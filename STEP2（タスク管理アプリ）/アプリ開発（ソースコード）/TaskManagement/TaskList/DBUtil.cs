using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace WindowsFormsApp1
{
    internal class DBUtil
    {
        private readonly string connectionString = "Server=localhost; Uid=atgs; Pwd=atgs; Database=task_management;";

        public MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
