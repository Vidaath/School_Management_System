using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class ChangePwUn : Form
    {
        public string TransferredAdmin1 { get; set; }
        public ChangePwUn()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtNewUsername.Text))
                {
                    MessageBox.Show("Please fill the relevant feilds", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    con.Open();

                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Text.Trim();
                    string searchQry = "select * from logintbl where username = '" + username + "'";
                    SqlCommand cmd = new SqlCommand(searchQry, con);
                    SqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        int userId = int.Parse(r[0].ToString());
                        string realUsername = r[1].ToString();
                        string realPassword = r[2].ToString();
                        if (realUsername == username && realPassword == password)
                        {
                            string updateQry = "update logintbl set username='" + txtNewUsername.Text.Trim() + "',password='" + txtNewPassword.Text.Trim() + "' where userId=" + userId + "";
                            int rowsEffected = Student.runQry(updateQry);
                            if (rowsEffected > 0)
                            {
                                MessageBox.Show("Username and Password Updated Successfully", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid initial username or password please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    if (r.HasRows == false)
                    {
                        MessageBox.Show("Initial username does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching \n" + ex);
            }
            finally { con.Close(); }
        }

        private void ChangePwUn_Load(object sender, EventArgs e)
        {
            if (TransferredAdmin1 == "Admin") {
                txtNewUsername.Text = "Admin";
                txtNewUsername.ReadOnly = true;
            }
        }
    }
}
