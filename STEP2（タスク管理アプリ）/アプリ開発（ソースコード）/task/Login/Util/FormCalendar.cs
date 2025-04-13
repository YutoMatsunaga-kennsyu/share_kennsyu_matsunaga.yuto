using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagement
{
    public partial class FormCalendar : Form
    {
        // 選択日
        private string selectDate;

        public FormCalendar()
        {
            InitializeComponent();
        }

        private void FormCalendar_Load_1(object sender, EventArgs e)
        {
            // 本日の日付マークを非表示にする（見にくい為）
            monthCalendar1.ShowTodayCircle = false;

            // 日付選択は1日のみとする
            monthCalendar1.MaxSelectionCount = 1;

            // 日付チェックを行い、カレンダに初期日をセットする
            if (selectDate.Length > 0)
            {
                DateTime d;
                if (DateTime.TryParse(selectDate, out d))
                {
                    monthCalendar1.SelectionStart = d;
                }
            }
        }

        /// <summary>
        /// カレンダ表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void inputCalenda(IWin32Window owner, TextBox textBox, Button bt)
        {
            // カレンダフォームのインスタンスを作成する
            FormCalendar calenda = new FormCalendar();

            // 引数の日付をカレンダフォームにセットする
            calenda.selectDate = textBox.Text;

            calenda.Location = bt.PointToScreen(bt.ClientRectangle.Location);

            if (bt.Name.Equals("btnDateDone"))
            {
                calenda.monthCalendar1.MaxDate = DateTime.Today;
            }
            else if (bt.Name.Equals("btnDate"))
            {
                calenda.monthCalendar1.MinDate = DateTime.Today;
            }

            // カレンダーフォームを表示する
            calenda.ShowDialog(owner);



            // 選択された日付をtextBoxにセットする
            if (!textBox.Text.Equals(calenda.selectDate))
            {
                textBox.Text = calenda.selectDate;
            }
        }

        private void btnSet_Click_1(object sender, EventArgs e)
        {
            // 選択された日付を
            selectDate = monthCalendar1.SelectionStart.ToString("yyyy/MM/dd");

            // カレンダ画面を閉じる
            this.Close();
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            // カレンダ画面を閉じる
            this.Close();
        }
    }
}
