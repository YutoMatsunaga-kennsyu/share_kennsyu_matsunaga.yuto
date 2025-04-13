using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Login;

namespace TaskList
{
    public class TasksDao
    {

        public List<TasksEntity> SelectAll()
        {
            DBUtil dbUtil = new DBUtil();

            // 実行SQL
            var commandText = "SELECT task_name, description, tag_name, due_date, done_date, update_date, is_active FROM tasks tasks INNER JOIN task_tags tags on tasks.tag_no = tags.tag_no ORDER BY ABS(DATEDIFF(due_date, CURDATE()));";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            // 在庫マスタエンティティのリスト
            List<TasksEntity> tasksEntityList = new();

            using var command = new MySqlCommand(commandText, connection);

            // SQLを実行し、結果を取得
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (!reader["done_date"].Equals(DBNull.Value))
                {
                    tasksEntityList.Add(new TasksEntity()
                    {
                        taskName = (string)reader["task_name"],
                        description = (string)reader["description"],
                        tagName = (string)reader["tag_name"],
                        dueDate = (DateTime)reader["due_date"],
                        doneDate = (DateTime)reader["done_date"],
                        updateDate = (DateTime)reader["update_date"],
                        isActive = (Boolean)reader["is_active"],
                    });
                }
                else
                {
                    tasksEntityList.Add(new TasksEntity()
                    {
                        taskName = (string)reader["task_name"],
                        description = (string)reader["description"],
                        tagName = (string)reader["tag_name"],
                        dueDate = (DateTime)reader["due_date"],
                        doneDate = null,
                        updateDate = (DateTime)reader["update_date"],
                        isActive = (Boolean)reader["is_active"],
                    });
                }
            }

            // 在庫マスタエンティティのリスト
            return tasksEntityList;
        }
    }
}

