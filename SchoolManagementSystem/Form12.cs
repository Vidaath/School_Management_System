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
    public partial class UpdateTeacherInfo : Form
    { 
        public int TransferredTId1 { get; set; }
        public UpdateTeacherInfo()
        {
            InitializeComponent();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TeacherInterface teacherInterface = new TeacherInterface();
            teacherInterface.TransferredTId = TransferredTId1;
            teacherInterface.Show();
            this.Close();
        }

        private void UpdateTeacherInfo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            int userId = int.Parse(TransferredTId1.ToString());
            try
            {
                con.Open();
                string searchQry = "select * from teachers where userId ='" + userId + "'";
                SqlCommand cmd = new SqlCommand(searchQry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtRegNo.Text = dr[0].ToString();
                    txtFNameT.Text = dr[1].ToString();
                    txtLNameT.Text = dr[2].ToString();
                    dtBirthdayT.Value = dr.GetDateTime(3);
                    if (dr[4].ToString() == "Male")
                    {
                        rbMaleT.Checked = true;
                    }
                    else if (dr[4].ToString() == "Female")
                    {
                        rbFemaleT.Checked = true;
                    }
                    else
                    {
                        rbMaleT.Checked = false;
                        rbFemaleT.Checked = false;
                    }
                    txtAddressT.Text = dr[5].ToString();
                    txtEmailT.Text = dr[6].ToString();
                    txtMobileT.Text = dr[7].ToString();
                    txtHomeT.Text = dr[8].ToString();
                    dataGridView3.DataSource = Student.getTable(searchQry);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  \n" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(TransferredTId1.ToString());
            DialogResult result = MessageBox.Show(
                      "Are you sure you want to update all information?",
                      "Confirmation",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question

                      );
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                string gender = "";
                if (rbMaleT.Checked)
                {
                    gender = "Male";
                }
                else if (rbFemaleT.Checked)
                {
                    gender = "Female";
                }
                if (string.IsNullOrWhiteSpace(txtMobileT.Text))
                {
                    txtMobile.Text = "0";
                }
                if (string.IsNullOrWhiteSpace(txtHomeT.Text))
                {
                    txtHome.Text = "0";
                }
                try
                {
                    con.Open();
                    string updateQry = "update teachers set firstName='" + txtFNameT.Text + "',lastName='" + txtLNameT.Text + "',dateOfBirth='" + dtBirthdayT.Value + "',gender='" + gender + "',address='" + txtAddressT.Text + "',email='" + txtEmailT.Text + "',mobilePhone=" + int.Parse(txtMobileT.Text) + ",homePhone=" + int.Parse(txtHomeT.Text) + "where userId='" + userId + "'";
                    int rowsEffected = Student.runQry(updateQry);
                    string qry = "select * from teachers where userId='" + userId + "'";
                    dataGridView3.DataSource = Student.getTable(qry);
                    if (rowsEffected > 0)
                    {
                        MessageBox.Show("Info Updated Successfully", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error  \n" + ex);
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void txtRegNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
