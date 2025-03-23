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
            if ((string.IsNullOrEmpty(textBoxEx1.Text)) || (string.IsNullOrEmpty(textBoxEx2.Text)))
            {
                MessageBox.Show("ユーザー名、またはパスワードが未入力です","入力値エラー");
                MessageBox.Show("ユーザー名、またはパスワードが間違っています", "ログインエラー");
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
