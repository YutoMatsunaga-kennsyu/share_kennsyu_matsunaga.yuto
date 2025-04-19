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

namespace TaskManagement
{
    /// <summary>ログイン画面クラス</summary>
    public partial class Login : Form
    {
        /// <summary>ログイン画面クラスのコンストラクタ</summary>
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>ログインボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // ユーザー名、またはパスワードが空かNULLの場合
            if ((string.IsNullOrEmpty(userNameTextBox.Text)) || (string.IsNullOrEmpty(passwordTextBox.Text)))
            {
                MessageBox.Show("ユーザー名、またはパスワードが未入力です", "入力値エラー");
                return;
            }

            // ユーザーテーブルのDAO取得
            UsersDao usersDao = new();

            // ログイン認証処理
            if (usersDao.Authenticate(userNameTextBox.Text, passwordTextBox.Text))
            {
                MessageBox.Show("ユーザー名、またはパスワードが間違っています", "ログインエラー");
                return;
            }

            // 一覧画面に遷移
            Program.Display_TaskList(userNameTextBox.Text);

            // ログイン画面を閉じる
            this.Close();
        }
    }
}
