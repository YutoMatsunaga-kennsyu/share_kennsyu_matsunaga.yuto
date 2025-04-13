using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(userNameTextBox.Text)) || (string.IsNullOrEmpty(passwordTextBox.Text)))
            {
                MessageBox.Show("ユーザー名、またはパスワードが未入力です", "入力値エラー");
                return;
            }

            UsersDao usersDao = new UsersDao();

            if (usersDao.Authenticate(userNameTextBox.Text, passwordTextBox.Text))
            {
                MessageBox.Show("ユーザー名、またはパスワードが間違っています", "ログインエラー");
                return;
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
