﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentLates
{
    public partial class frmStudent : Form
    {
        public frmStudent()
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
            string cmdStr = $"INSERT INTO tblStudent  (firstName,surName, StudentDOB) " +
                $"VALUES ('{txtfirstName.Text}' , '{txtSurName.Text}', '{dtpDob.Value.Date}')";
            dbConnector.Connect();
            dbConnector.DoDML(cmdStr);
            dbConnector.Close();
            reOpenForm1();

        }

        private void frmStudent_Load(object sender, EventArgs e)
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
            cmbStudentID.ValueMember = "studentid";
            cmbStudentID.DataSource = studentList;
            dbConnector.Close();

        }

        private void cmbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            dbConnector.Connect();
            sqlStr = "SELECT studentID, firstName, surName, StudentDOB" +
                " FROM tblStudent" +
                " WHERE studentID = " + cmbStudentID.SelectedValue;
            dr = dbConnector.DoSQL(sqlStr);

            while (dr.Read())
            {
                txtfirstName.Text = dr[1].ToString();
                txtSurName.Text = dr[2].ToString();
                dtpDob.Value = Convert.ToDateTime(dr[3]);
            }
            dbConnector.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clsDBConnector dbConnector = new clsDBConnector();
            string cmdStr = "UPDATE tblStudent " +
                            $"SET firstName = '{txtfirstName.Text}'," +
                            $"surName = '{txtSurName.Text}'," +
                            $"StudentDOB ='{dtpDob.Value.Date}'" +
                            $"WHERE (studentID = {cmbStudentID.SelectedValue})";
            dbConnector.Connect();
            dbConnector.DoDML(cmdStr);
            dbConnector.Close();
            reOpenForm1();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you wish to delete this student? {Environment.NewLine}Changes are non-reversible","Warning!",  MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                clsDBConnector dbConnector = new clsDBConnector();
                string cmdStr = "DELETE FROM tblStudent " +
                                    $"WHERE (studentID = {cmbStudentID.SelectedValue})";
                dbConnector.Connect();
                dbConnector.DoDML(cmdStr);
                dbConnector.Close();
                reOpenForm1();
            }
            else
            {
                MessageBox.Show("Changes not updated");
            }
        }
    }
}
