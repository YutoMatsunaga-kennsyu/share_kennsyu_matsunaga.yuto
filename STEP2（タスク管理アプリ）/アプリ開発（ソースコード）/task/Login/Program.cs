using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TaskManagement
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        
        public static ApplicationContext main_form;   //1,メインフォーム用の変数

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login()); コメントアウト
            main_form = new ApplicationContext();
            main_form.MainForm = new Login();
            Application.Run(main_form);
        }

        //4,Form1に切り替える処理
        public static void Display_Login()
        {
            main_form.MainForm = new Login();
            main_form.MainForm.Show();
        }

        //5,Form1に切り替える処理
        public static void Display_TaskList(String userId)
        {
            main_form.MainForm = new TaskList(userId);
            main_form.MainForm.Show();
        }

        //5,Form1に切り替える処理
        public static void Display_TaskDetail(String userId, int linkTaskNo)
        {
            main_form.MainForm = new TaskDetail(userId, linkTaskNo);
            main_form.MainForm.Show();
        }
    }
}
