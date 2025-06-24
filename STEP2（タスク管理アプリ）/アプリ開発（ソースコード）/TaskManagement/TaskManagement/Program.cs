using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TaskManagement
{
    /// <summary>タスク管理アプリのメインエントリポイント</summary>
    internal static class Program
    {
        //メインフォーム用の変数
        public static ApplicationContext gMain_form;

        /// <summary>メイン</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            gMain_form = new ApplicationContext();
            gMain_form.MainForm = new Login();
            Application.Run(gMain_form);
        }

        /// <summary>ログイン画面に遷移する処理</summary>
        public static void Display_Login()
        {
            gMain_form.MainForm = new Login();
            gMain_form.MainForm.Show();
        }

        /// <summary>一覧画面に遷移する処理</summary>
        /// <param name="strUserId">ログインしたユーザーのユーザーID</param>
        public static void Display_TaskList(String strUserId)
        {
            gMain_form.MainForm = new TaskList(strUserId, isFromLogin: true);
            gMain_form.MainForm.Show();
        }

        /// <summary>詳細画面に遷移する処理</summary>
        /// <param name="strUserId">ログインしたユーザーのユーザーID</param>
        /// <param name="intLinkTaskNo">一覧画面のタスク名のリンクを押下したタスクのタスク番号</param>
        public static void Display_TaskDetail(String strUserId, int intLinkTaskNo)
        {
            gMain_form.MainForm = new TaskDetail(strUserId, intLinkTaskNo);
            gMain_form.MainForm.Show();
        }
    }
}
