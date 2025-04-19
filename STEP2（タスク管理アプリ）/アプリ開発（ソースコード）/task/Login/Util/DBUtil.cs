using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace TaskManagement
{
    ///<summary>DB接続クラス</summary>
    public class DBUtil
    {
        //DB接続文字列
        private readonly String connectionString = "Server=localhost; Uid=root; Pwd=atgs; Database=task_management; Allow User Variables=true;";

        /// <summary>MySQLへの接続</summary>
        /// <returns>connection MySQL</returns>
        public MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}