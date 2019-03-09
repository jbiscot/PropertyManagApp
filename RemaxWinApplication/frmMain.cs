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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClients ft = new frmClients();
            ft.MdiParent = this;
            ft.Show();
        }

        private void emploToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployees ft = new frmEmployees();
            ft.MdiParent = this;
            ft.Show();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProperties ft = new frmProperties();
            ft.MdiParent = this;
            ft.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == (MessageBox.Show("Are you sure you want to quit the application?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                this.Hide();
                frmPublic form = new frmPublic();
                form.Show();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (clsGlobal.EmpAccessLevel == 2)
            {
                emploToolStripMenuItem.Enabled = false;
                return;
            }
        }
    }
}
