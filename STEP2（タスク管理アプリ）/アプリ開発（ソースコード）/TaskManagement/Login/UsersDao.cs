using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    internal class UsersDao
    {
        public Boolean Authenticate(String userName, String passWord)
        {

            var commandText = "SELECT * FROM users where ;";
            return true;

        }
    }
}