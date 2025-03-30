using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace TaskDetail
{
    public partial class TaskDetail : Form
    {
        public TaskDetail()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初期値
            ActiveComboBox.SelectedIndex = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("タスク名、またはタスク完了期限が未入力です", "入力値エラー");
            MessageBox.Show("入力されたタスク名は未完了のタスクに既に存在します", "入力値エラー");
            MessageBox.Show("入力した内容でタスクを修正しますか？", "タスクの修正", MessageBoxButtons.YesNo);
            MessageBox.Show("入力した内容でタスクを登録しますか？", "タスクの登録", MessageBoxButtons.YesNo);
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            // カレンダ表示処理
            FormCalendar.inputCalenda(this, txtDate, btnDate);
        }
    }
}
