using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JStudzinski_CapstoneA
{
    public partial class NewUser : Form
    {
        DBHelper _dbhelp = new DBHelper();
        public NewUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainScreen frm = new MainScreen();
            this.Hide();
            frm.Show();
        }

        public bool checkInfo()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("You must enter a username.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("You must enter a password.");
                return false;
            }
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (checkInfo())
            {
                var result = _dbhelp.CreateUser(txtUsername.Text, txtPassword.Text);
                if (result)
                {
                    if (MessageBox.Show("New user added successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        MainScreen frm = new MainScreen();
                        this.Hide();
                        frm.Show();
                    }
                }
            }

        }
    }
}
