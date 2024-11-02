using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Student : Form
    {
        public string TransferredAdmin2 { get; set; }

        public Student()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                string searchQry = "select regNo from students";
                SqlCommand cmd = new SqlCommand(searchQry, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbRegNo.Items.Add(dr["regNo"].ToString());
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
        public static DataTable getTable(string qry) {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open ();
            
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();    
            return dt;
            
        }
        public static int runQry(string query) {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int rowsEffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsEffected;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtBirthday.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) {
                dtBirthday.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            string gender = "";
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if(rbFemale.Checked){
                gender = "Female";
            }
            if (string.IsNullOrWhiteSpace(txtMobile.Text)) {
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
            else {
                if (cbRegNo.Items.Contains(cbRegNo.Text))
                {
                    MessageBox.Show("This Register No is already in use\n Please choose a new Register No. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    try
                    {
                        con.Open();
                        string insertLoginQry = "insert into logintbl (username,password) values ('" + txtLName.Text.Trim() + txtFName.Text.Trim() + "','" + txtFName.Text.Trim() + "@123" + "')";
                        runQry(insertLoginQry);
                        string lastLoginQry = "select top 1 userId from logintbl order by userId desc";
                        SqlCommand cmd2 = new SqlCommand(lastLoginQry, con);
                        object result=cmd2.ExecuteScalar();
                        string insertQry = "insert into students (regNo,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo,userId) values ('" + cbRegNo.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + dtBirthday.Value + "','" + gender + "','" + txtAddress.Text + "','" + txtEmail.Text + "'," + int.Parse(txtMobile.Text) + "," + int.Parse(txtHome.Text) + ",'" + txtParent.Text + "','" + txtNIC.Text + "'," + int.Parse(txtContact.Text) + ","+int.Parse(result.ToString())+")";
                        string searchQry = "select regNo from students";                        
                        int rowsEffected = runQry(insertQry);
                        string qry = "select * from students";
                        dataGridView1.DataSource = getTable(qry);

                        SqlCommand cmd1 = new SqlCommand(searchQry, con);
                        SqlDataReader dr = cmd1.ExecuteReader();
                        cbRegNo.Items.Clear();
                        while (dr.Read())
                        {
                            cbRegNo.Items.Add(dr["regNo"].ToString());
                        }
                        if (rowsEffected > 0)
                        {
                            MessageBox.Show("Info inserted Successfully", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbRegNo.Items.Contains(cbRegNo.Text))
            {
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
                    if (string.IsNullOrWhiteSpace(cbRegNo.Text))
                    {
                        MessageBox.Show("Please enter the register number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbRegNo.Focus();
                    }
                    else
                    {
                        try
                        {
                            if (cbRegNo.Items.Contains(cbRegNo.Text))
                            {
                                con.Open();
                                string updateQry = "update students set firstName='" + txtFName.Text + "',lastName='" + txtLName.Text + "',dateOfBirth='" + dtBirthday.Value + "',gender='" + gender + "',address='" + txtAddress.Text + "',email='" + txtEmail.Text + "',mobilePhone=" + int.Parse(txtMobile.Text) + ",homePhone=" + int.Parse(txtHome.Text) + ",parentName='" + txtParent.Text + "',nic='" + txtNIC.Text + "',contactNo=" + int.Parse(txtContact.Text) + " where regNo='" + cbRegNo.Text + "'";
                                int rowsEffected = runQry(updateQry);
                                string qry = "select * from students";
                                dataGridView1.DataSource = getTable(qry);
                                if (rowsEffected > 0)
                                {
                                    MessageBox.Show("Info Updated Successfully", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

                            }
                            else
                            {
                                MessageBox.Show("Register No: " + cbRegNo.Text + " is not in the database currently \n Please try another Register No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Register No: " + cbRegNo.Text + " is not in the database currently \n Please try another Register No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string qry = "select * from students";
            dataGridView1.DataSource = getTable(qry);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbRegNo.Items.Contains(cbRegNo.Text)) {
                DialogResult result = MessageBox.Show(
                   "Are you sure you want to delete the query at regNo: " + cbRegNo.Text + " ?",
                   "Confirmation",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question

                   );
                if (result == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                    try
                    {
                        con.Open();
                        int userId = 0;
                        string deleteQry = "delete students where regNo = '" + cbRegNo.Text + "'";
                        string searchQry = "select regNo from students";
                        string searchLoginDetailQry = "select * from students where regNo='" + cbRegNo.Text + "'";
                        SqlCommand cmd2 = new SqlCommand(searchLoginDetailQry, con);
                        SqlDataReader dr1 = cmd2.ExecuteReader();
                        while (dr1.Read()) {
                            userId = int.Parse(dr1[12].ToString());
                        }
                        dr1.Close();
                        int rowsEffected = runQry(deleteQry);
                        string deleteLoginQry = "delete logintbl where userId = " + userId + "";
                        runQry(deleteLoginQry);

                        SqlCommand cmd1 = new SqlCommand(searchQry, con);
                        SqlDataReader dr = cmd1.ExecuteReader();
                        cbRegNo.Items.Clear();
                        while (dr.Read())
                        {
                            cbRegNo.Items.Add(dr["regNo"].ToString());
                        }
                        dr.Close();
                        cbRegNo.Text = "";
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
                        string qry = "select * from students";
                        dataGridView1.DataSource = getTable(qry);
                        if (rowsEffected > 0)
                        {
                            MessageBox.Show("Info Deleted Successfully", "Task Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else {
                MessageBox.Show("Register No: " + cbRegNo.Text + " is not in the database currently \n Please try another Register No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbRegNo.Text))
            {
                MessageBox.Show("Please enter a valid register number to search", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbRegNo.Focus();
            }
            else {
                if (cbRegNo.Items.Contains(cbRegNo.Text))
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K76MP8E\SQLEXPRESS;Initial Catalog=skillscollege;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                    try
                    {
                        con.Open();
                        string searchQry = "select * from students where regNo='" + cbRegNo.Text + "'";
                        SqlCommand cmd = new SqlCommand(searchQry, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
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
                            string qry = "select * from students";
                            dataGridView1.DataSource = getTable(qry);
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
                else
                {
                    MessageBox.Show("regNo " + cbRegNo.Text + " is not in the database currently \n Please try another regNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
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
            AdminInterface adminInterface = new AdminInterface();
            adminInterface.TransferredAdmin = TransferredAdmin2;
            adminInterface.Show();
            this.Close();
        }
    }
}
