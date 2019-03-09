using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RemaxWinApplication
{
    public partial class frmClients : Form
    {
        public frmClients()
        {
            InitializeComponent();
        }


        private string mode;

        private void frmClients_Load(object sender, EventArgs e)
        {
            //TESTING ACCESSSES
            //MessageBox.Show(clsGlobal.EmpAccessLevel.ToString());
            //MessageBox.Show(clsGlobal.EmpLoggedRef.ToString());

            refresh();
            gridLoad();            
        }

        private void gridClient_SelectionChanged(object sender, EventArgs e)
        {
            if (gridClient.Rows.Count > 0)
            {
                try
                {
                    int abcd = Convert.ToInt32(gridClient.SelectedRows[0].Cells[0].Value.ToString());
                    txtFirstName.Text = gridClient.SelectedRows[0].Cells[1].Value.ToString();
                    txtLastName.Text = gridClient.SelectedRows[0].Cells[2].Value.ToString();
                    cboType.Text = gridClient.SelectedRows[0].Cells[3].Value.ToString();
                    cboAgent.SelectedValue = gridClient.SelectedRows[0].Cells[4].Value.ToString();

                    Int32 refc = Convert.ToInt32(gridClient.SelectedRows[0].Cells[4].Value.ToString());

                    DataRow myRow = clsGlobal.tbEmployees.Select("RefEmp = " + refc)[0];
                    cboAgent.Text = myRow["FirstName"].ToString();
                }

                catch
                {
                    return;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == (MessageBox.Show("Are you sure you want to delete from the list?",
                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                DataColumn[] col = { clsGlobal.tbClients.Columns["RefClient"] };
                clsGlobal.tbClients.PrimaryKey = col;

                DataRow myRow = clsGlobal.tbClients.Select("RefClient = " + gridClient.SelectedRows[0].Cells[0].Value.ToString())[0];

                myRow.Delete();

                OleDbCommandBuilder Build = new OleDbCommandBuilder(clsGlobal.adpClients);
                clsGlobal.adpClients.Update(clsGlobal.tbClients);

                gridLoad();
                refresh();
                btnCancel.PerformClick();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            txtFirstName.Clear();
            txtLastName.Clear();
            cboType.Text = null;
            cboAgent.Text = null;
            txtFirstName.Focus();
            mode = "Add";

            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            mode = "Edit";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void clearInfo()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            cboAgent.Text = null;
            cboType.Text = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInfo();
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            mode = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Input Information Validation-------------------------------------------- 

            Validator Validation = new Validator();

            if (!Validation.IsEmpty(cboType.Text, "Type") || !Validation.IsEmpty(txtFirstName.Text, "First Name") ||
                !Validation.IsEmpty(txtLastName.Text, "Last Name") || !Validation.IsEmpty(cboAgent.Text, "Agent Name"))
            {
                return;
            }
            //-------------------------------------------------------------------------


            DataRow myRow = null;

            if (mode == "Add")
            {
                myRow = clsGlobal.tbClients.NewRow();
            }

            if (mode == "Edit")
            {
                DataColumn[] col = { clsGlobal.tbClients.Columns["RefClient"] };
                clsGlobal.tbClients.PrimaryKey = col;
                myRow = clsGlobal.tbClients.Select("RefClient = " + gridClient.SelectedRows[0].Cells[0].Value.ToString())[0];

            }


            myRow["FirstName"] = txtFirstName.Text;
            myRow["LastName"] = txtLastName.Text;
            myRow["Type"] = cboType.Text;
            myRow["ReferEmp"] = cboAgent.SelectedValue;



            if (mode == "Add")
            {
                clsGlobal.tbClients.Rows.Add(myRow);
            }

            OleDbCommandBuilder Build = new OleDbCommandBuilder(clsGlobal.adpClients);
            clsGlobal.adpClients.Update(clsGlobal.tbClients);


            refresh();

            gridClient.DataSource = null;
            gridLoad();


            var Clients = from DataRow ab in clsGlobal.tbClients.Rows
                          where ab.Field<Int32>("ReferEmp") == clsGlobal.EmpLoggedRef
                          select ab;

            try
            {
                if (clsGlobal.EmpAccessLevel == 1)
                {
                    var Agent = from DataRow ab in clsGlobal.tbClients.Rows
                                select ab;
                    gridClient.DataSource = Agent.CopyToDataTable();
                }
                else
                {
                    gridClient.DataSource = Clients.CopyToDataTable();
                }
                gridClient.Columns[0].Visible = false;
            }
            catch
            {
                int a = 1;
            }

            btnCancel.PerformClick();
        }

        private void refresh()
        {
            clsGlobal.mySet.Tables["Clients"].Clear();
            clsGlobal.myCmdClient = new OleDbCommand("SELECT * from Clients", clsGlobal.myCon);
            clsGlobal.myReaderClient = clsGlobal.myCmdClient.ExecuteReader();

            clsGlobal.tbClients = new DataTable();
            clsGlobal.tbClients.Load(clsGlobal.myReaderClient);
        }

        private void gridLoad()
        {
            if (clsGlobal.EmpAccessLevel == 2)
            {
                var Agent = from DataRow ab in clsGlobal.tbEmployees.Rows
                            where ab.Field<Int32>("RefEmp") == clsGlobal.EmpLoggedRef
                            select ab;

                cboAgent.ValueMember = "RefEmp";
                cboAgent.DisplayMember = "FirstName";
                cboAgent.DataSource = Agent.CopyToDataTable();

                var Clients = from DataRow ab in clsGlobal.tbClients.Rows
                              where ab.Field<Int32>("ReferEmp") == clsGlobal.EmpLoggedRef
                              select ab;

                try
                {
                    gridClient.DataSource = Clients.CopyToDataTable();
                    gridClient.Columns[0].Visible = false;
                    gridClient.Columns[4].Visible = false;
                }
                catch
                {
                    int a = 1;
                }
            }

            else
            {
                gridClient.DataSource = clsGlobal.tbClients.AsDataView();

                var Agent = from DataRow ab in clsGlobal.tbEmployees.Rows
                            select ab;

                cboAgent.ValueMember = "RefEmp";
                cboAgent.DisplayMember = "FirstName";
                cboAgent.DataSource = Agent.CopyToDataTable();
                gridClient.Columns[0].Visible = false;
                gridClient.Columns[4].Visible = false;
            }
        }
    }
}
