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
using Login;

namespace TaskList
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
            TagComboBox.SelectedIndex = 0;
            ActiveComboBox.SelectedIndex = 1;

            // 在庫マスタ DAO取得
            TasksDao ms_Stock_Dao = new();

            // 在庫マスタの全抽出
            var _msStockDataList = ms_Stock_Dao.SelectAll();

            this.dataTable.Columns.Add("TaskName", typeof(string));
            this.dataTable.Columns.Add("Description", typeof(string));
            this.dataTable.Columns.Add("Tag", typeof(string));
            this.dataTable.Columns.Add("DueDate", typeof(DateTime));
            this.dataTable.Columns.Add("IsDone", typeof(DateTime));
            this.dataTable.Columns.Add("Updated On", typeof(DateTime));
            this.dataTable.Columns.Add("IsActive", typeof(string));

            foreach (var _msStockData in _msStockDataList)
            {
                String active;

                if (_msStockData.isActive == true)
                {
                    active = "未完了";
                }
                else
                {
                    active = "完了";
                }

                dataTable.Rows.Add(
                    _msStockData.taskName,
                    _msStockData.description,
                    _msStockData.tagName,
                    _msStockData.dueDate,
                    _msStockData.doneDate,
                    _msStockData.updateDate,
                    active
                );
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
            this.TaskInformation.DataSource = tables[bindingSource.Position];
        }

        private void TaskList_Load(object sender, EventArgs e)
        {

        }


        private void TaskInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            txtTaskName.Text = "";
            TagComboBox.SelectedIndex = 0;
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtDateDone.Text = "";
            ActiveComboBox.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("選択したタスクを削除しますか？", "タスクの削除", MessageBoxButtons.YesNo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("選択したタスクは既に完了済みです", "入力値エラー");
            MessageBox.Show("選択したタスクを完了しますか？", "タスクの完了", MessageBoxButtons.YesNo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("タスク完了期限(開始日)は、タスク完了期限(終了日)と同じか前の日付を設定してください", "入力値エラー");
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login.Login login = new Login.Login();
            
            login.ShowDialog();


        }
    }
}
