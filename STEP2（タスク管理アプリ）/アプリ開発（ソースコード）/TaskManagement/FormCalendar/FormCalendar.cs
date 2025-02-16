namespace FormCalendar
{
    public partial class FormCalendar : Form
    {
        public FormCalendar()
        {
            InitializeComponent();
        }

        // �I���
        private string selectDate;

        /// <summary>
        /// �N��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalendar_Load(object sender, EventArgs e)
        {

            // ���t�I����1���݂̂Ƃ���
            monthCalendar1.MaxSelectionCount = 1;

            // ���t�`�F�b�N���s���A�J�����_�ɏ��������Z�b�g����
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
        /// �J�����_�\������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void inputCalenda(IWin32Window owner, TextBox textBox)
        {
            // �J�����_�t�H�[���̃C���X�^���X���쐬����
            FormCalendar calenda = new FormCalendar();

            // �����̓��t���J�����_�t�H�[���ɃZ�b�g����
            calenda.selectDate = textBox.Text;

            // �J�����_�[�t�H�[����\������
            calenda.Show();

            // �I�����ꂽ���t��textBox�ɃZ�b�g����
            if (!textBox.Text.Equals(calenda.selectDate))
            {
                textBox.Text = calenda.selectDate;
            }
        }
    }
}
