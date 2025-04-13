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
        public DataTable dataTable = new DataTable();
        public BindingSource bindingSource = new BindingSource();
        public BindingList<DataTable> tables = new BindingList<DataTable>();

        // 1ページで表示する行数
        public int pageSize = 5;


        public TaskList()
        {
            InitializeComponent();
            //DetaTableから列の自動生成を行なわない
            TaskInformation.AutoGenerateColumns = false;

            //初期値
            tagComboBox.SelectedIndex = 0;
            activeComboBox.SelectedIndex = 1;

            // 在庫マスタ DAO取得
            TasksDao tasksDao = new();

            // 在庫マスタの全抽出
            var taskList = tasksDao.SelectAll();

            this.dataTable.Columns.Add("TaskNo", typeof(int));
            this.dataTable.Columns.Add("TaskName", typeof(string));
            this.dataTable.Columns.Add("Description", typeof(string));
            this.dataTable.Columns.Add("Tag", typeof(string));
            this.dataTable.Columns.Add("DueDate", typeof(DateTime));
            this.dataTable.Columns.Add("IsDone", typeof(DateTime));
            this.dataTable.Columns.Add("Updated On", typeof(DateTime));
            this.dataTable.Columns.Add("IsActive", typeof(string));

            SetData(taskList);
        }

        private void SetData(List<TasksEntity> tasklist)
        {
            DataTable newDataTable = null;

            TaskInformation.DataSource = newDataTable;
            dataTable.Clear();

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

                    dataTable.Rows.Add(
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
            DataView dv = dataTable.DefaultView;
            dv.Sort = "DueDate DESC";

            SetPagedDataSource();
        }

        private void SetPagedDataSource()
        {
            DataTable dt = null;
            int counter = 1;
            tables.Clear();

            foreach (DataRow dr in this.dataTable.Rows)
            {
                if (counter == 1)
                {
                    dt = dataTable.Clone();
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

                // 在庫マスタの全抽出
                var taskList = tasksDao.SelectAll();

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

                // 在庫マスタの全抽出
                var taskList = tasksDao.SelectAll();

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
                var taskList = tasksDao.SelectMatch(txtTaskName.Text, tagComboBox.Text, txtDateFrom.Text, txtDateTo.Text, txtDateDone.Text, activeComboBox.Text);
                SetData(taskList);
            }
        }

        private void CreateTaskBtn_Click(object sender, EventArgs e)
        {
            Program.Display_TaskDetail();
            this.Close();  //Form1を閉じる処理
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            txtTaskName.Text = "";
            tagComboBox.SelectedIndex = 0;
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtDateDone.Text = "";
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
            FormCalendar.inputCalenda(this, txtDateDone, btnDateDone);
        }
    }
}
