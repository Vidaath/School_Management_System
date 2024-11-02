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
    public partial class AdminInterface : Form
    {
        public string TransferredAdmin { get; set; }

        public AdminInterface()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.TransferredAdmin2 = TransferredAdmin;
            student.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.TransferredAdmin3 = TransferredAdmin;
            teacher.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePwUn changePwUn = new ChangePwUn();
            changePwUn.TransferredAdmin1 = TransferredAdmin;
            changePwUn.Show();
        }
    }
}
