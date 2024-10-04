namespace StudentLates
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstVStudents = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenStudentForm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLatesV2 = new System.Windows.Forms.Button();
            this.btnLateAdvanced = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstVStudents
            // 
            this.lstVStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstVStudents.FullRowSelect = true;
            this.lstVStudents.HideSelection = false;
            this.lstVStudents.Location = new System.Drawing.Point(46, 64);
            this.lstVStudents.Name = "lstVStudents";
            this.lstVStudents.Size = new System.Drawing.Size(482, 206);
            this.lstVStudents.TabIndex = 0;
            this.lstVStudents.UseCompatibleStateImageBehavior = false;
            this.lstVStudents.View = System.Windows.Forms.View.Details;
            this.lstVStudents.SelectedIndexChanged += new System.EventHandler(this.lstVStudents_SelectedIndexChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Student ID";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "First Name";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "surName";
            this.columnHeader3.Width = 138;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "DOB";
            this.columnHeader4.Width = 153;
            // 
            // btnOpenStudentForm
            // 
            this.btnOpenStudentForm.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOpenStudentForm.Location = new System.Drawing.Point(46, 296);
            this.btnOpenStudentForm.Name = "btnOpenStudentForm";
            this.btnOpenStudentForm.Size = new System.Drawing.Size(148, 62);
            this.btnOpenStudentForm.TabIndex = 1;
            this.btnOpenStudentForm.Text = "Add / Update a Student";
            this.btnOpenStudentForm.UseVisualStyleBackColor = true;
            this.btnOpenStudentForm.Click += new System.EventHandler(this.btnOpenStudentForm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 62);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Lates Basic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLatesV2
            // 
            this.btnLatesV2.Location = new System.Drawing.Point(291, 296);
            this.btnLatesV2.Name = "btnLatesV2";
            this.btnLatesV2.Size = new System.Drawing.Size(85, 62);
            this.btnLatesV2.TabIndex = 3;
            this.btnLatesV2.Text = "Add Lates V2";
            this.btnLatesV2.UseVisualStyleBackColor = true;
            this.btnLatesV2.Click += new System.EventHandler(this.btnLatesV2_Click);
            // 
            // btnLateAdvanced
            // 
            this.btnLateAdvanced.Location = new System.Drawing.Point(382, 296);
            this.btnLateAdvanced.Name = "btnLateAdvanced";
            this.btnLateAdvanced.Size = new System.Drawing.Size(85, 62);
            this.btnLateAdvanced.TabIndex = 4;
            this.btnLateAdvanced.Text = "Add Lates Advanced";
            this.btnLateAdvanced.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLateAdvanced);
            this.Controls.Add(this.btnLatesV2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOpenStudentForm);
            this.Controls.Add(this.lstVStudents);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstVStudents;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnOpenStudentForm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLatesV2;
        private System.Windows.Forms.Button btnLateAdvanced;
    }
}

