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

        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            // カレンダ表示処理
            FormCalendar.inputCalenda(this, txtDate, btnDate);
        }
    }
}
