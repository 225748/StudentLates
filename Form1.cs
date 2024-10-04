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

        // Declare a string to hold the entire document contents.
        private string documentContents;
        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;
        private string header; // this will appear at the top of each page


        private void btnPrntMinsLate_Click(object sender, EventArgs e)
        {
            header = string.Format("{0,-11}{1,-20}{2,-20}{3,-5}", "Student ID", "Name", "Date of Birth", "Mins late") + "\n";
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            stringToPrint = GetData();
            documentContents = stringToPrint;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            Font font = new Font("Courier New", 12.0f);
            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);
            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);
            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);
            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
            {
                stringToPrint = documentContents;
            }
            else
            {  // print the header as new page
                stringToPrint = header + stringToPrint;
            }

        }
        private string GetData()
        {
            string dataToPrint = "";
            clsDBConnector dbConnector = new clsDBConnector();
            OleDbDataReader dr;
            string sqlStr;
            DateTime dateofLate;
            dbConnector.Connect();
            sqlStr = " SELECT tblStudent.studentID, (surName & " + "', '" + "& firstname) as studentName, dateOfLate, tblLate.minsLate" +
                        " FROM tblLate INNER JOIN" +
                        " tblStudent ON tblLate.studentID = tblStudent.studentID";
            dr = dbConnector.DoSQL(sqlStr);
            //lstVLates.Items.Clear();
            dataToPrint = header;
            while (dr.Read())
            {
                dateofLate = Convert.ToDateTime(dr[2]);
                dataToPrint = dataToPrint + string.Format("{0,-11}{1,-20}{2,-20}{3,-5}", dr[0].ToString(), dr[1].ToString(), dateofLate.ToShortDateString(), dr[3].ToString()) + "\n";
            }
            dbConnector.Close();
            return dataToPrint;
        }

    }

}
