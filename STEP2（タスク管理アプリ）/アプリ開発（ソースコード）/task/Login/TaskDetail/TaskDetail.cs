using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagement;


namespace TaskManagement
{
    public partial class TaskDetail : Form
    {
        public TaskDetail(String userId, int linkTaskNo)
        {
            InitializeComponent();

            TaskTagsDao taskTagsDao = new TaskTagsDao();
            List<TaskTagsEntity> taskTagsList = taskTagsDao.getTaskTagsName();

            TasksDao tasksDao = new TasksDao();
            List<TasksEntity> taskList = tasksDao.getTaskInformation(linkTaskNo);

            foreach (var taskTag in taskTagsList)
            {
                tagComboBox.Items.Add(taskTag.tagName);
            }

            this.userId.Text = userId;

            if (linkTaskNo == 0)
            {
                taskDetailTitle.Text = "タスク登録";
                ConfirmBtn.Text = "登録";
                btnDate.Name = "minBtnDate";

                //初期値
                tagComboBox.SelectedIndex = 0;
                activeComboBox.SelectedIndex = 0;
                activeComboBox.Enabled = false;
            }
            else 
            {
                taskDetailTitle.Text = "タスク修正";
                ConfirmBtn.Text = "修正";

                foreach (var task in taskList)
                {
                    txtTaskName.Text = task.taskName;
                    txtDescription.Text = task.description;
                    tagComboBox.SelectedIndex = task.tagNo - 1;
                    txtDueDate.Text = task.dueDate.ToString("yyyy/MM/dd");
                    if(task.isActive == true)
                    {
                        activeComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        activeComboBox.SelectedIndex = 1;
                    }
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
            MessageBox.Show("入力した内容でタスクを修正しますか？", "タスクの修正", MessageBoxButtons.YesNo);
            
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            // カレンダ表示処理
            FormCalendar.inputCalenda(this, txtDueDate, btnDate);
        }

        private void backLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Display_TaskList(userId.Text);
            this.Close();  //Form1を閉じる処理
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtTaskName.Text)) || (string.IsNullOrEmpty(txtDueDate.Text)))
            {
                MessageBox.Show("タスク名、またはタスク完了期限が未入力です", "入力値エラー");
                return;
            }

            DialogResult result = MessageBox.Show("入力した内容でタスクを登録しますか？", "タスクの登録", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                TasksDao tasksDao = new TasksDao();
                tasksDao.CreateTask(txtTaskName.Text, txtDescription.Text, tagComboBox.SelectedIndex + 1, txtDueDate.Text, this.userId.Text);
                txtTaskName.Text = "";
                tagComboBox.SelectedIndex = 0;
                txtDueDate.Text = "";
                activeComboBox.SelectedIndex = 0;
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Program.Display_Login();
            this.Close();  //Form1を閉じる処理
        }
    }
}
