using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SchoolManagementSystem
{
    public partial class AdminLogin : Form
    {
       
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                string username=txtUsername.Text.Trim();   
                string password=txtPassword.Text.Trim();
                string searchQry = "select * from logintbl where username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(searchQry, con);
                SqlDataReader r=cmd.ExecuteReader();
                
                while (r.Read()) { 
                    string realUsername = r[1].ToString();
                    string realPassword = r[2].ToString();
                    if (username =="Admin"  && realPassword == password)
                    {
                        AdminInterface main = new AdminInterface();
                        main.TransferredAdmin = "Admin";
                        main.Show();
                        this.Hide();
                    }
                    else{
                        MessageBox.Show("Invalid username or password please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                if (r.HasRows==false) {
                    MessageBox.Show("Invalid username or password please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show("Error while searching \n"+ex);
            }
            finally{ con.Close(); }
            

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
