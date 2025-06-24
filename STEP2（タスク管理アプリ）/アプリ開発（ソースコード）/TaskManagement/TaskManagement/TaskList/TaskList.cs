using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using static System.Net.Mime.MediaTypeNames;
using TaskManagement;
using System.Diagnostics;
using System.Collections.Specialized;

namespace TaskManagement
{
    /// <summary>一覧画面クラス</summary>
    public partial class TaskList : Form
    {
        // チェックボックスの選択状態保存用
        private Dictionary<int, bool> taskCheckStates = new();

        // ログイン画面から遷移したかどうか
        private bool _isFromLogin;

        // 一覧画面のタスク一覧のデータを格納する変数
        public DataTable tasksDataTable = new();
        public BindingSource tasksBindingSource = new();
        public BindingList<DataTable> tasksBindingList = new();

        // タスク一覧の1ページで表示する行数
        public int pageSize = 5;

        /// <summary>一覧画面クラスのコンストラクタ</summary>
        /// <param name="strUserId">ユーザーID</param>
        public TaskList(String strUserId, bool isFromLogin = false)
        {
            _isFromLogin = isFromLogin;

            InitializeComponent();

            // タスク分類テーブルのDAO取得
            TaskTagsDao taskTagsDao = new();

            // タスク分類テーブルの全検索結果をタスク分類エンティティリストに格納
            List<TaskTagsEntity> taskTagsList = taskTagsDao.GetTaskTagsName();

            // タスク分類検索欄にタスク分類テーブルのタスク分類名の値を設定
            foreach (var taskTag in taskTagsList)
            {
                tagComboBox.Items.Add(taskTag.StrTagName);
            }

            // タスク分類検索欄のコンボボックスの初期値を「全て」に設定
            tagComboBox.SelectedIndex = 0;

            // タスク状況検索欄のコンボボックスの初期値を「未完了」に設定
            activeComboBox.SelectedIndex = 1;

            // ヘッダーにログインしたユーザーのユーザーIDを設定
            userId.Text = strUserId;

            // タスク一覧の列の自動生成を行なわないよう設定
            TaskInformation.AutoGenerateColumns = false;

            // タスクテーブルのDAO取得
            TasksDao tasksDao = new();

            // タスクテーブルの全抽出
            var taskList = tasksDao.SelectAll(strUserId);

            // データテーブルにカラムを追加
            this.tasksDataTable.Columns.Add("TaskNo", typeof(int));
            this.tasksDataTable.Columns.Add("TaskName", typeof(string));
            this.tasksDataTable.Columns.Add("Description", typeof(string));
            this.tasksDataTable.Columns.Add("Tag", typeof(string));
            this.tasksDataTable.Columns.Add("DueDate", typeof(DateTime));
            this.tasksDataTable.Columns.Add("IsDone", typeof(DateTime));
            this.tasksDataTable.Columns.Add("Updated On", typeof(DateTime));
            this.tasksDataTable.Columns.Add("IsActive", typeof(string));
            this.tasksDataTable.Columns.Add("IsCheck", typeof(bool));

            // タスク一覧に全抽出した結果を格納
            SetData(taskList, _isFromLogin);
        }

        /// <summary>タスク一覧に引数のタスクエンティティリストの値を格納する処理</summary>
        /// <param name="tasklist">タスクエンティティのリスト</param>
        private void SetData(List<TasksEntity> tasklist, bool isFromLogin)
        {
            _isFromLogin = isFromLogin;

            // 空のデータテーブルを初期化
            DataTable newDataTable = null;

            // タスク一覧のデータソース、データテーブルを初期化
            TaskInformation.DataSource = newDataTable;
            tasksDataTable.Clear();

            // 引数のタスクエンティティリストが空かNULLでない場合
            if (tasklist?.Count > 0)
            {
                foreach (var task in tasklist)
                {
                    String active;

                    // タスク状況がtrueの場合 
                    if (task.IsActive == true)
                    {
                        active = "未完了";
                    }
                    else
                    {
                        active = "完了";
                    }

                    bool isChecked = taskCheckStates.ContainsKey(task.IntTaskNo) ? taskCheckStates[task.IntTaskNo] : false;

                    // データテーブルに引数のタスクエンティティリストの値を格納
                    tasksDataTable.Rows.Add(
                        task.IntTaskNo,
                        task.StrTaskName,
                        task.StrDescription,
                        task.StrTagName,
                        task.DueDate,
                        task.DoneDate,
                        task.UpdateDate,
                        active,
                        isChecked
                    );
                }
            }
            else
            {
                if (_isFromLogin == false)
                {
                    MessageBox.Show("検索条件に一致するタスクはありませんでした", "検索結果");
                }
                else
                {
                    //ログイン画面、タスク詳細画面から一覧画面に遷移した場合の処理を記載
                }
               
            }

            // タスク一覧のページング、バインド
            SetPagedDataSource();
        }

