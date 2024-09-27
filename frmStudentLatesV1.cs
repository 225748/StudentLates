using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentLates
{
    public partial class frmStudentLatesV1 : Form
    {
        public frmStudentLatesV1()
        {
            InitializeComponent();
        }
        public void reOpenForm1()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string cmdStr = "INSERT INTO tblLate (studentID,period,dateOfLate,minsLate) " +
                            $"VALUES ('{txtStudentID.Text}','{comboPeriod.SelectedValue}','{DtpDateOfLate.Value.Date}','{txtMinsLate.Text}')";
            dbConnector.Connect();
            dbConnector.DoDML(cmdStr);
            dbConnector.Close();
            reOpenForm1();
            
        }
    }
}
