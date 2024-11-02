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
    public partial class UpdateStudentInfo : Form
    {
        public int TransferredSId1 { get; set; }
        public UpdateStudentInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentInterface studentInterface = new StudentInterface();
            studentInterface.TransferredSId = TransferredSId1;
            studentInterface.Show();
            this.Close();
        }

        private void UpdateStudentInfo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            int userId =int.Parse(TransferredSId1.ToString());
            try
            {
                con.Open();
                string searchQry = "select * from students where userId ='" + userId + "'";
                SqlCommand cmd = new SqlCommand(searchQry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtRegNo.Text = dr[0].ToString();
                    txtFName.Text = dr[1].ToString();
                    txtLName.Text = dr[2].ToString();
                    dtBirthday.Value = dr.GetDateTime(3);
                    if (dr[4].ToString() == "Male")
                    {
                        rbMale.Checked = true;
                    }
                    else if (dr[4].ToString() == "Female")
                    {
                        rbFemale.Checked = true;
                    }
                    else
                    {
                        rbMale.Checked = false;
                        rbFemale.Checked = false;
                    }
                    txtAddress.Text = dr[5].ToString();
                    txtEmail.Text = dr[6].ToString();
                    txtMobile.Text = dr[7].ToString();
                    txtHome.Text = dr[8].ToString();
                    txtParent.Text = dr[9].ToString();
                    txtNIC.Text = dr[10].ToString();
                    txtContact.Text = dr[11].ToString();
                    dataGridView1.DataSource = Student.getTable(searchQry);
                    
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(TransferredSId1.ToString());
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
                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else if (rbFemale.Checked)
                {
                    gender = "Female";
                }
                if (string.IsNullOrWhiteSpace(txtMobile.Text))
                {
                    txtMobile.Text = "0";
                }
                if (string.IsNullOrWhiteSpace(txtHome.Text))
                {
                    txtHome.Text = "0";
                }
                if (string.IsNullOrWhiteSpace(txtContact.Text))
                {
                    txtContact.Text = "0";
                }
                try
                {
                    con.Open();
                    string updateQry = "update students set firstName='" + txtFName.Text + "',lastName='" + txtLName.Text + "',dateOfBirth='" + dtBirthday.Value + "',gender='" + gender + "',address='" + txtAddress.Text + "',email='" + txtEmail.Text + "',mobilePhone=" + int.Parse(txtMobile.Text) + ",homePhone=" + int.Parse(txtHome.Text) + ",parentName='" + txtParent.Text + "',nic='" + txtNIC.Text + "',contactNo=" + int.Parse(txtContact.Text) + " where userId='" + userId + "'";
                    int rowsEffected = Student.runQry(updateQry);
                    string qry = "select * from students where userId='" + userId + "'";
                    dataGridView1.DataSource = Student.getTable(qry);
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
    }
}
