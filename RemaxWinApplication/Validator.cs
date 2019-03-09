using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RemaxWinApplication
{
    public class Validator
    {
        public bool IsEmpty(string txtInput, string type)
        {
            if (string.IsNullOrEmpty(txtInput) || string.IsNullOrWhiteSpace(txtInput))
            {
                MessageBox.Show("The field " + type.ToString() + " is empty.", "Invalid " + type.ToString(),
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public bool isValidID(TextBox txtInput, int size)
        {
            int tempId;
            if ((txtInput.TextLength != size) || !(int.TryParse(txtInput.Text, out tempId)))
            {
                txtInput.Clear();
                txtInput.Focus();
                return false;
            }
            return true;
        }


        //Certifies for numeric
        public bool isNumeric(string input, string type)
        {
            int tempId = 0;
            if ((!int.TryParse(input, out tempId)))
            {
                MessageBox.Show("The field " + type.ToString() + " has to contain a NUMERIC value.", "Invalid " + type.ToString(),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

    }
}
