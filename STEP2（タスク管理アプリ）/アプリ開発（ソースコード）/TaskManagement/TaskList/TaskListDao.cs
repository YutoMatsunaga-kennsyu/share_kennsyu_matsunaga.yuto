using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WindowsFormsApp1
{
    public class TaskListDao
    {
        private readonly string connectionString = "Server=localhost; Uid=atgs; Pwd=atgs; Database=task_management;";

        private MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<TaskListEntity> SelectAll()
        {
            // 実行SQL
            var commandText = "SELECT * FROM task_list";

            // MySQLへの接続
            using var connection = GetMySqlConnection();

            // 接続確立
            connection.Open();

            // 在庫マスタエンティティのリスト
            List<TaskListEntity> taskEntityList = new();

            using var command = new MySqlCommand(commandText, connection);

            // SQLを実行し、結果を取得
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!reader["done_date"].Equals(DBNull.Value)) {
                    taskEntityList.Add(new TaskListEntity()
                    {
                        taskName = (string)reader["task_name"],
                        description = (string)reader["description"],
                        dueDate = (DateTime)reader["due_date"],
                        tag = (string)reader["tag"],
                        doneDate = (DateTime)reader["done_date"],
                        updateDate = (DateTime)reader["update_date"],
                        active = (string)reader["active"],
                    });
                }else
                {
                    taskEntityList.Add(new TaskListEntity()
                    {
                        taskName = (string)reader["task_name"],
                        description = (string)reader["description"],
                        dueDate = (DateTime)reader["due_date"],
                        tag = (string)reader["tag"],
                        doneDate = null,
                        updateDate = (DateTime)reader["update_date"],
                        active = (string)reader["active"],
                    });
                }
            }

            // 在庫マスタエンティティのリスト
            return taskEntityList;
            }
        }
    }

