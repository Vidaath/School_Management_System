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
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
           
        }
        private void displayCount(string type) {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            string countQry = "";
            if (type == "students") {
                countQry = "select count(*) from students";
            }
            else if (type=="teachers") {
                countQry = "select count(*) from teachers";
            }
            try {
                con.Open();
                SqlCommand cmd = new SqlCommand(countQry,con);
                Int32 count=Convert.ToInt32(cmd.ExecuteScalar());
                if (type == "students")
                {
                    lblStudents.Text=Convert.ToString(count.ToString());
                }
                else if (type == "teachers")
                {
                    lblTeachers.Text = Convert.ToString(count.ToString());
                }

            }
            catch (Exception ex){
                MessageBox.Show("Error  \n" + ex);
            }
            finally {
                con.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {
            displayCount("students");
            displayCount("teachers");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentLogin studentLogin = new StudentLogin();
            studentLogin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeacherLogin teacherLogin = new TeacherLogin();
            teacherLogin.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewUser newUser=new NewUser();
            newUser.Show();
            this.Hide();
        }
    }
}
