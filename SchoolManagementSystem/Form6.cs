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
    public partial class TeacherInterface : Form
    {
        public int TransferredTId { get; set; }
        public TeacherInterface()
        {
            InitializeComponent();
        }

        private void TeacherInterface_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePwUn changePwUn = new ChangePwUn();
            changePwUn.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            welcomePage.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateTeacherInfo updateTeacherInfo = new UpdateTeacherInfo();      
            updateTeacherInfo.TransferredTId1 = TransferredTId;
            updateTeacherInfo.Show();
            this.Close();
        }
    }
}
