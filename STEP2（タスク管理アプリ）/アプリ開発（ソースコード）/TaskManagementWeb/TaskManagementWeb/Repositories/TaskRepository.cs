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

		public async Task<List<TaskModel>> GetTasksByConditionsAsync(
	string strTaskName,
	string strTag,
	string strDateFrom,
	string strDateTo,
	string strDateDone,
	string strActive,
	string strUserId)
		{
			var tasks = new List<TaskModel>();

			using var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
			await conn.OpenAsync();

			var sql = @"
        SELECT task_no, task_name, description, tag_name, tasks.tag_no, due_date, done_date, update_date, is_active
        FROM tasks
        INNER JOIN task_tags tags ON tasks.tag_no = tags.tag_no
        WHERE ";

			var conditions = new List<string>();
			var parameters = new List<MySqlParameter>();

			if (!string.IsNullOrEmpty(strTaskName))
			{
				conditions.Add("task_name LIKE @taskName");
				parameters.Add(new MySqlParameter("@taskName", $"%{strTaskName}%"));
			}

			if (!strTag.Equals("全て"))
			{
				conditions.Add("tag_name = @tag");
				parameters.Add(new MySqlParameter("@tag", strTag));
			}

			if (!string.IsNullOrEmpty(strDateFrom) && !string.IsNullOrEmpty(strDateTo))
			{
				conditions.Add("due_date BETWEEN @dateFrom AND @dateTo");
				parameters.Add(new MySqlParameter("@dateFrom", strDateFrom));
				parameters.Add(new MySqlParameter("@dateTo", strDateTo));
			}
			else if (!string.IsNullOrEmpty(strDateFrom))
			{
				conditions.Add("due_date >= @dateFrom");
				parameters.Add(new MySqlParameter("@dateFrom", strDateFrom));
			}
			else if (!string.IsNullOrEmpty(strDateTo))
			{
				conditions.Add("due_date <= @dateTo");
				parameters.Add(new MySqlParameter("@dateTo", strDateTo));
			}

			if (!string.IsNullOrEmpty(strDateDone))
			{
				conditions.Add("DATE_FORMAT(done_date, '%Y/%m/%d') = @dateDone");
				parameters.Add(new MySqlParameter("@dateDone", strDateDone));
			}

			if (!strActive.Equals("全て"))
			{
				int activeValue = strActive switch
				{
					"完了" => 0,
					"着手中" => 1,
					"未着手" => 2,
					_ => -1
				};

				if (activeValue >= 0)
				{
					conditions.Add("is_active = @isActive");
					parameters.Add(new MySqlParameter("@isActive", activeValue));
				}
			}

			conditions.Add("user_id = @userId");
			parameters.Add(new MySqlParameter("@userId", strUserId));

			sql += string.Join(" AND ", conditions);
			sql += " ORDER BY ABS(DATEDIFF(due_date, CURDATE()))";

			using var cmd = new MySqlCommand(sql, conn);
			cmd.Parameters.AddRange(parameters.ToArray());

			using var reader = await cmd.ExecuteReaderAsync();
			while (await reader.ReadAsync())
			{
				tasks.Add(new TaskModel
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
				});
			}

			return tasks;
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
				string sql = @"UPDATE tasks 
               SET done_date = NOW(), 
                   is_active = 0, 
                   update_date = NOW() 
               WHERE task_no = @taskNo";
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

		/// <summary>新規タスクの登録を行う処理（非同期）</summary>
		/// <param name="taskName">タスク名</param>
		/// <param name="description">説明</param>
		/// <param name="tagNo">タスク分類番号</param>
		/// <param name="dueDate">タスク完了期限（文字列で受け取る場合は適宜変換してください）</param>
		/// <param name="userId">ユーザーID</param>
		public async Task CreateTaskAsync(string taskName, string description, int tagNo, string dueDate, string userId)
		{
			var commandText = @"
                INSERT INTO tasks(user_id, task_name, description, tag_no, due_date, update_date, is_active) 
                VALUES (@userId, @taskName, @description, @tagNo, @dueDate, NOW(), 1)";

			using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
			await connection.OpenAsync();

			try
			{
				using var command = new MySqlCommand(commandText, connection);

				command.Parameters.AddWithValue("@userId", userId);
				command.Parameters.AddWithValue("@taskName", taskName);
				command.Parameters.AddWithValue("@description", description);
				command.Parameters.AddWithValue("@tagNo", tagNo);

				// dueDateはstring型なので、MySQLのDATETIMEに合う形に変換推奨
				// ここではstringのまま渡していますが、DateTime型で受け取る方が良いです
				command.Parameters.AddWithValue("@dueDate", dueDate);

				await command.ExecuteNonQueryAsync();
			}
			catch (Exception ex)
			{
				// 例外は必要に応じてログ出力や再スローしてください
				throw;
			}
			finally
			{
				await connection.CloseAsync();
			}
		}
	}
}
