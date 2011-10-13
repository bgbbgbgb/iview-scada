namespace Aimirim.iView
{
    partial class SecurityUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityUserControl));
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.splitContainer2 = new System.Windows.Forms.SplitContainer();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.dgvUser = new System.Windows.Forms.DataGridView();
        	this.colNameTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colPassTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colUserIdTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.tsUser = new System.Windows.Forms.ToolStrip();
        	this.tsbUserNew = new System.Windows.Forms.ToolStripButton();
        	this.tsbUserEdit = new System.Windows.Forms.ToolStripButton();
        	this.tsbUserDelete = new System.Windows.Forms.ToolStripButton();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.dgvGroup = new System.Windows.Forms.DataGridView();
        	this.colTextBoxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colTextBoxDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colTbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colTbUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ColumnUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.tsGroup = new System.Windows.Forms.ToolStrip();
        	this.tsbGroupAdd = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.tsbGroupNew = new System.Windows.Forms.ToolStripButton();
        	this.tsbGroupEdit = new System.Windows.Forms.ToolStripButton();
        	this.tsbGroupDelete = new System.Windows.Forms.ToolStripButton();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.dgvRule = new System.Windows.Forms.DataGridView();
        	this.colTbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colTbDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colTbRuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.colTbRuleGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ColumnGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.tsRule = new System.Windows.Forms.ToolStrip();
        	this.tsbRuleAdd = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.tsbRuleNew = new System.Windows.Forms.ToolStripButton();
        	this.tsbRuleEdit = new System.Windows.Forms.ToolStripButton();
        	this.tsbRuleDelete = new System.Windows.Forms.ToolStripButton();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
        	this.splitContainer2.Panel1.SuspendLayout();
        	this.splitContainer2.Panel2.SuspendLayout();
        	this.splitContainer2.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
        	this.tsUser.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
        	this.tsGroup.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRule)).BeginInit();
        	this.tsRule.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
        	this.splitContainer1.Name = "splitContainer1";
        	this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
        	this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
        	this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
        	this.splitContainer1.Size = new System.Drawing.Size(593, 599);
        	this.splitContainer1.SplitterDistance = 312;
        	this.splitContainer1.SplitterWidth = 3;
        	this.splitContainer1.TabIndex = 0;
        	// 
        	// splitContainer2
        	// 
        	this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer2.Location = new System.Drawing.Point(8, 8);
        	this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
        	this.splitContainer2.Name = "splitContainer2";
        	// 
        	// splitContainer2.Panel1
        	// 
        	this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
        	// 
        	// splitContainer2.Panel2
        	// 
        	this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
        	this.splitContainer2.Size = new System.Drawing.Size(577, 300);
        	this.splitContainer2.SplitterDistance = 289;
        	this.splitContainer2.SplitterWidth = 3;
        	this.splitContainer2.TabIndex = 0;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.dgvUser);
        	this.groupBox1.Controls.Add(this.tsUser);
        	this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.groupBox1.Location = new System.Drawing.Point(0, 0);
        	this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
        	this.groupBox1.Size = new System.Drawing.Size(289, 300);
        	this.groupBox1.TabIndex = 1;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Usuário";
        	// 
        	// dgvUser
        	// 
        	this.dgvUser.AllowUserToAddRows = false;
        	this.dgvUser.AllowUserToDeleteRows = false;
        	this.dgvUser.BackgroundColor = System.Drawing.Color.White;
        	this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.colNameTextBox,
        	        	        	this.colPassTextBox,
        	        	        	this.colUserIdTextBox});
        	this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvUser.Location = new System.Drawing.Point(8, 21);
        	this.dgvUser.Margin = new System.Windows.Forms.Padding(2);
        	this.dgvUser.Name = "dgvUser";
        	this.dgvUser.ReadOnly = true;
        	this.dgvUser.RowHeadersVisible = false;
        	this.dgvUser.RowTemplate.Height = 24;
        	this.dgvUser.Size = new System.Drawing.Size(225, 271);
        	this.dgvUser.TabIndex = 3;
        	// 
        	// colNameTextBox
        	// 
        	this.colNameTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.colNameTextBox.DataPropertyName = "Name";
        	this.colNameTextBox.HeaderText = "Nome";
        	this.colNameTextBox.Name = "colNameTextBox";
        	this.colNameTextBox.ReadOnly = true;
        	// 
        	// colPassTextBox
        	// 
        	this.colPassTextBox.DataPropertyName = "Pass";
        	this.colPassTextBox.HeaderText = "Pass";
        	this.colPassTextBox.Name = "colPassTextBox";
        	this.colPassTextBox.ReadOnly = true;
        	this.colPassTextBox.Visible = false;
        	// 
        	// colUserIdTextBox
        	// 
        	this.colUserIdTextBox.DataPropertyName = "Id";
        	this.colUserIdTextBox.HeaderText = "Id";
        	this.colUserIdTextBox.Name = "colUserIdTextBox";
        	this.colUserIdTextBox.ReadOnly = true;
        	this.colUserIdTextBox.Visible = false;
        	// 
        	// tsUser
        	// 
        	this.tsUser.Dock = System.Windows.Forms.DockStyle.Right;
        	this.tsUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.tsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsbUserNew,
        	        	        	this.tsbUserEdit,
        	        	        	this.tsbUserDelete});
        	this.tsUser.Location = new System.Drawing.Point(233, 21);
        	this.tsUser.Name = "tsUser";
        	this.tsUser.Size = new System.Drawing.Size(48, 271);
        	this.tsUser.TabIndex = 2;
        	this.tsUser.Text = "toolStrip1";
        	// 
        	// tsbUserNew
        	// 
        	this.tsbUserNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbUserNew.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbUserNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbUserNew.Image")));
        	this.tsbUserNew.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbUserNew.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbUserNew.Name = "tsbUserNew";
        	this.tsbUserNew.Size = new System.Drawing.Size(45, 17);
        	this.tsbUserNew.Text = "Novo";
        	this.tsbUserNew.Click += new System.EventHandler(this.TsbUserNewClick);
        	// 
        	// tsbUserEdit
        	// 
        	this.tsbUserEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbUserEdit.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbUserEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbUserEdit.Image")));
        	this.tsbUserEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbUserEdit.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbUserEdit.Name = "tsbUserEdit";
        	this.tsbUserEdit.Size = new System.Drawing.Size(45, 17);
        	this.tsbUserEdit.Text = "Altera";
        	this.tsbUserEdit.Click += new System.EventHandler(this.TsbUserEditClick);
        	// 
        	// tsbUserDelete
        	// 
        	this.tsbUserDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbUserDelete.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbUserDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbUserDelete.Image")));
        	this.tsbUserDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbUserDelete.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbUserDelete.Name = "tsbUserDelete";
        	this.tsbUserDelete.Size = new System.Drawing.Size(45, 17);
        	this.tsbUserDelete.Text = "Apaga";
        	this.tsbUserDelete.Click += new System.EventHandler(this.TsbUserDeleteClick);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.dgvGroup);
        	this.groupBox2.Controls.Add(this.tsGroup);
        	this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.groupBox2.Location = new System.Drawing.Point(0, 0);
        	this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
        	this.groupBox2.Size = new System.Drawing.Size(285, 300);
        	this.groupBox2.TabIndex = 0;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Grupo";
        	// 
        	// dgvGroup
        	// 
        	this.dgvGroup.AllowUserToAddRows = false;
        	this.dgvGroup.AllowUserToDeleteRows = false;
        	this.dgvGroup.BackgroundColor = System.Drawing.Color.White;
        	this.dgvGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.colTextBoxName,
        	        	        	this.colTextBoxDescription,
        	        	        	this.colTbId,
        	        	        	this.colTbUserId,
        	        	        	this.ColumnUserName});
        	this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvGroup.Location = new System.Drawing.Point(8, 21);
        	this.dgvGroup.Margin = new System.Windows.Forms.Padding(2);
        	this.dgvGroup.Name = "dgvGroup";
        	this.dgvGroup.ReadOnly = true;
        	this.dgvGroup.RowHeadersVisible = false;
        	this.dgvGroup.RowTemplate.Height = 24;
        	this.dgvGroup.Size = new System.Drawing.Size(204, 271);
        	this.dgvGroup.TabIndex = 3;
        	// 
        	// colTextBoxName
        	// 
        	this.colTextBoxName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.colTextBoxName.DataPropertyName = "Name";
        	this.colTextBoxName.HeaderText = "Name";
        	this.colTextBoxName.Name = "colTextBoxName";
        	this.colTextBoxName.ReadOnly = true;
        	// 
        	// colTextBoxDescription
        	// 
        	this.colTextBoxDescription.DataPropertyName = "Description";
        	this.colTextBoxDescription.HeaderText = "Description";
        	this.colTextBoxDescription.Name = "colTextBoxDescription";
        	this.colTextBoxDescription.ReadOnly = true;
        	this.colTextBoxDescription.Visible = false;
        	// 
        	// colTbId
        	// 
        	this.colTbId.DataPropertyName = "Id";
        	this.colTbId.HeaderText = "Id";
        	this.colTbId.Name = "colTbId";
        	this.colTbId.ReadOnly = true;
        	this.colTbId.Visible = false;
        	// 
        	// colTbUserId
        	// 
        	this.colTbUserId.DataPropertyName = "UserId";
        	this.colTbUserId.HeaderText = "UserId";
        	this.colTbUserId.Name = "colTbUserId";
        	this.colTbUserId.ReadOnly = true;
        	this.colTbUserId.Visible = false;
        	// 
        	// ColumnUserName
        	// 
        	this.ColumnUserName.DataPropertyName = "UserName";
        	this.ColumnUserName.HeaderText = "UserName";
        	this.ColumnUserName.Name = "ColumnUserName";
        	this.ColumnUserName.ReadOnly = true;
        	this.ColumnUserName.Visible = false;
        	// 
        	// tsGroup
        	// 
        	this.tsGroup.Dock = System.Windows.Forms.DockStyle.Right;
        	this.tsGroup.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.tsGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsbGroupAdd,
        	        	        	this.toolStripSeparator1,
        	        	        	this.tsbGroupNew,
        	        	        	this.tsbGroupEdit,
        	        	        	this.tsbGroupDelete});
        	this.tsGroup.Location = new System.Drawing.Point(212, 21);
        	this.tsGroup.Name = "tsGroup";
        	this.tsGroup.Size = new System.Drawing.Size(65, 271);
        	this.tsGroup.TabIndex = 2;
        	this.tsGroup.Text = "toolStrip2";
        	// 
        	// tsbGroupAdd
        	// 
        	this.tsbGroupAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbGroupAdd.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbGroupAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbGroupAdd.Image")));
        	this.tsbGroupAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbGroupAdd.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbGroupAdd.Name = "tsbGroupAdd";
        	this.tsbGroupAdd.Size = new System.Drawing.Size(62, 17);
        	this.tsbGroupAdd.Text = "Adicionar";
        	this.tsbGroupAdd.Click += new System.EventHandler(this.TsbGroupAddClick);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10);
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(5);
        	this.toolStripSeparator1.Size = new System.Drawing.Size(42, 6);
        	// 
        	// tsbGroupNew
        	// 
        	this.tsbGroupNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbGroupNew.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbGroupNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbGroupNew.Image")));
        	this.tsbGroupNew.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbGroupNew.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbGroupNew.Name = "tsbGroupNew";
        	this.tsbGroupNew.Size = new System.Drawing.Size(62, 17);
        	this.tsbGroupNew.Text = "Novo";
        	this.tsbGroupNew.Click += new System.EventHandler(this.TsbGroupNewClick);
        	// 
        	// tsbGroupEdit
        	// 
        	this.tsbGroupEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbGroupEdit.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbGroupEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbGroupEdit.Image")));
        	this.tsbGroupEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbGroupEdit.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbGroupEdit.Name = "tsbGroupEdit";
        	this.tsbGroupEdit.Size = new System.Drawing.Size(62, 17);
        	this.tsbGroupEdit.Text = "Altera";
        	this.tsbGroupEdit.Click += new System.EventHandler(this.TsbGroupEditClick);
        	// 
        	// tsbGroupDelete
        	// 
        	this.tsbGroupDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbGroupDelete.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbGroupDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbGroupDelete.Image")));
        	this.tsbGroupDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbGroupDelete.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbGroupDelete.Name = "tsbGroupDelete";
        	this.tsbGroupDelete.Size = new System.Drawing.Size(62, 17);
        	this.tsbGroupDelete.Text = "Apaga";
        	this.tsbGroupDelete.Click += new System.EventHandler(this.TsbGroupDeleteClick);
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.dgvRule);
        	this.groupBox3.Controls.Add(this.tsRule);
        	this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.groupBox3.Location = new System.Drawing.Point(8, 4);
        	this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Padding = new System.Windows.Forms.Padding(8);
        	this.groupBox3.Size = new System.Drawing.Size(577, 272);
        	this.groupBox3.TabIndex = 0;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "Premissão";
        	// 
        	// dgvRule
        	// 
        	this.dgvRule.AllowUserToAddRows = false;
        	this.dgvRule.AllowUserToDeleteRows = false;
        	this.dgvRule.BackgroundColor = System.Drawing.Color.White;
        	this.dgvRule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.dgvRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvRule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.colTbName,
        	        	        	this.colTbDescription,
        	        	        	this.colTbRuleId,
        	        	        	this.colTbRuleGroupId,
        	        	        	this.ColumnGroupName});
        	this.dgvRule.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvRule.Location = new System.Drawing.Point(8, 21);
        	this.dgvRule.Margin = new System.Windows.Forms.Padding(2);
        	this.dgvRule.Name = "dgvRule";
        	this.dgvRule.ReadOnly = true;
        	this.dgvRule.RowHeadersVisible = false;
        	this.dgvRule.RowTemplate.Height = 24;
        	this.dgvRule.Size = new System.Drawing.Size(496, 243);
        	this.dgvRule.TabIndex = 5;
        	// 
        	// colTbName
        	// 
        	this.colTbName.DataPropertyName = "Name";
        	this.colTbName.HeaderText = "Name";
        	this.colTbName.Name = "colTbName";
        	this.colTbName.ReadOnly = true;
        	this.colTbName.Width = 200;
        	// 
        	// colTbDescription
        	// 
        	this.colTbDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.colTbDescription.DataPropertyName = "Description";
        	this.colTbDescription.HeaderText = "Description";
        	this.colTbDescription.Name = "colTbDescription";
        	this.colTbDescription.ReadOnly = true;
        	// 
        	// colTbRuleId
        	// 
        	this.colTbRuleId.DataPropertyName = "Id";
        	this.colTbRuleId.HeaderText = "Id";
        	this.colTbRuleId.Name = "colTbRuleId";
        	this.colTbRuleId.ReadOnly = true;
        	this.colTbRuleId.Visible = false;
        	// 
        	// colTbRuleGroupId
        	// 
        	this.colTbRuleGroupId.DataPropertyName = "GroupId";
        	this.colTbRuleGroupId.HeaderText = "GroupId";
        	this.colTbRuleGroupId.Name = "colTbRuleGroupId";
        	this.colTbRuleGroupId.ReadOnly = true;
        	this.colTbRuleGroupId.Visible = false;
        	// 
        	// ColumnGroupName
        	// 
        	this.ColumnGroupName.DataPropertyName = "GroupName";
        	this.ColumnGroupName.HeaderText = "GroupName";
        	this.ColumnGroupName.Name = "ColumnGroupName";
        	this.ColumnGroupName.ReadOnly = true;
        	this.ColumnGroupName.Visible = false;
        	// 
        	// tsRule
        	// 
        	this.tsRule.Dock = System.Windows.Forms.DockStyle.Right;
        	this.tsRule.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.tsRule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tsbRuleAdd,
        	        	        	this.toolStripSeparator2,
        	        	        	this.tsbRuleNew,
        	        	        	this.tsbRuleEdit,
        	        	        	this.tsbRuleDelete});
        	this.tsRule.Location = new System.Drawing.Point(504, 21);
        	this.tsRule.Name = "tsRule";
        	this.tsRule.Size = new System.Drawing.Size(65, 243);
        	this.tsRule.TabIndex = 4;
        	this.tsRule.Text = "toolStrip3";
        	// 
        	// tsbRuleAdd
        	// 
        	this.tsbRuleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbRuleAdd.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbRuleAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbRuleAdd.Image")));
        	this.tsbRuleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbRuleAdd.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbRuleAdd.Name = "tsbRuleAdd";
        	this.tsbRuleAdd.Size = new System.Drawing.Size(62, 17);
        	this.tsbRuleAdd.Text = "Adicionar";
        	this.tsbRuleAdd.Click += new System.EventHandler(this.TsbRuleAddClick);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(10);
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(5);
        	this.toolStripSeparator2.Size = new System.Drawing.Size(42, 6);
        	// 
        	// tsbRuleNew
        	// 
        	this.tsbRuleNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbRuleNew.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbRuleNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbRuleNew.Image")));
        	this.tsbRuleNew.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbRuleNew.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbRuleNew.Name = "tsbRuleNew";
        	this.tsbRuleNew.Size = new System.Drawing.Size(62, 17);
        	this.tsbRuleNew.Text = "Novo";
        	this.tsbRuleNew.Click += new System.EventHandler(this.TsbRuleNewClick);
        	// 
        	// tsbRuleEdit
        	// 
        	this.tsbRuleEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbRuleEdit.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbRuleEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbRuleEdit.Image")));
        	this.tsbRuleEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbRuleEdit.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbRuleEdit.Name = "tsbRuleEdit";
        	this.tsbRuleEdit.Size = new System.Drawing.Size(62, 17);
        	this.tsbRuleEdit.Text = "Altera";
        	this.tsbRuleEdit.Click += new System.EventHandler(this.TsbRuleEditClick);
        	// 
        	// tsbRuleDelete
        	// 
        	this.tsbRuleDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.tsbRuleDelete.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tsbRuleDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbRuleDelete.Image")));
        	this.tsbRuleDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.tsbRuleDelete.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
        	this.tsbRuleDelete.Name = "tsbRuleDelete";
        	this.tsbRuleDelete.Size = new System.Drawing.Size(62, 17);
        	this.tsbRuleDelete.Text = "Apaga";
        	this.tsbRuleDelete.Click += new System.EventHandler(this.TsbRuleDeleteClick);
        	// 
        	// SecurityUserControl
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.splitContainer1);
        	this.Margin = new System.Windows.Forms.Padding(2);
        	this.Name = "SecurityUserControl";
        	this.Size = new System.Drawing.Size(593, 599);
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	this.splitContainer2.Panel1.ResumeLayout(false);
        	this.splitContainer2.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
        	this.splitContainer2.ResumeLayout(false);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
        	this.tsUser.ResumeLayout(false);
        	this.tsUser.PerformLayout();
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
        	this.tsGroup.ResumeLayout(false);
        	this.tsGroup.PerformLayout();
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox3.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvRule)).EndInit();
        	this.tsRule.ResumeLayout(false);
        	this.tsRule.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserName;
        private System.Windows.Forms.ToolStrip tsUser;
        private System.Windows.Forms.ToolStrip tsGroup;
        private System.Windows.Forms.ToolStrip tsRule;
        private System.Windows.Forms.ToolStripButton tsbRuleDelete;
        private System.Windows.Forms.ToolStripButton tsbRuleEdit;
        private System.Windows.Forms.ToolStripButton tsbRuleNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRuleAdd;
        private System.Windows.Forms.ToolStripButton tsbGroupNew;
        private System.Windows.Forms.ToolStripButton tsbGroupEdit;
        private System.Windows.Forms.ToolStripButton tsbGroupDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbGroupAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserIdTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTbRuleGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTbRuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTbUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTbId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTbDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTextBoxDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTextBoxName;
        private System.Windows.Forms.ToolStripButton tsbUserEdit;
        private System.Windows.Forms.ToolStripButton tsbUserDelete;
        private System.Windows.Forms.ToolStripButton tsbUserNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameTextBox;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.DataGridView dgvRule;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion


    }
}
