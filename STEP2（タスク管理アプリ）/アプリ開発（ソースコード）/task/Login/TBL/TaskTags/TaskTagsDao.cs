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
        public List<TaskTagsEntity> getTaskTagsName()
        {
            DBUtil dbUtil = new DBUtil();

            List<TaskTagsEntity> taskTags = new();

            // 実行SQL
            var commandText = "SELECT tag_no, tag_name FROM task_tags;";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                using var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    taskTags.Add(new TaskTagsEntity()
                    {
                        tagNo = (int)reader["tag_no"],
                        tagName = (String)reader["tag_name"],
                    });
                }
                return taskTags;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }


    }
}
