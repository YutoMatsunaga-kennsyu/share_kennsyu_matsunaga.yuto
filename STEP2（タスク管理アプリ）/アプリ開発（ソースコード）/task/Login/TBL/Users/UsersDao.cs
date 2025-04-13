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
    internal class UsersDao
    {
        public Boolean Authenticate(String userName, String passWord)
        {
            DBUtil dbUtil = new DBUtil();

            // MySQLへの接続
            using var connection = dbUtil.GetMySqlConnection();

            // 接続確立
            connection.Open();

            var commandText = "SELECT * FROM users WHERE user_name = '" + userName + "' AND password = '" + passWord + "';";

            // ユーザーエンティティのリスト
            List<UsersEntity> users = new();

            try
            {
                using var command = new MySqlCommand(commandText, connection);
                // SQLを実行し、結果を取得
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new UsersEntity()
                    {
                        userNo = (int)reader["user_no"],
                        userName = (string)reader["user_name"],
                        password = (string)reader["password"],
                    });
                }

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
