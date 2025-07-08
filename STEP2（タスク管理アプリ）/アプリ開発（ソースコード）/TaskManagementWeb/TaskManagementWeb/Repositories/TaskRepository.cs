using WebTaskManagement.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebTaskManagement.Repositories
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<TaskModel> GetTasks(string userId)
        {
            var list = new List<TaskModel>();

            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            string sql = "SELECT task_no, task_name, description, tag_no, due_date, done_date, update_date, is_active FROM tasks WHERE user_id = @userId ORDER BY task_no";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new TaskModel
                {
                    TaskNo = Convert.ToInt32(reader["task_no"]),
                    TaskName = reader["task_name"].ToString(),
                    Description = reader["description"].ToString(),
                    TagName = reader["tag_no"].ToString(),
                    DueDate = reader["due_date"] == DBNull.Value ? null : (DateTime?)reader["due_date"],
                    DoneDate = reader["done_date"] == DBNull.Value ? null : (DateTime?)reader["done_date"],
                    UpdateDate = reader["update_date"] == DBNull.Value ? null : (DateTime?)reader["update_date"],
                    IsActive = Convert.ToBoolean(reader["is_active"]),
                    IsChecked = false,
                });
            }
            return list;
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            string sql = @"UPDATE tasks 
                           SET task_name = @taskName, 
                               description = @description, 
                               due_date = @dueDate,
                               update_date = NOW()
                           WHERE task_no = @taskNo";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@taskName", task.TaskName);
            cmd.Parameters.AddWithValue("@description", task.Description);
            cmd.Parameters.AddWithValue("@dueDate", task.DueDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@taskNo", task.TaskNo);

            await cmd.ExecuteNonQueryAsync();
        }

        public void CompleteTasks(List<TaskModel> tasks)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            foreach (var task in tasks)
            {
                string sql = @"UPDATE tasks SET done_date = NOW(), is_active = 0 WHERE task_no = @taskNo";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@taskNo", task.TaskNo);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTasks(List<TaskModel> tasks)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            foreach (var task in tasks)
            {
                string sql = @"DELETE FROM tasks WHERE task_no = @taskNo";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@taskNo", task.TaskNo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
