using TaskManagementWeb.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace TaskManagementWeb.Repositories
{
    public class TaskRepository
    {
        private readonly IConfiguration _config;

        public TaskRepository(IConfiguration config)
        {
            _config = config;
        }

        public List<TaskModel> GetTasksByUserId(string userId)
        {
            var tasks = new List<TaskModel>();

            using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            conn.Open();

            using var cmd = new MySqlCommand("SELECT * FROM tasks WHERE user_id = @userId", conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tasks.Add(new TaskModel
                {
                    TaskNo = Convert.ToInt32(reader["task_no"]),
                    TaskName = reader["task_name"].ToString(),
                    Description = reader["description"].ToString(),
                    TagNo = Convert.ToInt32(reader["tag_no"]),
                    DueDate = reader["due_date"] as DateTime?,
                    DoneDate = reader["done_date"] as DateTime?,
                    UpdateDate = reader["update_date"] as DateTime?,
                    IsActive = Convert.ToInt32(reader["is_active"]),
                    IsChecked = false
                });
            }

            return tasks;
        }

		public async Task<TaskModel?> LoadTaskByIdAsync(int taskNo)
		{
			TaskModel? task = null;

			using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
			await conn.OpenAsync();

			using var cmd = new MySqlCommand("SELECT * FROM tasks WHERE task_no = @taskNo", conn);
			cmd.Parameters.AddWithValue("@taskNo", taskNo);

			using var reader = await cmd.ExecuteReaderAsync();
			if (await reader.ReadAsync())
			{
				task = new TaskModel
				{
					TaskNo = Convert.ToInt32(reader["task_no"]),
					TaskName = reader["task_name"].ToString() ?? string.Empty,
					Description = reader["description"].ToString() ?? string.Empty,
					TagNo = Convert.ToInt32(reader["tag_no"]),
					DueDate = reader["due_date"] as DateTime?,
					DoneDate = reader["done_date"] as DateTime?,
					UpdateDate = reader["update_date"] as DateTime?,
					IsActive = Convert.ToInt32(reader["is_active"]),
					IsChecked = false
				};
			}

			return task;
		}



		public async Task UpdateTaskAsync(TaskModel task)
        {
            using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            await conn.OpenAsync();

            string sql = @"UPDATE tasks 
                           SET task_name = @taskName, 
                               description = @description, 
                               due_date = @dueDate,
                               tag_no = @tagNo,
                               done_date = @doneDate,
                               update_date = NOW(),
                               is_active = @isActive
                           WHERE task_no = @taskNo";

            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@taskName", task.TaskName);
            cmd.Parameters.AddWithValue("@description", task.Description);
            cmd.Parameters.AddWithValue("@dueDate", task.DueDate ?? (object)DBNull.Value);
			cmd.Parameters.AddWithValue("@tagNo", task.TagNo);
			cmd.Parameters.AddWithValue("@taskNo", task.TaskNo);
			cmd.Parameters.AddWithValue("@doneDate", task.DoneDate);
			cmd.Parameters.AddWithValue("@isActive", task.IsActive);
			await cmd.ExecuteNonQueryAsync();
        }

        public void CompleteTasks(List<TaskModel> tasks)
        {
            using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
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
            using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
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
