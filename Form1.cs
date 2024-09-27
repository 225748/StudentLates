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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        public void DisplayData()
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            dbConnector.Connect();
            sqlStr = "SELECT studentID, firstName, surName, studentDOB FROM tblStudent";
            dr = dbConnector.DoSQL(sqlStr);
            lstVStudents.Items.Clear();
            while (dr.Read())
            {
                lstVStudents.Items.Add(dr[0].ToString()); //retrieves all the columns headings
                lstVStudents.Items[lstVStudents.Items.Count - 1].SubItems.Add(dr[1].ToString()); //each column is a subitem
                lstVStudents.Items[lstVStudents.Items.Count - 1].SubItems.Add(dr[2].ToString());
                lstVStudents.Items[lstVStudents.Items.Count - 1].SubItems.Add(dr[3].ToString());
            }
            dbConnector.Close();
        }

        private void lstVStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenStudentForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudent studentForm = new frmStudent();
            studentForm.Show();
            
        }

        private void lstVStudents_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudentLatesV1 latesForm = new frmStudentLatesV1();
            latesForm.Show();
        }

        private void btnLatesV2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStudentLatesV2 latesForm = new frmStudentLatesV2();
            latesForm.Show();
        }
    }
}
