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
    public partial class frmProperties : Form
    {
        public frmProperties()
        {
            InitializeComponent();
        }

        private string mode;

        private void frmProperties_Load(object sender, EventArgs e)
        {

            //TESTING ACCESSSES
            //MessageBox.Show(clsGlobal.EmpAccessLevel.ToString());
            //MessageBox.Show(clsGlobal.EmpLoggedRef.ToString());

            refresh();
            gridLoad();        


            foreach (DataRow ab in clsGlobal.tbProperties.Rows)
            {
                if (!cboType.Items.Contains(ab.Field<String>("Type").ToString()))
                {
                    cboType.Items.Add(ab.Field<String>("Type").ToString());
                }
            }
        }

        private void gridProperties_SelectionChanged(object sender, EventArgs e)
        {
            if (gridProperties.Rows.Count > 0)
            {
                try
                {
                    int abcd = Convert.ToInt32(gridProperties.SelectedRows[0].Cells[0].Value.ToString());
                    txtNumber.Text = gridProperties.SelectedRows[0].Cells[1].Value.ToString();
                    cboType.Text = gridProperties.SelectedRows[0].Cells[2].Value.ToString();
                    txtCity.Text = gridProperties.SelectedRows[0].Cells[3].Value.ToString();
                    txtBedrooms.Text = gridProperties.SelectedRows[0].Cells[4].Value.ToString();
                    txtBathrooms.Text = gridProperties.SelectedRows[0].Cells[5].Value.ToString();
                    txtGarage.Text = gridProperties.SelectedRows[0].Cells[6].Value.ToString();
                    txtPrice.Text = gridProperties.SelectedRows[0].Cells[7].Value.ToString();
                    cboAgent.Text = gridProperties.SelectedRows[0].Cells[8].Value.ToString();
                    cboClient.Text = gridProperties.SelectedRows[0].Cells[9].Value.ToString();

                    Int32 refEmp = Convert.ToInt32(gridProperties.SelectedRows[0].Cells[8].Value.ToString());
                    Int32 refCli = Convert.ToInt32(gridProperties.SelectedRows[0].Cells[9].Value.ToString());

                    DataColumn[] Keys = new DataColumn[1];
                    Keys[0] = clsGlobal.tbEmployees.Columns["RefEmp"];
                    clsGlobal.tbEmployees.PrimaryKey = Keys;

                    DataRow myRow = clsGlobal.tbEmployees.Rows.Find(refEmp);
                    cboAgent.Text = myRow["FirstName"].ToString();

                    DataColumn[] Keys2 = new DataColumn[1];
                    Keys2[0] = clsGlobal.tbClients.Columns["RefClient"];
                    clsGlobal.tbClients.PrimaryKey = Keys2;

                    DataRow myRow2 = clsGlobal.tbClients.Rows.Find(refCli);
                    cboClient.Text = myRow2["FirstName"].ToString();
                }

                catch
                {
                    return;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearInfo();
            txtNumber.Focus();
            mode = "Add";

            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtNumber.Focus();
            mode = "Edit";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void clearInfo()
        {
            txtNumber.Clear();
            cboType.Text = null;
            txtCity.Clear();
            txtBedrooms.Clear();
            txtBathrooms.Clear();
            txtGarage.Clear();
            cboAgent.Text = null;
            cboClient.Text = null;
            txtPrice.Clear();
            txtNumber.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == (MessageBox.Show("Are you sure you want to delete from the list?",
                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                DataColumn[] col = { clsGlobal.tbProperties.Columns["RefProp"] };
                clsGlobal.tbProperties.PrimaryKey = col;

                DataRow myRow = clsGlobal.tbProperties.Select("RefProp = " + gridProperties.SelectedRows[0].Cells[0].Value.ToString())[0];

                myRow.Delete();

                OleDbCommandBuilder Build = new OleDbCommandBuilder(clsGlobal.adpProperties);
                clsGlobal.adpProperties.Update(clsGlobal.tbProperties);

                gridLoad();

                refresh();
                btnCancel.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Input Information Validation-------------------------------------------- 

            Validator Validation = new Validator();

            if (!Validation.isValidID(txtNumber, 4))
            {
                MessageBox.Show("Property must have a 4 digit ID number.", "Invalid Property Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validation.isNumeric(txtNumber.Text, "Property Number"))
            {
                return;
            }

            if (!Validation.IsEmpty(cboType.Text, "Type") || !Validation.IsEmpty(txtCity.Text, "City") ||
                !Validation.IsEmpty(txtBedrooms.Text, "Bedrooms") || !Validation.isNumeric(txtBedrooms.Text, "Bedrooms") ||
                !Validation.IsEmpty(txtBathrooms.Text, "Bathrooms") || !Validation.isNumeric(txtBathrooms.Text, "Bathrooms") ||
                !Validation.IsEmpty(txtGarage.Text, "Garage") || !Validation.isNumeric(txtGarage.Text, "Garage") ||
                !Validation.IsEmpty(cboAgent.Text, "Agent") || !Validation.IsEmpty(cboClient.Text, "Client") ||
                !Validation.IsEmpty(txtPrice.Text, "Price") || !Validation.isNumeric(txtPrice.Text, "Price"))
            {
                return;
            }

            //-------------------------------------------------------------------------


            DataRow myRow = null;

            if (mode == "Add")
            {
                myRow = clsGlobal.tbProperties.NewRow();
            }

            if (mode == "Edit")
            {
                DataColumn[] col = { clsGlobal.tbProperties.Columns["RefProp"] };
                clsGlobal.tbProperties.PrimaryKey = col;
                myRow = clsGlobal.tbProperties.Select("RefProp = " + gridProperties.SelectedRows[0].Cells[0].Value.ToString())[0];

            }

            myRow["Numb"] = txtNumber.Text;
            myRow["Type"] = cboType.Text;
            myRow["City"] = txtCity.Text;
            myRow["Bedrooms"] = txtBedrooms.Text;
            myRow["Bathrooms"] = txtBathrooms.Text;
            myRow["Garage"] = txtGarage.Text;
            myRow["Price"] = txtPrice.Text;
            myRow["ReferEmp"] = cboAgent.SelectedValue;
            myRow["ReferClie"] = cboClient.SelectedValue;

            txtNumber.Clear();
            cboType.Text = null;
            txtCity.Clear();
            txtBedrooms.Clear();
            txtBathrooms.Clear();
            txtGarage.Clear();
            cboAgent.Text = null;
            cboClient.Text = null;
            txtPrice.Clear();
            txtNumber.Focus();


            if (mode == "Add")
            {
                clsGlobal.tbProperties.Rows.Add(myRow);
            }

            OleDbCommandBuilder Build = new OleDbCommandBuilder(clsGlobal.adpProperties);
            clsGlobal.adpProperties.Update(clsGlobal.tbProperties);



            refresh();
            gridProperties.DataSource = null;
            gridLoad();

            btnCancel.PerformClick();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void refresh()
        {
            clsGlobal.mySet.Tables["Properties"].Clear();
            clsGlobal.myCmdProperty = new OleDbCommand("SELECT * from Properties", clsGlobal.myCon);
            clsGlobal.myReaderProperty = clsGlobal.myCmdProperty.ExecuteReader();

            clsGlobal.tbProperties = new DataTable();
            clsGlobal.tbProperties.Load(clsGlobal.myReaderProperty);
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


                var Client = from DataRow ab in clsGlobal.tbClients.Rows
                             where ab.Field<Int32>("ReferEmp") == clsGlobal.EmpLoggedRef
                             select ab;

                cboClient.ValueMember = "RefClient";
                cboClient.DisplayMember = "FirstName";
                cboClient.DataSource = Client.CopyToDataTable();



                var Properties = from DataRow ab in clsGlobal.tbProperties.Rows
                                 where ab.Field<Int32>("ReferEmp") == clsGlobal.EmpLoggedRef
                                 select ab;

                try
                {
                    gridProperties.DataSource = Properties.CopyToDataTable();
                    gridProperties.Columns[0].Visible = false;
                    gridProperties.Columns[8].Visible = false;
                    gridProperties.Columns[9].Visible = false;
                }
                catch
                {
                    int a = 1;
                }
            }

            else
            {
                var Agent = from DataRow ab in clsGlobal.tbEmployees.Rows
                            select ab;

                cboAgent.ValueMember = "RefEmp";
                cboAgent.DisplayMember = "FirstName";
                cboAgent.DataSource = Agent.CopyToDataTable();


                var Client = from DataRow ab in clsGlobal.tbClients.Rows
                             select ab;

                cboClient.ValueMember = "RefClient";
                cboClient.DisplayMember = "FirstName";
                cboClient.DataSource = Client.CopyToDataTable();

                gridProperties.DataSource = clsGlobal.tbProperties.AsDataView();
                gridProperties.Columns[0].Visible = false;
                gridProperties.Columns[8].Visible = false;
                gridProperties.Columns[9].Visible = false;
            }
        }
    }
}
