namespace toDoList
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.IDC_title = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDC_btnAdd = new System.Windows.Forms.Button();
            this.IDC_btnUpdate = new System.Windows.Forms.Button();
            this.IDC_btnDelete = new System.Windows.Forms.Button();
            this.IDC_btnViewAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IDC_btnDescription = new System.Windows.Forms.RichTextBox();
            this.IDC_btnImport = new System.Windows.Forms.Button();
            this.IDC_btnExport = new System.Windows.Forms.Button();
            this.IDC_btnViewRecord = new System.Windows.Forms.Button();
            this.label5_title = new System.Windows.Forms.Label();
            this.IDC_btnComplete = new System.Windows.Forms.Button();
            this.IDC_dueDate = new System.Windows.Forms.DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(270, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 312);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // label1 (Title)
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.Text = "Title";

            // IDC_title
            this.IDC_title.Location = new System.Drawing.Point(270, 78);
            this.IDC_title.Name = "IDC_title";
            this.IDC_title.Size = new System.Drawing.Size(454, 23);

            // label2 (Description)
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 106);
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.Text = "Description";

            // IDC_btnAdd
            this.IDC_btnAdd.Location = new System.Drawing.Point(750, 151);
            this.IDC_btnAdd.Size = new System.Drawing.Size(162, 23);
            this.IDC_btnAdd.Text = "Add";
            this.IDC_btnAdd.Click +=
                new System.EventHandler(this.IDC_btnAdd_Click);

            // IDC_btnUpdate
            this.IDC_btnUpdate.Location = new System.Drawing.Point(750, 180);
            this.IDC_btnUpdate.Size = new System.Drawing.Size(162, 23);
            this.IDC_btnUpdate.Text = "Update";
            this.IDC_btnUpdate.Click +=
                new System.EventHandler(this.IDC_btnUpdate_Click);

            // IDC_btnDelete
            this.IDC_btnDelete.Location = new System.Drawing.Point(837, 542);
            this.IDC_btnDelete.Size = new System.Drawing.Size(75, 23);
            this.IDC_btnDelete.Text = "Delete";
            this.IDC_btnDelete.Click +=
                new System.EventHandler(this.IDC_btnDelete_Click);

            // IDC_btnViewAll
            this.IDC_btnViewAll.Location = new System.Drawing.Point(270, 542);
            this.IDC_btnViewAll.Size = new System.Drawing.Size(75, 23);
            this.IDC_btnViewAll.Text = "View All";
            this.IDC_btnViewAll.Click +=
                new System.EventHandler(this.IDC_btnViewAll_Click);

            // label3 (Due Date)
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(749, 60);
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.Text = "Due Date";

            // IDC_dueDate
            this.IDC_dueDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.IDC_dueDate.Location = new System.Drawing.Point(751, 78);
            this.IDC_dueDate.Name = "IDC_dueDate";
            this.IDC_dueDate.Size = new System.Drawing.Size(161, 23);
            this.IDC_dueDate.ValueChanged +=
                new System.EventHandler(this.IDC_dueDate_ValueChanged);
            this.IDC_dueDate.Enter +=
                new System.EventHandler(this.IDC_dueDate_Enter);

            // comboBox1 (Status)
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(751, 122);
            this.comboBox1.Size = new System.Drawing.Size(161, 23);
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DrawItem +=
                new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);

            // label4 (Status)
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(748, 105);
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.Text = "Status";

            // IDC_btnDescription
            this.IDC_btnDescription.Location = new System.Drawing.Point(270, 123);
            this.IDC_btnDescription.Size = new System.Drawing.Size(454, 95);

            // IDC_btnImport
            this.IDC_btnImport.Location = new System.Drawing.Point(687, 543);
            this.IDC_btnImport.Size = new System.Drawing.Size(75, 23);
            this.IDC_btnImport.Text = "Import";
            this.IDC_btnImport.Click +=
                new System.EventHandler(this.IDC_btnImport_Click);

            // IDC_btnExport
            this.IDC_btnExport.Location = new System.Drawing.Point(762, 542);
            this.IDC_btnExport.Size = new System.Drawing.Size(75, 23);
            this.IDC_btnExport.Text = "Export";
            this.IDC_btnExport.Click +=
                new System.EventHandler(this.IDC_btnExport_Click);

            // IDC_btnViewRecord
            this.IDC_btnViewRecord.Location = new System.Drawing.Point(351, 542);
            this.IDC_btnViewRecord.Size = new System.Drawing.Size(104, 23);
            this.IDC_btnViewRecord.Text = "View Record";
            this.IDC_btnViewRecord.Click +=
                new System.EventHandler(this.IDC_btnViewRecord_Click);

            // label5_title
            this.label5_title.AutoSize = true;
            this.label5_title.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.label5_title.Location = new System.Drawing.Point(264, 9);
            this.label5_title.Size = new System.Drawing.Size(187, 47);
            this.label5_title.Text = "To-Do List";

            // IDC_btnComplete
            this.IDC_btnComplete.Location = new System.Drawing.Point(462, 541);
            this.IDC_btnComplete.Size = new System.Drawing.Size(108, 23);
            this.IDC_btnComplete.Text = "Mark Complete";
            this.IDC_btnComplete.Click +=
                new System.EventHandler(this.IDC_btnComplete_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(1199, 606);
            this.Controls.Add(this.IDC_dueDate);
            this.Controls.Add(this.IDC_btnComplete);
            this.Controls.Add(this.label5_title);
            this.Controls.Add(this.IDC_btnViewRecord);
            this.Controls.Add(this.IDC_btnExport);
            this.Controls.Add(this.IDC_btnImport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.IDC_btnDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IDC_btnViewAll);
            this.Controls.Add(this.IDC_btnDelete);
            this.Controls.Add(this.IDC_btnUpdate);
            this.Controls.Add(this.IDC_btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IDC_title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "To-Do List";
            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDC_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button IDC_btnAdd;
        private System.Windows.Forms.Button IDC_btnUpdate;
        private System.Windows.Forms.Button IDC_btnDelete;
        private System.Windows.Forms.Button IDC_btnViewAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker IDC_dueDate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox IDC_btnDescription;
        private System.Windows.Forms.Button IDC_btnImport;
        private System.Windows.Forms.Button IDC_btnExport;
        private System.Windows.Forms.Button IDC_btnViewRecord;
        private System.Windows.Forms.Label label5_title;
        private System.Windows.Forms.Button IDC_btnComplete;
    }
}
