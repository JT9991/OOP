using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace toDoList
{
    public partial class Form1 : Form
    {
        dataLayer dl = new dataLayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate status dropdown
            comboBox1.Items.Clear();
            comboBox1.Items.Add("-- Select One --");
            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("In Progress");
            comboBox1.Items.Add("Completed");

            comboBox1.SelectedIndex = 0; // default

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadTasksIntoGrid();
        }

        private void LoadTasksIntoGrid()
        {
            dataGridView1.DataSource = dl.GetAllTasks();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            IDC_title.Text = row.Cells["Title"].Value?.ToString();
            IDC_btnDescription.Text = row.Cells["Description"].Value?.ToString();
            comboBox1.Text = row.Cells["Status"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["DueDate"].Value?.ToString(), out DateTime due))
            {
                IDC_dueDate.Value = due;
            }
        }

        private void IDC_btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a valid status.", "Error");
                return;
            }

            dl.InsertTask(
                IDC_title.Text,
                IDC_btnDescription.Text,
                IDC_dueDate.Value.ToShortDateString(),
                comboBox1.Text
            );

            MessageBox.Show("Task added successfully.");
            LoadTasksIntoGrid();
        }

        private void IDC_btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a task to update.");
                return;
            }

            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a valid status.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TaskId"].Value);

            dl.UpdateTask_Disconnected(
                id,
                IDC_title.Text,
                IDC_btnDescription.Text,
                IDC_dueDate.Value.ToShortDateString(),
                comboBox1.Text
            );

            MessageBox.Show("Task updated successfully.");
            LoadTasksIntoGrid();
        }

        private void IDC_btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a task to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this task?",
                "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TaskId"].Value);

            dl.DeleteTask(id);

            MessageBox.Show("Task deleted.");
            LoadTasksIntoGrid();
        }

        private void IDC_btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV Files (*.csv)|*.csv";

            if (open.ShowDialog() != DialogResult.OK) return;

            try
            {
                string[] lines = File.ReadAllLines(open.FileName);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');

                    if (values.Length >= 5)
                    {
                        dl.InsertTask(values[1], values[2], values[3], values[4]);
                    }
                }

                MessageBox.Show("Import successful.");
                LoadTasksIntoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import error: " + ex.Message);
            }
        }

        private void IDC_btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "CSV Files (*.csv)|*.csv";
            save.FileName = "TasksExport.csv";

            if (save.ShowDialog() != DialogResult.OK) return;

            try
            {
                DataTable dt = dl.GetAllTasks();
                var lines = dt.Columns.Cast<DataColumn>()
                    .Select(col => col.ColumnName)
                    .ToList();

                var output = new System.Collections.Generic.List<string>();
                output.Add(string.Join(",", lines));

                foreach (DataRow row in dt.Rows)
                {
                    string[] fields = row.ItemArray.Select(f => f.ToString()).ToArray();
                    output.Add(string.Join(",", fields));
                }

                File.WriteAllLines(save.FileName, output);
                MessageBox.Show("Export successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export error: " + ex.Message);
            }
        }

        private void IDC_btnViewAll_Click(object sender, EventArgs e)
        {
            LoadTasksIntoGrid();
            ClearFields();
            MessageBox.Show("All records refreshed.");
        }

        private void ClearFields()
        {
            IDC_title.Clear();
            IDC_btnDescription.Clear();
            IDC_dueDate.Value = DateTime.Now;
            comboBox1.SelectedIndex = 0;
        }

        private void IDC_btnViewRecord_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a task to view.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];

            MessageBox.Show(
                $"📌 Task Details\n\n" +
                $"Title: {row.Cells["Title"].Value}\n" +
                $"Description: {row.Cells["Description"].Value}\n" +
                $"Due Date: {row.Cells["DueDate"].Value}\n" +
                $"Status: {row.Cells["Status"].Value}",
                "Task Record");
        }

        private void IDC_btnComplete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a task to mark complete.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TaskId"].Value);

            if (MessageBox.Show("Mark this task as Completed?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            dl.UpdateTask(
                id,
                dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["Description"].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells["DueDate"].Value.ToString(),
                "Completed"
            );

            MessageBox.Show("Task marked as completed.");
            LoadTasksIntoGrid();
        }

        private void IDC_dueDate_ValueChanged(object sender, EventArgs e)
        {
            // No logic required (kept for Designer compatibility)
        }

        private void IDC_dueDate_Enter(object sender, EventArgs e)
        {
            // Removes the highlight on enter
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Not required
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cb = (ComboBox)sender;
            e.DrawBackground();

            string text = cb.Items[e.Index].ToString();

            TextRenderer.DrawText(
                e.Graphics,
                text,
                cb.Font,
                e.Bounds,
                cb.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            e.DrawFocusRectangle();
        }
    }
}
