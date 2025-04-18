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

    public partial class TaskList : Form

    {

        public DataTable tasksDataTable = new DataTable();
        public BindingSource bindingSource = new BindingSource();
        public BindingList<DataTable> tables = new BindingList<DataTable>();

        // 1ページで表示する行数
        public int pageSize = 5;

        public TaskList(String userId)
        {
            InitializeComponent();

            TaskTagsDao taskTagsDao = new TaskTagsDao();
            List<TaskTagsEntity> taskTagsList = taskTagsDao.getTaskTagsName();

            foreach (var taskTag in taskTagsList)
            {
                tagComboBox.Items.Add(taskTag.tagName);
            }

            UserId.Text = userId;

            //DetaTableから列の自動生成を行なわない
            TaskInformation.AutoGenerateColumns = false;

            //初期値
            tagComboBox.SelectedIndex = 0;
            activeComboBox.SelectedIndex = 1;

            // 在庫マスタ DAO取得
            TasksDao tasksDao = new();

            // 在庫マスタの全抽出
            var taskList = tasksDao.SelectAll(userId);

            this.tasksDataTable.Columns.Add("TaskNo", typeof(int));
            this.tasksDataTable.Columns.Add("TaskName", typeof(string));
            this.tasksDataTable.Columns.Add("Description", typeof(string));
            this.tasksDataTable.Columns.Add("Tag", typeof(string));
            this.tasksDataTable.Columns.Add("DueDate", typeof(DateTime));
            this.tasksDataTable.Columns.Add("IsDone", typeof(DateTime));
            this.tasksDataTable.Columns.Add("Updated On", typeof(DateTime));
            this.tasksDataTable.Columns.Add("IsActive", typeof(string));

            SetData(taskList);
        }

        private void TaskInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            //"Link"列ならば、ボタンがクリックされた
            if (dataGridView.Columns[e.ColumnIndex].Name.Equals("TaskName"))
            {

                int linkTaskNo = (int)dataGridView["TaskNo", e.RowIndex].Value;
                Program.Display_TaskDetail(UserId.Text, linkTaskNo);
                this.Close();  //Form1を閉じる処理
            }
        }

        private void SetData(List<TasksEntity> tasklist)
        {
            DataTable newDataTable = null;

            TaskInformation.DataSource = newDataTable;
            tasksDataTable.Clear();

            if (tasklist?.Count > 0) {
                foreach (var task in tasklist)
                {
                    String active;

                    if (task.isActive == true)
                    {
                        active = "未完了";
                    }
                    else
                    {
                        active = "完了";
                    }

                    tasksDataTable.Rows.Add(
                        task.taskNo,
                        task.taskName,
                        task.description,
                        task.tagName,
                        task.dueDate,
                        task.doneDate,
                        task.updateDate,
                        active
                    );
                }
            }

            //DataViewを取得
            DataView dv = tasksDataTable.DefaultView;
            dv.Sort = "DueDate DESC";

            SetPagedDataSource();
        }

        private void SetPagedDataSource()
        {
            DataTable dt = null;
            int counter = 1;
            tables.Clear();

            foreach (DataRow dr in this.tasksDataTable.Rows)
            {
                if (counter == 1)
                {
                    dt = tasksDataTable.Clone();
                    tables.Add(dt);
                }

                dt.Rows.Add(dr.ItemArray);

                if (pageSize < ++counter)
                {
                    counter = 1;
                }
            }

            this.bindingNavigator1.BindingSource = bindingSource;

            bindingSource.DataSource = tables;

            bindingSource.PositionChanged += bindingSource_PositionChanged;

            bindingSource_PositionChanged(bindingSource, EventArgs.Empty);

        }

        private void bindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (tables?.Count > 0)
            {
                this.TaskInformation.DataSource = tables[bindingSource.Position];
            }
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("選択したタスクを削除しますか？", "タスクの削除", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                TasksDao tasksDao = new();

                for (int i = 0; i < TaskInformation.RowCount; i++)

                {
                    ////チェックボックスのチェックされている行を読み込み
                    if (TaskInformation.Rows[i].Cells["IsCheck"].Value != null)
                    {
                        //セルのValueをbool型で受け取るのがポイント！
                        if ((bool)TaskInformation.Rows[i].Cells["IsCheck"].Value)
                        {
                            tasksDao.DeleteTask((int)TaskInformation.Rows[i].Cells["TaskNo"].Value);
                        }
                    }

                }

                var taskList = tasksDao.SelectMatch(txtTaskName.Text, tagComboBox.Text, txtDateFrom.Text, txtDateTo.Text, txtDueDate.Text, activeComboBox.Text, UserId.Text);

                SetData(taskList);
            }
            else
            {
                return;
            }
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            TasksDao tasksDao = new();
            for (int i = 0; i < TaskInformation.RowCount; i++)

            {
                ////チェックボックスのチェックされている行を読み込み
                if (TaskInformation.Rows[i].Cells["IsCheck"].Value != null)
                {
                    //セルのValueをbool型で受け取るのがポイント！
                    if ((bool)TaskInformation.Rows[i].Cells["IsCheck"].Value)
                    {
                        if (tasksDao.IsComplete((int)TaskInformation.Rows[i].Cells["TaskNo"].Value))
                        {
                            MessageBox.Show("選択したタスクは既に完了済みです", "入力値エラー");
                            return;
                        }
                    }
                }
            }

            DialogResult result = MessageBox.Show("選択したタスクを完了しますか？", "タスクの完了", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < TaskInformation.RowCount; i++)

                {
                    ////チェックボックスのチェックされている行を読み込み
                    if (TaskInformation.Rows[i].Cells["IsCheck"].Value != null)
                    {
                        //セルのValueをbool型で受け取るのがポイント！
                        if ((bool)TaskInformation.Rows[i].Cells["IsCheck"].Value)
                        {
                            tasksDao.CompleteTask((int)TaskInformation.Rows[i].Cells["TaskNo"].Value);
                        }
                    }

                }

                var taskList = tasksDao.SelectMatch(txtTaskName.Text, tagComboBox.Text, txtDateFrom.Text, txtDateTo.Text, txtDueDate.Text, activeComboBox.Text, UserId.Text);

                SetData(taskList);
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if(txtDateFrom.Text.CompareTo(txtDateTo.Text) == 1)
            {
                MessageBox.Show("タスク完了期限(開始日)は、タスク完了期限(終了日)と同じか前の日付を設定してください", "入力値エラー");
                return;
            }
            else
            {
                TasksDao tasksDao = new();
                var taskList = tasksDao.SelectMatch(txtTaskName.Text, tagComboBox.Text, txtDateFrom.Text, txtDateTo.Text, txtDueDate.Text, activeComboBox.Text, UserId.Text);
                SetData(taskList);
            }
        }

        private void CreateTaskBtn_Click(object sender, EventArgs e)
        {
            Program.Display_TaskDetail(UserId.Text, 0);
            this.Close();  //Form1を閉じる処理
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            txtTaskName.Text = "";
            tagComboBox.SelectedIndex = 0;
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtDueDate.Text = "";
            activeComboBox.SelectedIndex = 0;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Program.Display_Login();
            this.Close();  //Form1を閉じる処理

        }
        private void btnDateTo_Click(object sender, EventArgs e)
        {
            // カレンダ表示処理
            FormCalendar.inputCalenda(this, txtDateTo, btnDateTo);
        }

        private void btnDateFrom_Click(object sender, EventArgs e)
        {
            // カレンダ表示処理
            FormCalendar.inputCalenda(this, txtDateFrom, btnDateFrom);
        }

        private void btnDateDone_Click(object sender, EventArgs e)
        {
            // カレンダ表示処理
            FormCalendar.inputCalenda(this, txtDueDate, btnDateDone);
        }


    }
}
