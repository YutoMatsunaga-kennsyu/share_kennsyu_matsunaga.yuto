namespace TaskManagement
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskList));
            this.tagComboBox = new System.Windows.Forms.ComboBox();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DueDateLabel = new System.Windows.Forms.Label();
            this.TagLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Re = new System.Windows.Forms.ToolStripLabel();
            this.logoutBtn = new System.Windows.Forms.ToolStripButton();
            this.UserId = new System.Windows.Forms.ToolStripLabel();
            this.TaskInformation = new System.Windows.Forms.DataGridView();
            this.TaskNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updated_On = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.CreateTaskBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.activeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDateTo = new System.Windows.Forms.Button();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.btnDateFrom = new System.Windows.Forms.Button();
            this.btnDateDone = new System.Windows.Forms.Button();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tagComboBox
            // 
            this.tagComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagComboBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tagComboBox.FormattingEnabled = true;
            this.tagComboBox.Items.AddRange(new object[] {
            "全て"});
            this.tagComboBox.Location = new System.Drawing.Point(299, 131);
            this.tagComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tagComboBox.Name = "tagComboBox";
            this.tagComboBox.Size = new System.Drawing.Size(188, 31);
            this.tagComboBox.TabIndex = 0;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTaskName.Location = new System.Drawing.Point(26, 131);
            this.txtTaskName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(257, 30);
            this.txtTaskName.TabIndex = 2;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetBtn.BackColor = System.Drawing.Color.White;
            this.ResetBtn.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.ResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ResetBtn.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.ResetBtn.Location = new System.Drawing.Point(1117, 123);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(96, 44);
            this.ResetBtn.TabIndex = 4;
            this.ResetBtn.Text = "リセット";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "タスク一覧";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NameLabel.Location = new System.Drawing.Point(23, 106);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(70, 23);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "タスク名";
            // 
            // DueDateLabel
            // 
            this.DueDateLabel.AutoSize = true;
            this.DueDateLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DueDateLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.DueDateLabel.Location = new System.Drawing.Point(498, 107);
            this.DueDateLabel.Name = "DueDateLabel";
            this.DueDateLabel.Size = new System.Drawing.Size(115, 23);
            this.DueDateLabel.TabIndex = 8;
            this.DueDateLabel.Text = "タスク完了期限";
            // 
            // TagLabel
            // 
            this.TagLabel.AutoSize = true;
            this.TagLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TagLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.TagLabel.Location = new System.Drawing.Point(294, 107);
            this.TagLabel.Name = "TagLabel";
            this.TagLabel.Size = new System.Drawing.Size(85, 23);
            this.TagLabel.TabIndex = 9;
            this.TagLabel.Text = "タスク分類";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Re,
            this.logoutBtn,
            this.UserId});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1339, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Re
            // 
            this.Re.ActiveLinkColor = System.Drawing.Color.Tomato;
            this.Re.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Re.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Re.Name = "Re";
            this.Re.Size = new System.Drawing.Size(29, 24);
            this.Re.Text = "Re";
            // 
            // logoutBtn
            // 
            this.logoutBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logoutBtn.Image = global::Login.Properties.Resources.ログアウトイラスト1;
            this.logoutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(29, 24);
            this.logoutBtn.Text = "toolStripButton1";
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // UserId
            // 
            this.UserId.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UserId.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(0, 24);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TaskInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TaskInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskNo,
            this.TaskName,
            this.Description,
            this.Tag,
            this.DueDate,
            this.a,
            this.Updated_On,
            this.Is_Active,
            this.IsCheck});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TaskInformation.DefaultCellStyle = dataGridViewCellStyle10;
            this.TaskInformation.EnableHeadersVisualStyles = false;
            this.TaskInformation.Location = new System.Drawing.Point(25, 190);
            this.TaskInformation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TaskInformation.Name = "TaskInformation";
            this.TaskInformation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TaskInformation.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.TaskInformation.RowHeadersVisible = false;
            this.TaskInformation.RowHeadersWidth = 51;
            this.TaskInformation.RowTemplate.Height = 50;
            this.TaskInformation.Size = new System.Drawing.Size(1295, 343);
            this.TaskInformation.TabIndex = 11;
            this.TaskInformation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TaskInformation_CellContentClick);
            // 
            // TaskNo
            // 
            this.TaskNo.DataPropertyName = "TaskNo";
            this.TaskNo.HeaderText = "タスク番号（非表示）";
            this.TaskNo.MinimumWidth = 6;
            this.TaskNo.Name = "TaskNo";
            this.TaskNo.Visible = false;
            // 
            // TaskName
            // 
            this.TaskName.DataPropertyName = "TaskName";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.TaskName.DefaultCellStyle = dataGridViewCellStyle2;
            this.TaskName.FillWeight = 102.0626F;
            this.TaskName.HeaderText = "タスク名";
            this.TaskName.MinimumWidth = 6;
            this.TaskName.Name = "TaskName";
            this.TaskName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Description.DefaultCellStyle = dataGridViewCellStyle3;
            this.Description.FillWeight = 102.0626F;
            this.Description.HeaderText = "説明";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tag
            // 
            this.Tag.DataPropertyName = "Tag";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Tag.DefaultCellStyle = dataGridViewCellStyle4;
            this.Tag.FillWeight = 102.0626F;
            this.Tag.HeaderText = "タスク分類";
            this.Tag.MinimumWidth = 6;
            this.Tag.Name = "Tag";
            this.Tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DueDate
            // 
            this.DueDate.DataPropertyName = "DueDate";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DueDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.DueDate.FillWeight = 102.0626F;
            this.DueDate.HeaderText = "タスク完了期限";
            this.DueDate.MinimumWidth = 6;
            this.DueDate.Name = "DueDate";
            this.DueDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // a
            // 
            this.a.DataPropertyName = "IsDone";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.a.DefaultCellStyle = dataGridViewCellStyle6;
            this.a.FillWeight = 102.0626F;
            this.a.HeaderText = "タスク完了日";
            this.a.MinimumWidth = 6;
            this.a.Name = "a";
            this.a.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Updated_On
            // 
            this.Updated_On.DataPropertyName = "Updated On";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.Updated_On.DefaultCellStyle = dataGridViewCellStyle7;
            this.Updated_On.FillWeight = 102.0626F;
            this.Updated_On.HeaderText = "タスク更新日";
            this.Updated_On.MinimumWidth = 6;
            this.Updated_On.Name = "Updated_On";
            this.Updated_On.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Is_Active
            // 
            this.Is_Active.DataPropertyName = "IsActive";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.Is_Active.DefaultCellStyle = dataGridViewCellStyle8;
            this.Is_Active.FillWeight = 102.0626F;
            this.Is_Active.HeaderText = "タスク状況";
            this.Is_Active.MinimumWidth = 6;
            this.Is_Active.Name = "Is_Active";
            this.Is_Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IsCheck
            // 
            this.IsCheck.DataPropertyName = "IsCheck";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.NullValue = false;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.IsCheck.DefaultCellStyle = dataGridViewCellStyle9;
            this.IsCheck.FillWeight = 85.56149F;
            this.IsCheck.HeaderText = "削除/完了選択";
            this.IsCheck.MinimumWidth = 6;
            this.IsCheck.Name = "IsCheck";
            // 
            // SelectBtn
            // 
            this.SelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.SelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SelectBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.SelectBtn.Location = new System.Drawing.Point(1224, 122);
            this.SelectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(96, 45);
            this.SelectBtn.TabIndex = 3;
            this.SelectBtn.Text = "検索";
            this.SelectBtn.UseVisualStyleBackColor = false;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // CreateTaskBtn
            // 
            this.CreateTaskBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateTaskBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.CreateTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateTaskBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CreateTaskBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreateTaskBtn.Location = new System.Drawing.Point(1224, 46);
            this.CreateTaskBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateTaskBtn.Name = "CreateTaskBtn";
            this.CreateTaskBtn.Size = new System.Drawing.Size(96, 45);
            this.CreateTaskBtn.TabIndex = 5;
            this.CreateTaskBtn.Text = "新規作成";
            this.CreateTaskBtn.UseVisualStyleBackColor = false;
            this.CreateTaskBtn.Click += new System.EventHandler(this.CreateTaskBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(605, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 23);
            this.label2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(836, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "タスク完了日";
            // 
            // activeComboBox
            // 
            this.activeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activeComboBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.activeComboBox.FormattingEnabled = true;
            this.activeComboBox.Items.AddRange(new object[] {
            "全て",
            "未完了",
            "完了"});
            this.activeComboBox.Location = new System.Drawing.Point(1012, 134);
            this.activeComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.activeComboBox.Name = "activeComboBox";
            this.activeComboBox.Size = new System.Drawing.Size(90, 31);
            this.activeComboBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(1007, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "タスク状況";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(645, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "～";
            // 
            // btnDateTo
            // 
            this.btnDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDateTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDateTo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDateTo.Location = new System.Drawing.Point(786, 134);
            this.btnDateTo.Name = "btnDateTo";
            this.btnDateTo.Size = new System.Drawing.Size(29, 30);
            this.btnDateTo.TabIndex = 22;
            this.btnDateTo.Text = "▼\r\n\r\n";
            this.btnDateTo.UseVisualStyleBackColor = false;
            this.btnDateTo.Click += new System.EventHandler(this.btnDateTo_Click);
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDateFrom.Location = new System.Drawing.Point(502, 131);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.ReadOnly = true;
            this.txtDateFrom.Size = new System.Drawing.Size(115, 30);
            this.txtDateFrom.TabIndex = 24;
            // 
            // txtDateTo
            // 
            this.txtDateTo.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDateTo.Location = new System.Drawing.Point(671, 132);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.ReadOnly = true;
            this.txtDateTo.Size = new System.Drawing.Size(115, 30);
            this.txtDateTo.TabIndex = 25;
            // 
            // btnDateFrom
            // 
            this.btnDateFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDateFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDateFrom.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDateFrom.Location = new System.Drawing.Point(614, 132);
            this.btnDateFrom.Name = "btnDateFrom";
            this.btnDateFrom.Size = new System.Drawing.Size(29, 30);
            this.btnDateFrom.TabIndex = 26;
            this.btnDateFrom.Text = "▼\r\n\r\n";
            this.btnDateFrom.UseVisualStyleBackColor = false;
            this.btnDateFrom.Click += new System.EventHandler(this.btnDateFrom_Click);
            // 
            // btnDateDone
            // 
            this.btnDateDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDateDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDateDone.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDateDone.Location = new System.Drawing.Point(956, 135);
            this.btnDateDone.Name = "btnDateDone";
            this.btnDateDone.Size = new System.Drawing.Size(29, 30);
            this.btnDateDone.TabIndex = 27;
            this.btnDateDone.Text = "▼\r\n\r\n";
            this.btnDateDone.UseVisualStyleBackColor = false;
            this.btnDateDone.Click += new System.EventHandler(this.btnDateDone_Click);
            // 
            // txtDueDate
            // 
            this.txtDueDate.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDueDate.Location = new System.Drawing.Point(840, 134);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(115, 30);
            this.txtDueDate.TabIndex = 28;
            // 
            // DoneBtn
            // 
            this.DoneBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.DoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DoneBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DoneBtn.Location = new System.Drawing.Point(1224, 539);
            this.DoneBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(96, 45);
            this.DoneBtn.TabIndex = 29;
            this.DoneBtn.Text = "完了";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteBtn.BackColor = System.Drawing.Color.White;
            this.DeleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.DeleteBtn.Location = new System.Drawing.Point(1117, 540);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(96, 44);
            this.DeleteBtn.TabIndex = 30;
            this.DeleteBtn.Text = "削除";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 601);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1339, 27);
            this.bindingNavigator1.TabIndex = 31;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 24);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目の総数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "最初に移動";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "前に戻る";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Yu Gothic UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "現在の場所";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "次に移動";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "最後に移動";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 628);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.txtDueDate);
            this.Controls.Add(this.btnDateDone);
            this.Controls.Add(this.btnDateFrom);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.btnDateTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.activeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TaskInformation);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TagLabel);
            this.Controls.Add(this.DueDateLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateTaskBtn);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.tagComboBox);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TaskList";
            this.Text = "タスク一覧";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tagComboBox;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DueDateLabel;
        private System.Windows.Forms.Label TagLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel Re;
        private System.Windows.Forms.ToolStripButton logoutBtn;
        private System.Windows.Forms.DataGridView TaskInformation;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button CreateTaskBtn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox activeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDateTo;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.Button btnDateFrom;
        private System.Windows.Forms.Button btnDateDone;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskNo;
        private System.Windows.Forms.DataGridViewLinkColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updated_On;
        private System.Windows.Forms.DataGridViewTextBoxColumn Is_Active;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCheck;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        public System.Windows.Forms.ToolStripLabel UserId;
    }
}

