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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                string searchSQry = "select regNo from students";
                SqlCommand cmd = new SqlCommand(searchSQry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbRegNo.Items.Add(dr["regNo"].ToString());
                }
                dr.Close();
                string searchTQry = "select regNo from teachers";
                SqlCommand cmd1 = new SqlCommand(searchTQry, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    cbRegNo.Items.Add(dr1["regNo"].ToString());
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

        private void cbRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbRegNo.Text.Trim().StartsWith("S", StringComparison.OrdinalIgnoreCase))
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
                if (string.IsNullOrWhiteSpace(cbRegNo.Text))
                {
                    MessageBox.Show("Please enter the register number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbRegNo.Focus();
                }
                else
                {
                    if (cbRegNo.Items.Contains(cbRegNo.Text))
                    {
                        MessageBox.Show("This Register No is already in use\n Please choose a new Register No. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            string insertLoginQry = "insert into logintbl (username,password) values ('" + txtLName.Text.Trim() + txtFName.Text.Trim() + "','" + txtFName.Text.Trim() + "@123" + "')";
                            Student.runQry(insertLoginQry);
                            string lastLoginQry = "select top 1 userId from logintbl order by userId desc";
                            SqlCommand cmd2 = new SqlCommand(lastLoginQry, con);
                            object result = cmd2.ExecuteScalar();
                            string insertQry = "insert into students (regNo,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo,userId) values ('" + cbRegNo.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + dtBirthday.Value + "','" + gender + "','" + txtAddress.Text + "','" + txtEmail.Text + "'," + int.Parse(txtMobile.Text) + "," + int.Parse(txtHome.Text) + ",'" + txtParent.Text + "','" + txtNIC.Text + "'," + int.Parse(txtContact.Text) + "," + int.Parse(result.ToString()) + ")";
                            int rowsEffected = Student.runQry(insertQry);
                            string qry = "select * from students where regNo='" + cbRegNo.Text.Trim() + "'";
                            dataGridView1.DataSource = Student.getTable(qry);



                            if (rowsEffected > 0)
                            {
                                MessageBox.Show("Info inserted Successfully \n Please do not make any changes", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            this.Cursor = Cursors.WaitCursor;
                            await Task.Delay(3000);
                            WelcomePage welcomePage = new WelcomePage();
                            welcomePage.Show();
                            this.Close();
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
            else if (cbRegNo.Text.Trim().StartsWith("T", StringComparison.OrdinalIgnoreCase)) {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                string gender = "";
                txtParent.ReadOnly = true;
                txtNIC.ReadOnly = true;
                txtContact.ReadOnly = true;
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
                if (string.IsNullOrWhiteSpace(cbRegNo.Text))
                {
                    MessageBox.Show("Please enter the register number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbRegNo.Focus();
                }
                else
                {
                    if (cbRegNo.Items.Contains(cbRegNo.Text))
                    {
                        MessageBox.Show("This Register No is already in use\n Please choose a new Register No. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            string insertLoginQry = "insert into logintbl (username,password) values ('" + txtLName.Text.Trim() + txtFName.Text.Trim() + "','" + txtFName.Text.Trim() + "@123" + "')";
                            Student.runQry(insertLoginQry);
                            string lastLoginQry = "select top 1 userId from logintbl order by userId desc";
                            SqlCommand cmd2 = new SqlCommand(lastLoginQry, con);
                            object result = cmd2.ExecuteScalar();
                            string insertQry = "insert into teachers (regNo,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,userId) values ('" + cbRegNo.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + dtBirthday.Value + "','" + gender + "','" + txtAddress.Text + "','" + txtEmail.Text + "'," + int.Parse(txtMobile.Text) + "," + int.Parse(txtHome.Text) + "," + int.Parse(result.ToString()) + ")";
                            int rowsEffected = Student.runQry(insertQry);
                            string qry = "select * from teachers where regNo='"+cbRegNo.Text.Trim()+"'";
                            dataGridView1.DataSource = Student.getTable(qry);

                            txtParent.Text = "----";
                            txtNIC.Text = "----";
                            txtContact.Text = "----";
                            if (rowsEffected > 0)
                            {
                                MessageBox.Show("Info inserted Successfully \n Please do not make any changes", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            this.Cursor = Cursors.WaitCursor;
                            await Task.Delay(3000);                           
                            WelcomePage welcomePage = new WelcomePage();
                            welcomePage.Show();
                            this.Close();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                      "Are you sure you want to clear all information?",
                      "Confirmation",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question

                      );
            if (result == DialogResult.Yes)
            {

                txtFName.Text = "";
                txtLName.Text = "";
                dtBirthday.Value = DateTime.Now;
                rbMale.Checked = false;
                rbFemale.Checked = false;
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtHome.Text = "";
                txtParent.Text = "";
                txtNIC.Text = "";
                txtContact.Text = "";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Hide();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
