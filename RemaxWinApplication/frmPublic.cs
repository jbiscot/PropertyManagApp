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
    public partial class frmPublic : Form
    {
        public frmPublic()
        {
            InitializeComponent();
        }

        private void frmPublic_Load(object sender, EventArgs e)
        {
            clsGlobal.mySet = new DataSet();
            clsGlobal.myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DATA\RemaxDataBase.mdb");
            clsGlobal.myCon.Open();


            //Employees 
            clsGlobal.myCmdEmployee = new OleDbCommand("SELECT * from Employees", clsGlobal.myCon);
            clsGlobal.myReaderEmployee = clsGlobal.myCmdEmployee.ExecuteReader();

            clsGlobal.tbEmployees = new DataTable();
            clsGlobal.tbEmployees.Load(clsGlobal.myReaderEmployee);

            clsGlobal.adpEmployees = new OleDbDataAdapter(clsGlobal.myCmdEmployee);
            clsGlobal.adpEmployees.Fill(clsGlobal.mySet, "Employees");


            //Clients
            clsGlobal.myCmdClient = new OleDbCommand("SELECT * from Clients", clsGlobal.myCon);
            clsGlobal.myReaderClient = clsGlobal.myCmdClient.ExecuteReader();

            clsGlobal.tbClients = new DataTable();
            clsGlobal.tbClients.Load(clsGlobal.myReaderClient);

            clsGlobal.adpClients = new OleDbDataAdapter(clsGlobal.myCmdClient);
            clsGlobal.adpClients.Fill(clsGlobal.mySet, "Clients");


            //Properties
            clsGlobal.myCmdProperty = new OleDbCommand("SELECT * from Properties", clsGlobal.myCon);
            clsGlobal.myReaderProperty = clsGlobal.myCmdProperty.ExecuteReader();

            clsGlobal.tbProperties = new DataTable();
            clsGlobal.tbProperties.Load(clsGlobal.myReaderProperty);

            clsGlobal.adpProperties = new OleDbDataAdapter(clsGlobal.myCmdProperty);
            clsGlobal.adpProperties.Fill(clsGlobal.mySet, "Properties");


            fillComboBoxes();
        }

        private void fillComboBoxes()
        {
            var employees = from DataRow emp in clsGlobal.tbEmployees.Rows select new { fname = emp.Field<string>("FirstName"), refEmp = emp.Field<Int32>("RefEmp") };
            if (employees.Count() > 0)
            {
                cboEmployee.DisplayMember = "fname";
                cboEmployee.ValueMember = "refEmp";
                cboEmployee.DataSource = employees.Distinct().ToList();
                cboEmployee.Text = null;
                cboEmployee.Enabled = false;
            }

            foreach (DataRow ab in clsGlobal.tbProperties.Rows)
            {
                if (!cboCity.Items.Contains(ab.Field<String>("City").ToString()))
                {
                    cboCity.Items.Add(ab.Field<String>("City").ToString());
                }
            }

            foreach (DataRow ab in clsGlobal.tbProperties.Rows)
            {
                if (cboType.Items.Count < 0)                   
                {
                    cboType.Items.Add(ab.Field<String>("Type").ToString());
                }
                else if (!cboType.Items.Contains(ab.Field<String>("Type").ToString())) {
                    cboType.Items.Add(ab.Field<String>("Type").ToString());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * from PROPERTIES ";
            bool searchFilters = true;

            //Search using the Property Reference Number
            if (!string.IsNullOrEmpty(txtPropRef.Text))
            {
                sql += "WHERE [Numb] = " + txtPropRef.Text.ToString() + "";
                searchFilters = false;
            }


            if (searchFilters)
            {
                //Searching by Agent SQL statement
                if ((radioAgent.Checked) && !(radioProperty.Checked))
                {

                    if (cboEmployee.Text == "")
                    {
                        MessageBox.Show("Please, select an Agent as search cirteria!", "Select a Remax Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    sql += "WHERE ReferEmp = " + cboEmployee.SelectedValue.ToString() + "";

                    if (cboType.Text != "")
                    {
                        sql += " AND [Type] = '" + cboType.Text.ToString() + "'";
                    }

                    if (cboCity.Text != "")
                    {
                        sql += " AND [City] = '" + cboCity.Text.ToString() + "'";
                    }

                    if (cboBedrooms.Text != "")
                    {
                        if (cboBedrooms.Text == "4+")
                        {
                            sql += " AND [Bedrooms] >= 4";
                        }

                        else sql += " AND [Bedrooms] = " + cboBedrooms.Text.ToString() + "";
                    }

                    if (cboBathrooms.Text != "")
                    {
                        if (cboBathrooms.Text == "4+")
                        {
                            sql += " AND [Bathrooms] >= 4";
                        }
                        else sql += " AND [Bathrooms] = " + cboBathrooms.Text.ToString() + "";
                    }
                }

                //Searching by Property SQL statement
                if ((radioProperty.Checked) && !(radioAgent.Checked))
                {
                    sql += "WHERE ReferEmp >= 0 ";

                    if (cboType.Text != "")
                    {
                        sql += " AND [Type] = '" + cboType.Text.ToString() + "'";
                    }

                    if (cboCity.Text != "")
                    {
                        sql += " AND [City] = '" + cboCity.Text.ToString() + "'";
                    }

                    if (cboBedrooms.Text != "")
                    {
                        if (cboBedrooms.Text == "4+")
                        {
                            sql += " AND [Bedrooms] >= 4";
                        }
                        else sql += " AND [Bedrooms] = " + cboBedrooms.Text.ToString() + "";
                    }

                    if (cboBathrooms.Text != "")
                    {
                        if (cboBathrooms.Text == "4+")
                        {
                            sql += " AND [Bathrooms] >= 4";
                        }
                        else sql += " AND [Bathrooms] = " + cboBathrooms.Text.ToString() + "";
                    }
                }
            }


            //Displaying the results
            OleDbCommand myCmd = new OleDbCommand(sql, clsGlobal.myCon);
            OleDbDataReader myReader = myCmd.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Load(myReader);
            gridResult.DataSource = Table;
            gridResult.Columns[0].Visible = false;
            gridResult.Columns[8].Visible = false;
            gridResult.Columns[9].Visible = false;

            if (gridResult.Rows.Count == 1)
            {
                MessageBox.Show("Sorry, no Property is available for you under these conditions.", "Remax Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin form = new frmLogin();
            form.Show();
            this.Hide();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtPropRef.Clear();
            cboBathrooms.Text = null;
            cboBedrooms.Text = null;
            cboCity.Text = null;
            cboEmployee.Text = null;
            cboType.Text = null;
            txtPropRef.Text = "";

            if (radioProperty.Checked)
            {
                cboEmployee.Enabled = false;
            }

        }

        private void radioAgent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAgent.Checked)
            {
                cboEmployee.Enabled = true;
            }
            else cboEmployee.Enabled = false;
        }

        private void frmPublic_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
