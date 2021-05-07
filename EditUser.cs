using JStudzinski_CapstoneA.model;
using MySql.Data.MySqlClient;
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
    public partial class EditUser : Form
    {
        private bool doneLoading = false;
        User _user = new User();
        DBHelper _dbhelp = new DBHelper();
        public EditUser()
        {
            InitializeComponent();
            getUsers();
            cmbUserDefault();
        }

        public void getUsers()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            string sql = "Select * from User;";
            MySqlConnection _con = new MySqlConnection(DBConnection.connectSqlString);
            try
            {
                _con.Open();
                MySqlCommand _cmd = new MySqlCommand(sql, _con);
                da.SelectCommand = _cmd;
                da.Fill(dt);

                cmbUsers.ValueMember = "UserId";
                cmbUsers.DisplayMember = "username";
                cmbUsers.DataSource = dt;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Error getting user list " + ex, "Error");
            }
            finally
            {
                _con.Close();
            }

        }

        public void cmbUserDefault()
        {
            cmbUsers.SelectedItem = null;
            cmbUsers.Text = "Select Customer";
            btnSave.Enabled = false;
            doneLoading = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainScreen frm = new MainScreen();
            this.Hide();
            frm.Show();
        }

        private void cmbUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cmbUsers.SelectedValue);
            if (doneLoading)
            {
                btnSave.Enabled = true;
                _user = _dbhelp.getUserInfo(id);
                txtPassword.Text = _user.Password;
                txtUsername.Text = _user.userName;
            }
            
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (checkInfo())
            {
                _user.userName = txtUsername.Text;
                _user.Password = txtPassword.Text;

                var result= _dbhelp.UpdateUser(_user);
                if (result)
                {
                    if (MessageBox.Show("User information saved successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
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
