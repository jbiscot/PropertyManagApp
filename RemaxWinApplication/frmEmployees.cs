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
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        //Last button clicked tracker variable
        private string mode;

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            refresh();
            gridEmployee.DataSource = clsGlobal.tbEmployees.AsDataView();

            btnSave.Enabled = false;
            gridEmployee.Columns[0].Visible = false;
        }



        private void gridEmployee_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEmployee.Rows.Count > 0)
            {
                try
                {
                    int abcd = Convert.ToInt32(gridEmployee.SelectedRows[0].Cells[0].Value.ToString());
                    txtNumber.Text = gridEmployee.SelectedRows[0].Cells[1].Value.ToString();
                    txtFirstName.Text = gridEmployee.SelectedRows[0].Cells[2].Value.ToString();
                    txtLastName.Text = gridEmployee.SelectedRows[0].Cells[3].Value.ToString();
                    cboPosition.Text = gridEmployee.SelectedRows[0].Cells[4].Value.ToString();
                    txtPassword.Text = gridEmployee.SelectedRows[0].Cells[5].Value.ToString();
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
                //DataColumn[] col = { clsGlobal.tbEmployees.Columns["RefEmp"] };
                //clsGlobal.tbEmployees.PrimaryKey = col;

                //DataRow myRow = clsGlobal.tbEmployees.Rows.Find(gridEmployee.SelectedRows[0].Cells[0].Value.ToString());
                DataRow myRow = clsGlobal.tbEmployees.Select("RefEmp = " + gridEmployee.SelectedRows[0].Cells[0].Value.ToString())[0];

                myRow.Delete();


                OleDbCommandBuilder Build = new OleDbCommandBuilder(clsGlobal.adpEmployees);
                clsGlobal.adpEmployees.Update(clsGlobal.tbEmployees);

                gridEmployee.DataSource = clsGlobal.tbEmployees.AsDataView();
                gridEmployee.Columns[0].Visible = false;

                refresh();

                btnCancel.PerformClick();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtNumber.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPassword.Clear();
            cboPosition.Text = null;
            txtNumber.Focus();
            mode = "Add";

            btnAdd.Enabled = false;
            btnSave.Enabled = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Input Information Validation-------------------------------------------- 

            Validator Validation = new Validator();

            if (!Validation.isValidID(txtNumber, 4))
            {
                MessageBox.Show("Employee must have a 4 digit ID number.", "Invalid ID Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validation.isNumeric(txtNumber.Text, "Employee ID"))
            {
                //MessageBox.Show("Employee must have a 4 DIGIT ONLY ID number.", "Invalid ID Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validation.IsEmpty(cboPosition.Text, "Position") || !Validation.IsEmpty(txtFirstName.Text, "First Name") ||
                !Validation.IsEmpty(txtLastName.Text, "Last Name") || !Validation.IsEmpty(txtPassword.Text, "Password"))
            {
                return;
            }

            //-------------------------------------------------------------------------



            DataRow myRow = null;

            if (mode == "Add")
            {
                myRow = clsGlobal.tbEmployees.NewRow();
            }

            if (mode == "Edit")
            {
                //DataColumn[] col = { clsGlobal.tbEmployees.Columns["RefEmp"] };
                //clsGlobal.tbEmployees.PrimaryKey = col;
                //myRow = clsGlobal.tbEmployees.Rows.Find(gridEmployee.SelectedRows[0].Cells[0].Value.ToString());
                myRow = clsGlobal.tbEmployees.Select("RefEmp = " + gridEmployee.SelectedRows[0].Cells[0].Value.ToString())[0];

            }


            myRow["Numb"] = Convert.ToInt32(txtNumber.Text);
            myRow["FirstName"] = txtFirstName.Text;
            myRow["LastName"] = txtLastName.Text;
            myRow["Pos"] = cboPosition.Text;
            myRow["Pass"] = txtPassword.Text;

            if (mode == "Add")
            {
                clsGlobal.tbEmployees.Rows.Add(myRow);
            }

            OleDbCommandBuilder Build = new OleDbCommandBuilder(clsGlobal.adpEmployees);
            clsGlobal.adpEmployees.Update(clsGlobal.tbEmployees);

            refresh();

            gridEmployee.DataSource = null;
            gridEmployee.DataSource = clsGlobal.tbEmployees.AsDataView();
            gridEmployee.Columns[0].Visible = false;

            btnCancel.PerformClick();
        }


        private void clearInfo()
        {
            txtNumber.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            cboPosition.Text = null;
            txtPassword.Clear();
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

        private void refresh()
        {
            clsGlobal.mySet.Tables["Employees"].Clear();
            clsGlobal.myCmdEmployee = new OleDbCommand("SELECT * from Employees", clsGlobal.myCon);
            clsGlobal.myReaderEmployee = clsGlobal.myCmdEmployee.ExecuteReader();

            clsGlobal.tbEmployees = new DataTable();
            clsGlobal.tbEmployees.Load(clsGlobal.myReaderEmployee);

            //OleDbCommandBuilder Build = new OleDbCommandBuilder(clsGlobal.adpEmployees);
            //clsGlobal.adpEmployees.Update(clsGlobal.tbEmployees);
        }

    }
}