        /// <summary>タスク一覧のページング、バインド処理</summary>
        private void SetPagedDataSource()
        {
            SaveCheckStates();

            // バインディングリストを初期化
            tasksBindingList.Clear();

            // タスク一覧のページング処理に使用する変数を初期化
            DataTable dateTable = null;
            int intCounter = 1;

            // 1ぺージに5レコードずつ表示されるようにページング
            foreach (DataRow dataRow in this.tasksDataTable.Rows)
            {
                if (intCounter == 1)
                {
                    dateTable = tasksDataTable.Clone();
                    tasksBindingList.Add(dateTable);
                }

                dateTable.Rows.Add(dataRow.ItemArray);

                if (pageSize < ++intCounter)
                {
                    intCounter = 1;
                }
            }

            // ページング済みのデータをバインドする
            this.tasksBindingNavigator.BindingSource = tasksBindingSource;
            tasksBindingSource.DataSource = tasksBindingList;
            tasksBindingSource.PositionChanged -= BindingSource_PositionChanged;
            tasksBindingSource.PositionChanged += BindingSource_PositionChanged;
            BindingSource_PositionChanged(tasksBindingSource, EventArgs.Empty);
        }

        /// <summary>タスク一覧のページ切り替え処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            SaveCheckStates();

            // バインディングリストが空かNULLでない場合
            if (tasksBindingList?.Count > 0)
            {
                this.TaskInformation.DataSource = tasksBindingList[tasksBindingSource.Position];
                RestoreCheckStates();


                if (TaskInformation.Columns.Contains("TaskNo"))
                {
                    TaskInformation.Columns["TaskNo"].Visible = false;
                }
            }
        }

        /// <summary>タスクのチェックボックスの選択状態を保存する処理</summary>
        private void SaveCheckStates()
        {
            taskCheckStates.Clear();

            foreach (DataTable pageTable in tasksBindingList)
            {
                foreach (DataRow row in pageTable.Rows)
                {
                    if (row["TaskNo"] is int taskNo && row["IsCheck"] != DBNull.Value)
                    {
                        taskCheckStates[taskNo] = (bool)row["IsCheck"];
                    }
                }
            }
        }

        /// <summary>タスクのチェックボックスの選択状態を反映する処理</summary>
        private void RestoreCheckStates()
        {
            foreach (DataGridViewRow row in TaskInformation.Rows)
            {
                if (row.Cells["TaskNo"].Value is int taskNo && taskCheckStates.TryGetValue(taskNo, out bool isChecked))
                {
                    row.Cells["IsCheck"].Value = isChecked;
                }
            }
        }

