using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemaxWinApplication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Validator Validation = new Validator();

            if (!Validation.IsEmpty(txtIDNumber.Text, "Login ID"))
            {
                txtIDNumber.Clear();
                txtIDNumber.Focus();
                return;
            }


            //Login Search
            bool found = false;
            foreach (DataRow ab in clsGlobal.tbEmployees.Rows)
            {
                if ((ab.Field<Int32>("Numb").ToString() == txtIDNumber.Text) && (ab.Field<string>("Pass").ToString() == txtPassword.Text))
                {

                    found = true;

                    //Defining access Level
                    if (ab.Field<string>("Pos").ToString() == "Manager")
                    {
                        clsGlobal.EmpAccessLevel = 1;
                    }
                    else clsGlobal.EmpAccessLevel = 2;


                    foreach (DataRow emp in clsGlobal.tbEmployees.Rows)
                    {
                        if (emp.Field<Int32>("Numb") == Convert.ToInt32(txtIDNumber.Text))
                        {
                            clsGlobal.EmpLoggedRef = emp.Field<Int32>("RefEmp");
                        }
                    }

                    frmMain form = new frmMain();
                    form.Show();
                    this.Hide();

                    return;
                }
            }

            if (!found)
            {
                MessageBox.Show("Incorrect ID or Password, please try again!", "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPublic form = new frmPublic();
            form.Show();
        }

        private void btnPasswords_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manager ID: 1111 \nPassword: 1111  \n\nSalesPerson ID: 2222\nPassword: 2222", "Password Tips");
        }

        private void txtIDNumber_Click(object sender, EventArgs e)
        {
            txtIDNumber.Clear();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "Login";
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmPublic fa = new frmPublic();
            fa.Show();
        }
    }
}
