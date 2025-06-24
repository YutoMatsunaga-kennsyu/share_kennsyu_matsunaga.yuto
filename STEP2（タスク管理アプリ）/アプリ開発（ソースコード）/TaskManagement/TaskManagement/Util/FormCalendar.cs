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
    ///<summary>カレンダークラス</summary>
    public partial class FormCalendar : Form
    {
        // 日付が入力されるテキストボックス
        public TextBox TargetTextBox { get; set; }

        // カレンダー選択日
        private String gStrSelectDate;

        /// <summary>カレンダークラスのコンストラクタ</summary>
        public FormCalendar()
        {
            InitializeComponent();
        }

        /// <summary>カレンダーロード時処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalendar_Load(object sender, EventArgs e)
        {
            // カレンダーフォームの外をクリックした際の処理
            this.Deactivate += FormCalendar_Deactivate;

            // カレンダーの本日の日付マークを非表示
            monthCalendar.ShowTodayCircle = false;

            // カレンダーで選択可能な日付を1日のみにする
            monthCalendar.MaxSelectionCount = 1;

            // 日付チェックを行い、カレンダに初期日をセットする
            if (gStrSelectDate.Length > 0)
            {
                DateTime initialDate;
                if (DateTime.TryParse(this.gStrSelectDate, out initialDate))
                {
                    monthCalendar.SelectionStart = initialDate;
                }
            }
        }

        /// <summary>カレンダー表示処理 </summary>
        /// <param name="owner"></param>
        /// <param name="textBox">カレンダーで選択した日付を反映させるテキストボックス</param>
        /// <param name="pressedBtn">カレンダーを表示させる際に押下したボタン</param>
        public static void inputCalenda(IWin32Window owner, TextBox textBox, Button pressedBtn)
        {
            // カレンダフォームのインスタンスを作成する
            FormCalendar calenda = new();

            // 引数の日付をカレンダフォームにセットする
            calenda.gStrSelectDate = textBox.Text;
            calenda.TargetTextBox = textBox;

            // カレンダーが表示される箇所を押下したボタンの横に設定する
            calenda.Location = pressedBtn.PointToScreen(pressedBtn.ClientRectangle.Location);

            // 押下したボタンによって、カレンダーで選択可能な日付を制限する(タスク完了日、タスク完了期限）
            if (pressedBtn.Name.Equals("maxDateBtn"))
            {
                calenda.monthCalendar.MaxDate = DateTime.Today;
            }
            else if (pressedBtn.Name.Equals("minDateBtn"))
            {
                calenda.monthCalendar.MinDate = DateTime.Today;
            }

            // カレンダーフォームを表示する
            calenda.TopMost = true;  
            calenda.Show(owner);     

            // カレンダーで選択された日付をtextBoxにセットする
            if (!textBox.Text.Equals(calenda.gStrSelectDate))
            {
                textBox.Text = calenda.gStrSelectDate;
            }
        }

        /// <summary>カレンダーの選択ボタン押下時処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setBtn_Click(object sender, EventArgs e)
        {
            // カレンダーで選択された日付を変数に格納する
            gStrSelectDate = monthCalendar.SelectionStart.ToString("yyyy/MM/dd");

            // テキストボックスに日付をセットする
            if (TargetTextBox != null)
            {
                TargetTextBox.Text = gStrSelectDate;  
            }

            // カレンダ画面を閉じる
            this.Close();
        }

        /// <summary>カレンダーの削除ボタン押下時処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // テキストボックスに入力されている日付を削除
            TargetTextBox.Text = "";

            // カレンダ画面を閉じる
            this.Close();
        }

        /// <summary>カレンダーの戻るボタン押下時処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnBtn_Click(object sender, EventArgs e)
        {
            // カレンダ画面を閉じる
            this.Close();
        }

        /// <summary>カレンダーフォームの外をクリックした際の処理</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalendar_Deactivate(object sender, EventArgs e)
        {
            // カレンダ画面を閉じる
            this.Close();
        }
    }
}
