namespace WindowsFormsApp1
{
    partial class TaskList
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskList));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DueDateLabel = new System.Windows.Forms.Label();
            this.TagLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Re = new System.Windows.Forms.ToolStripLabel();
            this.rental = new System.Windows.Forms.ToolStripLabel();
            this.TaskDetail = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.UserName = new System.Windows.Forms.ToolStripLabel();
            this.TaskInformation = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(305, 96);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 20);
            this.comboBox1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(182, 97);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 19);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 97);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 19);
            this.textBox1.TabIndex = 2;
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.SearchBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.SearchBtn.Location = new System.Drawing.Point(440, 79);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(66, 36);
            this.SearchBtn.TabIndex = 3;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ResetBtn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ResetBtn.Location = new System.Drawing.Point(520, 79);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(65, 36);
            this.ResetBtn.TabIndex = 4;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Task List";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NameLabel.Location = new System.Drawing.Point(17, 76);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(43, 18);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Name";
            // 
            // DueDateLabel
            // 
            this.DueDateLabel.AutoSize = true;
            this.DueDateLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DueDateLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.DueDateLabel.Location = new System.Drawing.Point(179, 75);
            this.DueDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DueDateLabel.Name = "DueDateLabel";
            this.DueDateLabel.Size = new System.Drawing.Size(59, 18);
            this.DueDateLabel.TabIndex = 8;
            this.DueDateLabel.Text = "DueDate";
            // 
            // TagLabel
            // 
            this.TagLabel.AutoSize = true;
            this.TagLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TagLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.TagLabel.Location = new System.Drawing.Point(301, 75);
            this.TagLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TagLabel.Name = "TagLabel";
            this.TagLabel.Size = new System.Drawing.Size(29, 18);
            this.TagLabel.TabIndex = 9;
            this.TagLabel.Text = "Tag";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Re,
            this.rental,
            this.TaskDetail,
            this.toolStripButton1,
            this.UserName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1004, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Re
            // 
            this.Re.ActiveLinkColor = System.Drawing.Color.Tomato;
            this.Re.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Re.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Re.Name = "Re";
            this.Re.Size = new System.Drawing.Size(23, 24);
            this.Re.Text = "Re";
            // 
            // rental
            // 
            this.rental.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rental.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rental.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.rental.Name = "rental";
            this.rental.Size = new System.Drawing.Size(42, 24);
            this.rental.Text = "rental";
            // 
            // TaskDetail
            // 
            this.TaskDetail.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TaskDetail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TaskDetail.Name = "TaskDetail";
            this.TaskDetail.Size = new System.Drawing.Size(69, 24);
            this.TaskDetail.Text = "TaskDetail";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // UserName
            // 
            this.UserName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UserName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(66, 24);
            this.UserName.Text = "Matsunaga";
            // 
            // TaskInformation
            // 
            this.TaskInformation.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TaskInformation.AllowUserToAddRows = false;
            this.TaskInformation.AllowUserToDeleteRows = false;
            this.TaskInformation.AllowUserToResizeColumns = false;
            this.TaskInformation.AllowUserToResizeRows = false;
            this.TaskInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskInformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TaskInformation.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TaskInformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TaskInformation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.TaskInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.Description,
            this.DueDate,
            this.Tag,
            this.IsDone,
            this.UpdatedOn,
            this.IsActive});
            this.TaskInformation.Location = new System.Drawing.Point(19, 130);
            this.TaskInformation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TaskInformation.Name = "TaskInformation";
            this.TaskInformation.RowHeadersVisible = false;
            this.TaskInformation.RowHeadersWidth = 51;
            this.TaskInformation.RowTemplate.Height = 24;
            this.TaskInformation.Size = new System.Drawing.Size(971, 295);
            this.TaskInformation.TabIndex = 11;
            this.TaskInformation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TaskInformation_CellContentClick);
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Name";
            this.TaskName.MinimumWidth = 6;
            this.TaskName.Name = "TaskName";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "DueDate";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            // 
            // Tag
            // 
            this.Tag.HeaderText = "Tag";
            this.Tag.MinimumWidth = 6;
            this.Tag.Name = "Tag";
            // 
            // IsDone
            // 
            this.IsDone.HeaderText = "Is Done";
            this.IsDone.MinimumWidth = 6;
            this.IsDone.Name = "IsDone";
            // 
            // UpdatedOn
            // 
            this.UpdatedOn.HeaderText = "Updated On";
            this.UpdatedOn.MinimumWidth = 6;
            this.UpdatedOn.Name = "UpdatedOn";
            // 
            // IsActive
            // 
            this.IsActive.HeaderText = "Is Active";
            this.IsActive.MinimumWidth = 6;
            this.IsActive.Name = "IsActive";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(440, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(918, 44);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "新規作成";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 477);
            this.Controls.Add(this.TaskInformation);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TagLabel);
            this.Controls.Add(this.DueDateLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TaskList";
            this.Text = "Task List";
            this.Load += new System.EventHandler(this.TaskList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DueDateLabel;
        private System.Windows.Forms.Label TagLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel Re;
        private System.Windows.Forms.ToolStripLabel rental;
        private System.Windows.Forms.ToolStripLabel TaskDetail;
        private System.Windows.Forms.ToolStripLabel UserName;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView TaskInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

