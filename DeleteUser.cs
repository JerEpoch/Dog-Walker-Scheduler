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
    public partial class DeleteUser : Form
    {
        private bool doneLoading = false;
        DBHelper _dbhelp = new DBHelper();
        User _user = new User();
        public DeleteUser()
        {
            InitializeComponent();
            getUsers();
            cmbUserDefault();
        }

        public void cmbUserDefault()
        {
            cmbUsers.SelectedItem = null;
            cmbUsers.Text = "Select Customer";
            btnDelete.Enabled = false;
            doneLoading = true;
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
                btnDelete.Enabled = true;
                _user = _dbhelp.getUserInfo(id);
                txtPassword.Text = _user.Password;
                txtUsername.Text = _user.userName;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this user?","Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var result = _dbhelp.DeleteUser(Convert.ToInt32(cmbUsers.SelectedValue));
                if (result)
                {
                    if (MessageBox.Show("user deleted successfully.", "Success", MessageBoxButtons.OK) == DialogResult.OK)
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
