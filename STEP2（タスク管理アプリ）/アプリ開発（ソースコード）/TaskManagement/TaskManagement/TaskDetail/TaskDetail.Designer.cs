namespace TaskManagement
{
    partial class TaskDetail
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.TagLabel = new System.Windows.Forms.Label();
            this.DueDateLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Re = new System.Windows.Forms.ToolStripLabel();
            this.logoutBtn = new System.Windows.Forms.ToolStripButton();
            this.userId = new System.Windows.Forms.ToolStripLabel();
            this.backLink = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.activeComboBox = new System.Windows.Forms.ComboBox();
            this.btnDate = new System.Windows.Forms.Button();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.tagComboBox = new System.Windows.Forms.ComboBox();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.taskDetailTitle = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NameLabel.Location = new System.Drawing.Point(21, 20);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(70, 23);
            this.NameLabel.TabIndex = 8;
            this.NameLabel.Text = "タスク名";
            // 
            // TagLabel
            // 
            this.TagLabel.AutoSize = true;
            this.TagLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TagLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.TagLabel.Location = new System.Drawing.Point(21, 168);
            this.TagLabel.Name = "TagLabel";
            this.TagLabel.Size = new System.Drawing.Size(85, 23);
            this.TagLabel.TabIndex = 10;
            this.TagLabel.Text = "タスク分類";
            // 
            // DueDateLabel
            // 
            this.DueDateLabel.AutoSize = true;
            this.DueDateLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DueDateLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.DueDateLabel.Location = new System.Drawing.Point(21, 251);
            this.DueDateLabel.Name = "DueDateLabel";
            this.DueDateLabel.Size = new System.Drawing.Size(115, 23);
            this.DueDateLabel.TabIndex = 11;
            this.DueDateLabel.Text = "タスク完了期限";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(21, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "タスク状況";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Re,
            this.logoutBtn,
            this.userId});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(622, 31);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Re
            // 
            this.Re.ActiveLinkColor = System.Drawing.Color.Tomato;
            this.Re.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Re.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Re.Name = "Re";
            this.Re.Size = new System.Drawing.Size(29, 28);
            this.Re.Text = "Re";
            // 
            // logoutBtn
            // 
            this.logoutBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logoutBtn.Image = global::TaskManagement.Properties.Resources.ログアウトイラスト1;
            this.logoutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(29, 28);
            this.logoutBtn.Text = "ログアウト";
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // userId
            // 
            this.userId.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userId.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(0, 28);
            // 
            // backLink
            // 
            this.backLink.AutoSize = true;
            this.backLink.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.backLink.Location = new System.Drawing.Point(12, 46);
            this.backLink.Name = "backLink";
            this.backLink.Size = new System.Drawing.Size(55, 23);
            this.backLink.TabIndex = 22;
            this.backLink.TabStop = true;
            this.backLink.Text = "◁戻る";
            this.backLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.backLink_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.activeComboBox);
            this.panel1.Controls.Add(this.btnDate);
            this.panel1.Controls.Add(this.txtDueDate);
            this.panel1.Controls.Add(this.tagComboBox);
            this.panel1.Controls.Add(this.txtTaskName);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Controls.Add(this.TagLabel);
            this.panel1.Controls.Add(this.DueDateLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(19, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 400);
            this.panel1.TabIndex = 23;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDescription.Location = new System.Drawing.Point(25, 118);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.MaxLength = 30;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(522, 30);
            this.txtDescription.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(21, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "説明";
            // 
            // activeComboBox
            // 
            this.activeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activeComboBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.activeComboBox.FormattingEnabled = true;
            this.activeComboBox.Items.AddRange(new object[] {
            "未完了",
            "完了"});
            this.activeComboBox.Location = new System.Drawing.Point(25, 349);
            this.activeComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.activeComboBox.Name = "activeComboBox";
            this.activeComboBox.Size = new System.Drawing.Size(90, 31);
            this.activeComboBox.TabIndex = 28;
            // 
            // btnDate
            // 
            this.btnDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDate.Location = new System.Drawing.Point(145, 277);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(29, 30);
            this.btnDate.TabIndex = 27;
            this.btnDate.Text = "▼\r\n\r\n";
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // txtDueDate
            // 
            this.txtDueDate.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDueDate.Location = new System.Drawing.Point(25, 276);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(120, 30);
            this.txtDueDate.TabIndex = 25;
            // 
            // tagComboBox
            // 
            this.tagComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagComboBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tagComboBox.FormattingEnabled = true;
            this.tagComboBox.Location = new System.Drawing.Point(25, 195);
            this.tagComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tagComboBox.Name = "tagComboBox";
            this.tagComboBox.Size = new System.Drawing.Size(188, 31);
            this.tagComboBox.TabIndex = 21;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTaskName.Location = new System.Drawing.Point(25, 47);
            this.txtTaskName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTaskName.MaxLength = 15;
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(522, 30);
            this.txtTaskName.TabIndex = 20;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConfirmBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ConfirmBtn.Location = new System.Drawing.Point(506, 521);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(96, 45);
            this.ConfirmBtn.TabIndex = 30;
            this.ConfirmBtn.Text = "修正";
            this.ConfirmBtn.UseVisualStyleBackColor = false;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // taskDetailTitle
            // 
            this.taskDetailTitle.AutoSize = true;
            this.taskDetailTitle.Font = new System.Drawing.Font("メイリオ", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.taskDetailTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.taskDetailTitle.Location = new System.Drawing.Point(12, 69);
            this.taskDetailTitle.Name = "taskDetailTitle";
            this.taskDetailTitle.Size = new System.Drawing.Size(158, 42);
            this.taskDetailTitle.TabIndex = 20;
            this.taskDetailTitle.Text = "タスク登録";
            // 
            // TaskDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 576);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.backLink);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.taskDetailTitle);
            this.Name = "TaskDetail";
            this.Text = "タスク詳細";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TagLabel;
        private System.Windows.Forms.Label DueDateLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel Re;
        private System.Windows.Forms.ToolStripButton logoutBtn;
        private System.Windows.Forms.ToolStripLabel userId;
        private System.Windows.Forms.LinkLabel backLink;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.ComboBox tagComboBox;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.Button btnDate;
        private System.Windows.Forms.ComboBox activeComboBox;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label taskDetailTitle;
    }
}

