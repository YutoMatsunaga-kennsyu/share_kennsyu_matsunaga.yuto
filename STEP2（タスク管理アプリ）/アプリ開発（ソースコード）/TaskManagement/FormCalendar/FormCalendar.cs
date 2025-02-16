namespace FormCalendar
{
    public partial class FormCalendar : Form
    {
        public FormCalendar()
        {
            InitializeComponent();
        }

        // 選択日
        private string selectDate;

        /// <summary>
        /// 起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalendar_Load(object sender, EventArgs e)
        {

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
        public static void inputCalenda(IWin32Window owner, TextBox textBox)
        {
            // カレンダフォームのインスタンスを作成する
            FormCalendar calenda = new FormCalendar();

            // 引数の日付をカレンダフォームにセットする
            calenda.selectDate = textBox.Text;

            // カレンダーフォームを表示する
            calenda.Show();

            // 選択された日付をtextBoxにセットする
            if (!textBox.Text.Equals(calenda.selectDate))
            {
                textBox.Text = calenda.selectDate;
            }
        }
    }
}
