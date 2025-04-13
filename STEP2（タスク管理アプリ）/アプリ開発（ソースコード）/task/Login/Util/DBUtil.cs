using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace TaskManagement
{
    public class DBUtil
    {
        private readonly string connectionString = "Server=localhost; Uid=root; Pwd=atgs; Database=task_management; Allow User Variables=true;";

        public MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}