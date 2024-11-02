using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class StudentInterface : Form
    {
        public int TransferredSId { get; set; }

        public StudentInterface()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            UpdateStudentInfo updateStudentInfo = new UpdateStudentInfo();
            updateStudentInfo.TransferredSId1 = TransferredSId;
            updateStudentInfo.Show();
            this.Close();
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

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePwUn changePwUn = new ChangePwUn();
            changePwUn.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
