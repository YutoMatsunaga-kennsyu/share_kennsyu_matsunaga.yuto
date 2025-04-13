using TaskManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace TaskManagement
{
    internal class TaskTagsDao
    {
        public String getTaskTagsName(int tagNo)
        {
            DBUtil dbUtil = new DBUtil();

            String taskTagsName;

            // 実行SQL
            var commandText = "SELECT tag_name FROM task_tags WHERE "+ tagNo +";";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            using var command = new MySqlCommand(commandText, connection);

            using var reader = command.ExecuteReader();

            // ユーザーエンティティのリスト
            List<TaskTagsEntity> taskTags = new();

            while (reader.Read())
            {
                taskTags.Add(new TaskTagsEntity()
                {
                    tagNo = (int)reader["tag_no"],
                    tagName = (string)reader["tag_name"],
                });
            }
            return "a";
        }
    }
}
