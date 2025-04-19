using TaskManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace TaskManagement
{
    /// <summary>タスク分類テーブルのDAO</summary>
    internal class TaskTagsDao
    {
        /// <summary>タスク分類名取得処理</summary>
        /// <returns>タスク分類エンティティのリスト</returns>
        public List<TaskTagsEntity> GetTaskTagsName()
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // タスク分類エンティティのリスト
            List<TaskTagsEntity> taskTags = new();

            // 実行クエリ
            var commandText = "SELECT tag_no, tag_name FROM task_tags;";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // クエリ実行
                using var reader = command.ExecuteReader();

                // クエリの実行結果を、リストに格納
                while (reader.Read())
                {
                    taskTags.Add(new TaskTagsEntity()
                    {
                        IntTagNo = (int)reader["tag_no"],
                        StrTagName = (String)reader["tag_name"],
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
