using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace StudentLates
{
    public partial class frmStudentLatesV2 : Form
    {
        public frmStudentLatesV2()
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
                            $"VALUES ('{cmbStudentID.SelectedValue}','{cmbPeriod.Text}','{DtpDateOfLate.Value.Date}','{txtMinsLate.Text}')";
            dbConnector.Connect();
            dbConnector.DoDML(cmdStr);
            dbConnector.Close();
            reOpenForm1();
        }

        private void frmStudentLatesV2_Load(object sender, EventArgs e)
        {
            // list to hold the studetid and the student name
            List<CLsStudent> studentList = new List<CLsStudent>();
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            dbConnector.Connect();
            sqlStr = "SELECT studentid, (surName & " + "', '" + "& firstname) as studentName From tblStudent";
            dr = dbConnector.DoSQL(sqlStr);
            // add all the students to the list
            while (dr.Read())
            {
                studentList.Add(new CLsStudent { studentid = Convert.ToInt32(dr[0]), studentname = dr[1].ToString() });
            }
            // now bind the combo box to the list
            cmbStudentID.DisplayMember = "studentname";
            cmbStudentID.ValueMember = "studentID";
            cmbStudentID.DataSource = studentList;
            dbConnector.Close();

        }
    }
}
