using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagement;

namespace TaskManagement
{
    /// <summary>詳細画面クラス</summary>
    public partial class TaskDetail : Form
    {

        int gIntLinkTaskNo;
        Boolean prevTaskIsActive;

        /// <summary>詳細画面クラスのコンストラクタ</summary>
        /// <param name="strUserId">ユーザーID</param>
        /// <param name="intLinkTaskNo">一覧画面でタスク名のリンクを押下したタスクのタスク番号</param>
        public TaskDetail(String strUserId, int intLinkTaskNo)
        {
            InitializeComponent();

            gIntLinkTaskNo = intLinkTaskNo;

            // タスク分類テーブルのDAO取得
            TaskTagsDao taskTagsDao = new();

            // タスク分類テーブルの全検索結果をタスク分類エンティティリストに格納
            List<TaskTagsEntity> taskTagsList = taskTagsDao.GetTaskTagsName();

            // タスク分類検索欄にタスク分類テーブルのタスク分類名の値を設定
            foreach (var taskTag in taskTagsList)
            {
                tagComboBox.Items.Add(taskTag.StrTagName);
            }

            // ヘッダーにログインしたユーザーのユーザーIDを設定
            this.userId.Text = strUserId;

            // 一覧画面の新規作成ボタンから詳細画面に遷移時
            if (gIntLinkTaskNo == 0)
            {
                // タイトル、ボタンのテキストをタスク新規作成用に設定
                taskDetailTitle.Text = "タスク登録";
                ConfirmBtn.Text = "登録";

                // タスク完了期限を入力するカレンダーで現在日時より前の日付を選択不可にする
                btnDate.Name = "minDateBtn";

                // タスク分類入力欄のコンボボックスの初期値を「仕事」に設定
                tagComboBox.SelectedIndex = 0;

                // タスク状況検索欄のコンボボックスの初期値を「未完了」、かつ編集不可にする
                activeComboBox.SelectedIndex = 0;
                activeComboBox.Enabled = false;
            }
            // 一覧画面のタスク名のリンクから詳細画面に遷移時
            else
            {
                // タスクテーブルのDAO取得
                TasksDao tasksDao = new();

                // 一覧画面でタスク名のリンクを押下したタスクの情報をタスクエンティティリストに格納
                List<TasksEntity> taskList = tasksDao.GetTaskInformation(gIntLinkTaskNo);

                // タイトル、ボタンのテキストをタスク修正用に設定
                taskDetailTitle.Text = "タスク修正";
                ConfirmBtn.Text = "修正";

                // 各入力欄の初期値に、一覧画面でタスク名のリンクを押下したタスクの情報を設定
                foreach (var task in taskList)
                {
                    txtTaskName.Text = task.StrTaskName;
                    txtDescription.Text = task.StrDescription;
                    tagComboBox.SelectedIndex = task.IntTagNo - 1;
                    txtDueDate.Text = task.DueDate.ToString("yyyy/MM/dd");
                    prevTaskIsActive = task.IsActive;

                    // タスク状況入力欄の初期値をタスク状況がtrueの場合は「未完了」、falseの場合は「完了」にする
                    if (task.IsActive == true)
                    {
                        activeComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        activeComboBox.SelectedIndex = 1;
                    }
                }

            }
        }

        /// <summary>タスク完了期限入力ボタン押下時</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDate_Click(object sender, EventArgs e)
        {
            // カレンダー表示処理
            FormCalendar.inputCalenda(this, txtDueDate, btnDate);
        }

        /// <summary>登録/修正ボタン押下時</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            // タスクテーブルのDAO取得
            TasksDao tasksDao = new();

            // 登録ボタン押下時
            if (ConfirmBtn.Text.Equals("登録"))
            {
                // タスク名、またはタスク完了期限が未入力の場合
                if ((string.IsNullOrEmpty(txtTaskName.Text)) || (string.IsNullOrEmpty(txtDueDate.Text)))
                {
                    MessageBox.Show("タスク名、またはタスク完了期限が未入力です", "入力値エラー");
                    return;
                }

                DialogResult result = MessageBox.Show("入力した内容でタスクを登録しますか？", "タスクの登録", MessageBoxButtons.YesNo);

                // Yesの場合
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // 各入力欄に入力された内容でタスクを新規登録
                    tasksDao.CreateTask(txtTaskName.Text, txtDescription.Text, tagComboBox.SelectedIndex + 1, txtDueDate.Text, this.userId.Text);

                    // 各入力欄を初期化
                    txtTaskName.Text = "";
                    tagComboBox.SelectedIndex = 0;
                    txtDueDate.Text = "";
                    txtDescription.Text = "";
                    activeComboBox.SelectedIndex = 0;
                }
            }
            // 修正ボタン押下時
            else if (ConfirmBtn.Text.Equals("修正"))
            {
                // タスク名が未入力の場合
                if ((string.IsNullOrEmpty(txtTaskName.Text)))
                {
                    MessageBox.Show("タスク名が未入力です", "入力値エラー");
                    return;
                }

                DialogResult result = MessageBox.Show("入力した内容でタスクを修正しますか？", "タスクの修正", MessageBoxButtons.YesNo);

                // Yesの場合
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // 各入力欄に入力された内容でタスクを修正
                    tasksDao.UpdateTask(gIntLinkTaskNo, txtTaskName.Text, txtDescription.Text, tagComboBox.SelectedIndex + 1, txtDueDate.Text, prevTaskIsActive, activeComboBox.Text);

                    // 一覧画面に遷移
                    Program.Display_TaskList(userId.Text);

                    // 詳細画面を閉じる
                    this.Close();
                }
            }
        }

        /// <summary>ログアウトボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // ログイン画面に遷移
            Program.Display_Login();

            // 詳細画面を閉じる
            this.Close();
        }

        /// <summary>戻るリンク押下時</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            // 一覧画面に遷移
            Program.Display_TaskList(userId.Text);

            // 詳細画面を閉じる
            this.Close();
        }
    }
}
