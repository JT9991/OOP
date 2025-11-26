using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace toDoList
{
    internal class dataLayer
    {
        private string connectionString = @"Data Source=D:\C#\AT2\ToDoList\AT2_Part3_DB.db";

        // ================================
        // Get ALL Tasks
        // ================================
        public DataTable GetAllTasks()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Tasks";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }

            return dt;
        }

        // ================================
        // Insert Task
        // ================================
        public void InsertTask(string title, string description, string dueDate, string status)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Tasks (Title, Description, DueDate, Status) 
                                     VALUES (@Title, @Desc, @DueDate, @Status)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Desc", description);
                        cmd.Parameters.AddWithValue("@DueDate", dueDate);
                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert error: " + ex.Message);
            }
        }

        // ================================
        // Update Task
        // ================================
        public void UpdateTask(int id, string title, string description, string dueDate, string status)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE Tasks 
                                     SET Title = @Title,
                                         Description = @Desc,
                                         DueDate = @DueDate,
                                         Status = @Status
                                     WHERE TaskId = @TaskId";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Desc", description);
                        cmd.Parameters.AddWithValue("@DueDate", dueDate);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@TaskId", id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        // ================================
        // Delete Task
        // ================================
        public void DeleteTask(int id)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Tasks WHERE TaskId = @TaskId";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TaskId", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message);
            }
        }
        public void UpdateTask_Disconnected(int id, string title, string description, string dueDate, string status)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // ---------------------------------------------------------
                    // 1. Create the DataAdapter using a SELECT command
                    //    - This retrieves all data from the Tasks table.
                    //    - DataAdapter acts as the "bridge" between DB and DataTable.
                    // ---------------------------------------------------------
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM Tasks", conn);

                    // ---------------------------------------------------------
                    // 2. Create CommandBuilder
                    //    - Generates INSERT, UPDATE, DELETE commands automatically.
                    //    - Required for adapter.Update() to push changes to DB.
                    // ---------------------------------------------------------
                    SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);

                    // ---------------------------------------------------------
                    // 3. Fill a DataTable (DISCONNECTED copy of the database)
                    //    - DataTable now holds all rows from the "Tasks" table
                    //    - After this, the database connection is *not needed*
                    // ---------------------------------------------------------
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // ---------------------------------------------------------
                    // 4. Find the row to update inside the DataTable
                    //    - We search for the row using TaskId
                    //    - Any changes we make here are IN MEMORY ONLY
                    // ---------------------------------------------------------
                    DataRow[] rows = dt.Select("TaskId = " + id);

                    if (rows.Length == 1)
                    {
                        rows[0]["Title"] = title;
                        rows[0]["Description"] = description;
                        rows[0]["DueDate"] = dueDate;
                        rows[0]["Status"] = status;
                    }
                    else
                    {
                        MessageBox.Show("Task not found!");
                        return;
                    }

                    // ---------------------------------------------------------
                    // 5. Update the database using adapter.Update()
                    //    - This pushes all modified rows in the DataTable
                    //      back to the actual SQLite database.
                    //    - THIS is the key step that makes it disconnected mode.
                    // ---------------------------------------------------------
                    adapter.Update(dt);

                    MessageBox.Show("UPDATE successful!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnected update error: " + ex.Message);
            }
        }

    }
}
