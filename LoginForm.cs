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
    public partial class LoginForm : Form
    {
        DBHelper _dbhelp = new DBHelper();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var result = _dbhelp.Login(txtUsername.Text, txtPassword.Text);
            if (result)
            {
                MainScreen frm = new MainScreen();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Could not log you in. Check username and password.", "Error");
            }
        }
    }
}
