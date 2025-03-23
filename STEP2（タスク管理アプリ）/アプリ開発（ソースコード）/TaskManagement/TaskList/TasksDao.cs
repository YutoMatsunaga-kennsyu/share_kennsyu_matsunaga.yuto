using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WindowsFormsApp1
{
    public class TasksDao
    {

        public List<TasksEntity> SelectAll()
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "SELECT * FROM tasks ORDER BY ABS(DATEDIFF(due_date, CURDATE()));";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            // 在庫マスタエンティティのリスト
            List<TasksEntity> taskEntityList = new();

            using var command = new MySqlCommand(commandText, connection);

            // SQLを実行し、結果を取得
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!reader["done_date"].Equals(DBNull.Value)) {
                    taskEntityList.Add(new TasksEntity()
                    {
                        taskName = (string)reader["task_name"],
                        description = (string)reader["description"],
                        tag = (string)reader["tag"],
                        dueDate = (DateTime)reader["due_date"],
                        doneDate = (DateTime)reader["done_date"],
                        updateDate = (DateTime)reader["update_date"],
                        active = (string)reader["active"],
                    });
                }else
                {
                    taskEntityList.Add(new TasksEntity()
                    {
                        taskName = (string)reader["task_name"],
                        description = (string)reader["description"],
                        tag = (string)reader["tag"],
                        dueDate = (DateTime)reader["due_date"],
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

