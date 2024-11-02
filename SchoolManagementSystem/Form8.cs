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
    public partial class StudentLogin : Form
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                int userId = 0;
                string realUsername = "";
                string realPassword = "";
                string searchQry = "select * from logintbl where username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(searchQry, con);


                SqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows == false)
                {
                    MessageBox.Show("Invalid username or password please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    while (r.Read())
                    {
                        userId = int.Parse(r[0].ToString());
                        realUsername = r[1].ToString();
                        realPassword = r[2].ToString();
                    }
                    r.Close();
                    Console.WriteLine(userId);
                    string searchUserQry = "select count (*) from students where userId=" + userId + "";
                    SqlCommand cmd1 = new SqlCommand(searchUserQry, con);
                    int count = (int)cmd1.ExecuteScalar();
                    if (count > 0)
                    {
                        if (realUsername == username && realPassword == password)
                        {
                            StudentInterface studentInterface = new StudentInterface();
                            studentInterface.TransferredSId=userId;
                            studentInterface.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching \n" + ex);
            }
            finally { con.Close(); }
        }

        private void StudentLogin_Load(object sender, EventArgs e)
        {

        }
    }
}