        /// <summary>タスク一覧のタスク名をクリック時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            // タスク名のカラムのセルがクリックされた場合
            if (dataGridView.Columns[e.ColumnIndex].Name.Equals("TaskName"))
            {
                // クリックされたタスク名のタスク番号を取得
                int linkTaskNo = (int)dataGridView["TaskNo", e.RowIndex].Value;

                // 詳細画面に遷移
                Program.Display_TaskDetail(userId.Text, linkTaskNo);

                // 一覧画面を閉じる
                this.Close();
            }
        }

        /// <summary>削除ボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {    // まず現在ページのチェック状態を保存
            SaveCheckStates();

            // チェックされた全タスク番号を取得（全ページ分）
            List<int> checkedTaskNo = taskCheckStates
                .Where(kvp => kvp.Value)
                .Select(kvp => kvp.Key)
                .ToList();

            if (checkedTaskNo.Count > 0)
            {
                DialogResult result = MessageBox.Show("選択したタスクを削除しますか？", "タスクの削除", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // 削除実行
                    TasksDao tasksDao = new();
                    int deletedCount = tasksDao.DeleteTask(checkedTaskNo); 

                    // 正常に削除された分だけチェック状態からも削除
                    if (deletedCount > 0)
                    {
                        foreach (int taskNo in checkedTaskNo)
                        {
                            taskCheckStates.Remove(taskNo);
                        }
                    }

                    // 最新のタスク一覧を取得・表示
                    var taskList = tasksDao.SelectMatch(
                        txtTaskName.Text, tagComboBox.Text,
                        txtDateFrom.Text, txtDateTo.Text, txtDueDate.Text,
                        activeComboBox.Text, userId.Text);

                    SetData(taskList, false);
                }
            }
            else
            {
                MessageBox.Show("タスクが選択されていません", "タスクの削除");
            }

        }


        /// <summary>完了ボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoneBtn_Click(object sender, EventArgs e)
        {
            // 全ページ分のチェック状態を保存
            SaveCheckStates();

            // チェック状態から、完了対象のタスク番号を取得
            List<int> checkedTaskNo = taskCheckStates
                .Where(kv => kv.Value)  // チェックされている
                .Select(kv => kv.Key)   // タスク番号のみ
                .ToList();

            if (checkedTaskNo.Count == 0)
            {
                MessageBox.Show("タスクが選択されていません", "タスクの完了");
                return;
            }

            // タスクテーブルのDAO取得
            TasksDao tasksDao = new();

            // 既に完了しているタスクがあるかチェック
            List<int> alreadyCompleted = new();
            foreach (int taskNo in checkedTaskNo)
            {
                if (tasksDao.IsComplete(taskNo))
                {
                    alreadyCompleted.Add(taskNo);
                }
            }

            if (alreadyCompleted.Count > 0)
            {
                MessageBox.Show("選択したタスクは既に完了済みです", "入力値エラー");
                return;
            }

            // ユーザー確認
            DialogResult result = MessageBox.Show("選択したタスクを完了しますか？", "タスクの完了", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // 選択されたタスクを完了に更新
                tasksDao.CompleteTask(checkedTaskNo);

                // チェック状態リセット
                taskCheckStates.Clear();

                // 検索条件で再読み込み
                var taskList = tasksDao.SelectMatch(txtTaskName.Text, tagComboBox.Text, txtDateFrom.Text, txtDateTo.Text, txtDueDate.Text, activeComboBox.Text, userId.Text);
                SetData(taskList, false);
            }
        }

        /// <summary>検索ボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectBtn_Click(object sender, EventArgs e)
        {
            SaveCheckStates();

            // タスク完了期限(開始日)が、タスク完了期限(終了日)より後の日付だった場合
            if (!String.IsNullOrEmpty(txtDateTo.Text) && txtDateFrom.Text.CompareTo(txtDateTo.Text) == 1)
            {
                MessageBox.Show("タスク完了期限(開始日)は、タスク完了期限(終了日)と\n同じか前の日付を設定してください", "入力値エラー");
                return;
            }
            else
            {
                // タスクテーブルのDAO取得
                TasksDao tasksDao = new();

                // 入力されている検索条件で検索
                var taskList = tasksDao.SelectMatch(txtTaskName.Text, tagComboBox.Text, txtDateFrom.Text, txtDateTo.Text, txtDueDate.Text, activeComboBox.Text, userId.Text);

                // 検索結果をタスク一覧に格納
                SetData(taskList, false);
            }
        }

        /// <summary>新規作成ボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateTaskBtn_Click(object sender, EventArgs e)
        {
            // 詳細画面に遷移
            Program.Display_TaskDetail(userId.Text, 0);

            // 一覧画面を閉じる
            this.Close();
        }

        /// <summary>検索条件リセットボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            // タスク一覧画面の初期表示時の検索条件にリセット
            txtTaskName.Text = "";
            tagComboBox.SelectedIndex = 0;
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtDueDate.Text = "";
            activeComboBox.SelectedIndex = 1;

            // チェック状態をリセット
            taskCheckStates.Clear();

            // タスクテーブルのDAO取得
            TasksDao tasksDao = new();

            // 入力されている検索条件で検索
            var taskList = tasksDao.SelectMatch(txtTaskName.Text, tagComboBox.Text, txtDateFrom.Text, txtDateTo.Text, txtDueDate.Text, activeComboBox.Text, userId.Text);

            // 検索結果をタスク一覧に格納
            SetData(taskList, false);
        }

        /// <summary>ログアウトボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // ログイン画面に遷移
            Program.Display_Login();

            // 一覧画面を閉じる
            this.Close();
        }

        /// <summary>タスク完了期限（開始日）ボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDateFrom_Click(object sender, EventArgs e)
        {
            // カレンダー表示処理
            FormCalendar.inputCalenda(this, txtDateFrom, btnDateFrom);
        }

        /// <summary>タスク完了期限（終了日）ボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDateTo_Click(object sender, EventArgs e)
        {
            // カレンダー表示処理
            FormCalendar.inputCalenda(this, txtDateTo, btnDateTo);
        }

        /// <summary>タスク完了日ボタン押下時の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDateDone_Click(object sender, EventArgs e)
        {
            // カレンダー表示処理
            FormCalendar.inputCalenda(this, txtDueDate, maxDateBtn);
        }
    }
}