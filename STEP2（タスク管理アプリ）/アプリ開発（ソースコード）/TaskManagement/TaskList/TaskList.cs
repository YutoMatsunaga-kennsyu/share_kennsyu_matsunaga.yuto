using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class TaskList : Form
    {
        public TaskList()
        {
            InitializeComponent();
            // 在庫マスタ DAO取得
            TaskListDao ms_Stock_Dao = new();

            // 在庫マスタの全抽出
            var _msStockDataList = ms_Stock_Dao.SelectAll();

            foreach (var _msStockData in _msStockDataList)
            {
                TaskInformation.Rows.Add(
                    _msStockData.taskName,
                    _msStockData.description,
                    _msStockData.dueDate,
                    _msStockData.tag,
                    _msStockData.doneDate,
                    _msStockData.updateDate
                );
            }

        }

        private void TaskInformation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
