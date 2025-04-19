using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Specialized;

namespace TaskManagement
{
    /// <summary>ユーザーテーブルのDAO</summary>
    internal class UsersDao
    {
        /// <summary>ログイン認証処理</summary>
        /// <param name="strUserId"></param>
        /// <param name="strPassword"></param>
        /// <returns>ログイン認証結果</returns>
        public Boolean Authenticate(String strUserId, String strPassword)
        {
            // DB接続クラスのインスタンス作成
            DBUtil dbUtil = new();

            // ユーザーエンティティのリスト
            List<UsersEntity> users = new();

            // 実行クエリ
            var commandText = "SELECT * FROM users WHERE user_id = @userId AND password = @password;";

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            try
            {
                using var command = new MySqlCommand(commandText, connection);

                // パラメータの設定
                command.Parameters.AddWithValue("@userId", strUserId);
                command.Parameters.AddWithValue("@password", strPassword);

                // クエリ実行
                using var reader = command.ExecuteReader();

                // クエリの実行結果を、リストに格納
                while (reader.Read())
                {
                    users.Add(new UsersEntity()
                    {
                        StrUserId = (String)reader["user_id"],
                        StrUserName = (String)reader["user_name"],
                        StrPassword = (String)reader["password"],
                    });
                }

                // リストが空かNULLの場合は、falseを返す
                if (users?.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                //コネクション終了
                connection.Close();
            }
        }
    }
}
