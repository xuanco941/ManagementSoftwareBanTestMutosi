using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    partial class ActivityHistory
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityHistory));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewActivity = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCustomGoPage = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.inputNumPageGo = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.buttonPageNext = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage3 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage1 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage2 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonCallFormEmployeeActivities = new System.Windows.Forms.Button();
            this.btnChangeNumElmPage = new System.Windows.Forms.Button();
            this.buttonDeleteDataActivity = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoc = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.dateTimePickerTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerToiNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.labelToiNgay = new System.Windows.Forms.Label();
            this.labelBanGhiMoiTrang = new System.Windows.Forms.Label();
            this.labelTuNgay = new System.Windows.Forms.Label();
            this.labelTongSoTrang = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivity)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 514);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 508);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewActivity);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 450);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewActivity
            // 
            this.dataGridViewActivity.AllowUserToAddRows = false;
            this.dataGridViewActivity.AllowUserToDeleteRows = false;
            this.dataGridViewActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActivity.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewActivity.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewActivity.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewActivity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewActivity.Name = "dataGridViewActivity";
            this.dataGridViewActivity.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActivity.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewActivity.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewActivity.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewActivity.RowTemplate.Height = 25;
            this.dataGridViewActivity.Size = new System.Drawing.Size(706, 450);
            this.dataGridViewActivity.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCustomGoPage);
            this.panel2.Controls.Add(this.inputNumPageGo);
            this.panel2.Controls.Add(this.buttonPageNext);
            this.panel2.Controls.Add(this.buttonPage3);
            this.panel2.Controls.Add(this.buttonPage1);
            this.panel2.Controls.Add(this.buttonPage2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 450);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(706, 58);
            this.panel2.TabIndex = 0;
            // 
            // buttonCustomGoPage
            // 
            this.buttonCustomGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCustomGoPage.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonCustomGoPage.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.buttonCustomGoPage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonCustomGoPage.BorderRadius = 3;
            this.buttonCustomGoPage.BorderSize = 0;
            this.buttonCustomGoPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustomGoPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomGoPage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCustomGoPage.ForeColor = System.Drawing.Color.Black;
            this.buttonCustomGoPage.Image = ((System.Drawing.Image)(resources.GetObject("buttonCustomGoPage.Image")));
            this.buttonCustomGoPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCustomGoPage.Location = new System.Drawing.Point(613, 12);
            this.buttonCustomGoPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCustomGoPage.Name = "buttonCustomGoPage";
            this.buttonCustomGoPage.Size = new System.Drawing.Size(93, 35);
            this.buttonCustomGoPage.TabIndex = 33;
            this.buttonCustomGoPage.Text = "Đi";
            this.buttonCustomGoPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCustomGoPage.TextColor = System.Drawing.Color.Black;
            this.buttonCustomGoPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCustomGoPage.UseVisualStyleBackColor = false;
            this.buttonCustomGoPage.Click += new System.EventHandler(this.buttonCustomGoPage_Click);
            // 
            // inputNumPageGo
            // 
            this.inputNumPageGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputNumPageGo.BeforeTouchSize = new System.Drawing.Size(66, 35);
            this.inputNumPageGo.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.inputNumPageGo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputNumPageGo.IntegerValue = ((long)(1));
            this.inputNumPageGo.Location = new System.Drawing.Point(543, 14);
            this.inputNumPageGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputNumPageGo.Multiline = true;
            this.inputNumPageGo.Name = "inputNumPageGo";
            this.inputNumPageGo.Size = new System.Drawing.Size(66, 35);
            this.inputNumPageGo.TabIndex = 32;
            this.inputNumPageGo.Text = "1";
            this.inputNumPageGo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonPageNext
            // 
            this.buttonPageNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPageNext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPageNext.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPageNext.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonPageNext.BorderRadius = 3;
            this.buttonPageNext.BorderSize = 0;
            this.buttonPageNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPageNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPageNext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPageNext.ForeColor = System.Drawing.Color.Black;
            this.buttonPageNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPageNext.Location = new System.Drawing.Point(240, 12);
            this.buttonPageNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPageNext.Name = "buttonPageNext";
            this.buttonPageNext.Size = new System.Drawing.Size(74, 35);
            this.buttonPageNext.TabIndex = 28;
            this.buttonPageNext.Text = ">>";
            this.buttonPageNext.TextColor = System.Drawing.Color.Black;
            this.buttonPageNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPageNext.UseVisualStyleBackColor = false;
            this.buttonPageNext.Click += new System.EventHandler(this.buttonPageNext_Click);
            // 
            // buttonPage3
            // 
            this.buttonPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPage3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage3.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonPage3.BorderRadius = 3;
            this.buttonPage3.BorderSize = 0;
            this.buttonPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPage3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPage3.ForeColor = System.Drawing.Color.Black;
            this.buttonPage3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPage3.Location = new System.Drawing.Point(160, 12);
            this.buttonPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage3.Name = "buttonPage3";
            this.buttonPage3.Size = new System.Drawing.Size(74, 35);
            this.buttonPage3.TabIndex = 27;
            this.buttonPage3.Text = "3";
            this.buttonPage3.TextColor = System.Drawing.Color.Black;
            this.buttonPage3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage3.UseVisualStyleBackColor = false;
            this.buttonPage3.Click += new System.EventHandler(this.buttonPage1_Click);
            // 
            // buttonPage1
            // 
            this.buttonPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonPage1.BorderRadius = 3;
            this.buttonPage1.BorderSize = 0;
            this.buttonPage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPage1.ForeColor = System.Drawing.Color.Black;
            this.buttonPage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPage1.Location = new System.Drawing.Point(0, 12);
            this.buttonPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage1.Name = "buttonPage1";
            this.buttonPage1.Size = new System.Drawing.Size(74, 35);
            this.buttonPage1.TabIndex = 26;
            this.buttonPage1.Text = "1";
            this.buttonPage1.TextColor = System.Drawing.Color.Black;
            this.buttonPage1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage1.UseVisualStyleBackColor = false;
            this.buttonPage1.Click += new System.EventHandler(this.buttonPage1_Click);
            // 
            // buttonPage2
            // 
            this.buttonPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonPage2.BorderRadius = 3;
            this.buttonPage2.BorderSize = 0;
            this.buttonPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPage2.ForeColor = System.Drawing.Color.Black;
            this.buttonPage2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPage2.Location = new System.Drawing.Point(79, 12);
            this.buttonPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage2.Name = "buttonPage2";
            this.buttonPage2.Size = new System.Drawing.Size(74, 35);
            this.buttonPage2.TabIndex = 25;
            this.buttonPage2.Text = "2";
            this.buttonPage2.TextColor = System.Drawing.Color.Black;
            this.buttonPage2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage2.UseVisualStyleBackColor = false;
            this.buttonPage2.Click += new System.EventHandler(this.buttonPage1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonCallFormEmployeeActivities);
            this.panel4.Controls.Add(this.btnChangeNumElmPage);
            this.panel4.Controls.Add(this.buttonDeleteDataActivity);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(718, 3);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 508);
            this.panel4.TabIndex = 1;
            // 
            // buttonCallFormEmployeeActivities
            // 
            this.buttonCallFormEmployeeActivities.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCallFormEmployeeActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCallFormEmployeeActivities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonCallFormEmployeeActivities.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCallFormEmployeeActivities.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonCallFormEmployeeActivities.Image = ((System.Drawing.Image)(resources.GetObject("buttonCallFormEmployeeActivities.Image")));
            this.buttonCallFormEmployeeActivities.Location = new System.Drawing.Point(0, 222);
            this.buttonCallFormEmployeeActivities.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCallFormEmployeeActivities.Name = "buttonCallFormEmployeeActivities";
            this.buttonCallFormEmployeeActivities.Size = new System.Drawing.Size(242, 51);
            this.buttonCallFormEmployeeActivities.TabIndex = 20;
            this.buttonCallFormEmployeeActivities.Text = "Hoạt động thành viên";
            this.buttonCallFormEmployeeActivities.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCallFormEmployeeActivities.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCallFormEmployeeActivities.UseVisualStyleBackColor = false;
            this.buttonCallFormEmployeeActivities.Click += new System.EventHandler(this.buttonCallFormEmployeeActivities_Click);
            // 
            // btnChangeNumElmPage
            // 
            this.btnChangeNumElmPage.BackColor = System.Drawing.SystemColors.Control;
            this.btnChangeNumElmPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeNumElmPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChangeNumElmPage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangeNumElmPage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnChangeNumElmPage.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeNumElmPage.Image")));
            this.btnChangeNumElmPage.Location = new System.Drawing.Point(0, 273);
            this.btnChangeNumElmPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnChangeNumElmPage.Name = "btnChangeNumElmPage";
            this.btnChangeNumElmPage.Size = new System.Drawing.Size(242, 51);
            this.btnChangeNumElmPage.TabIndex = 16;
            this.btnChangeNumElmPage.Text = "Thay đổi số dòng hiển thị";
            this.btnChangeNumElmPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeNumElmPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeNumElmPage.UseVisualStyleBackColor = false;
            this.btnChangeNumElmPage.Click += new System.EventHandler(this.btnChangeNumElmPage_Click);
            // 
            // buttonDeleteDataActivity
            // 
            this.buttonDeleteDataActivity.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteDataActivity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteDataActivity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDeleteDataActivity.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteDataActivity.ForeColor = System.Drawing.Color.Crimson;
            this.buttonDeleteDataActivity.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteDataActivity.Image")));
            this.buttonDeleteDataActivity.Location = new System.Drawing.Point(0, 324);
            this.buttonDeleteDataActivity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonDeleteDataActivity.Name = "buttonDeleteDataActivity";
            this.buttonDeleteDataActivity.Size = new System.Drawing.Size(242, 51);
            this.buttonDeleteDataActivity.TabIndex = 21;
            this.buttonDeleteDataActivity.Text = "Xóa dữ liệu trang này";
            this.buttonDeleteDataActivity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDeleteDataActivity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDeleteDataActivity.UseVisualStyleBackColor = false;
            this.buttonDeleteDataActivity.Click += new System.EventHandler(this.buttonDeleteDataActivity_Click);
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.buttonLoc);
            this.panel5.Controls.Add(this.dateTimePickerTuNgay);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.dateTimePickerToiNgay);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(242, 375);
            this.panel5.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(242, 43);
            this.panel6.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 43);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lọc dữ liệu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLoc
            // 
            this.buttonLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoc.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLoc.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.buttonLoc.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonLoc.BorderRadius = 3;
            this.buttonLoc.BorderSize = 0;
            this.buttonLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLoc.ForeColor = System.Drawing.Color.Black;
            this.buttonLoc.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoc.Image")));
            this.buttonLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoc.Location = new System.Drawing.Point(65, 148);
            this.buttonLoc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonLoc.Name = "buttonLoc";
            this.buttonLoc.Size = new System.Drawing.Size(97, 38);
            this.buttonLoc.TabIndex = 19;
            this.buttonLoc.Text = "Lọc";
            this.buttonLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoc.TextColor = System.Drawing.Color.Black;
            this.buttonLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLoc.UseVisualStyleBackColor = false;
            this.buttonLoc.Click += new System.EventHandler(this.buttonLoc_Click);
            // 
            // dateTimePickerTuNgay
            // 
            this.dateTimePickerTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTuNgay.Location = new System.Drawing.Point(79, 75);
            this.dateTimePickerTuNgay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePickerTuNgay.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTuNgay.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            this.dateTimePickerTuNgay.Size = new System.Drawing.Size(144, 25);
            this.dateTimePickerTuNgay.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ ngày :";
            // 
            // dateTimePickerToiNgay
            // 
            this.dateTimePickerToiNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerToiNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePickerToiNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerToiNgay.Location = new System.Drawing.Point(79, 108);
            this.dateTimePickerToiNgay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePickerToiNgay.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerToiNgay.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerToiNgay.Name = "dateTimePickerToiNgay";
            this.dateTimePickerToiNgay.Size = new System.Drawing.Size(144, 25);
            this.dateTimePickerToiNgay.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tới ngày :";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.groupBox3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 375);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(242, 133);
            this.panel7.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelPage);
            this.groupBox3.Controls.Add(this.labelToiNgay);
            this.groupBox3.Controls.Add(this.labelBanGhiMoiTrang);
            this.groupBox3.Controls.Add(this.labelTuNgay);
            this.groupBox3.Controls.Add(this.labelTongSoTrang);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(242, 133);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin trang";
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPage.Location = new System.Drawing.Point(8, 63);
            this.labelPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(88, 15);
            this.labelPage.TabIndex = 4;
            this.labelPage.Text = "- Đang ở trang:";
            // 
            // labelToiNgay
            // 
            this.labelToiNgay.AutoSize = true;
            this.labelToiNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelToiNgay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelToiNgay.Location = new System.Drawing.Point(8, 43);
            this.labelToiNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelToiNgay.Name = "labelToiNgay";
            this.labelToiNgay.Size = new System.Drawing.Size(83, 15);
            this.labelToiNgay.TabIndex = 3;
            this.labelToiNgay.Text = "- Lọc tới ngày:";
            // 
            // labelBanGhiMoiTrang
            // 
            this.labelBanGhiMoiTrang.AutoSize = true;
            this.labelBanGhiMoiTrang.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelBanGhiMoiTrang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelBanGhiMoiTrang.Location = new System.Drawing.Point(8, 84);
            this.labelBanGhiMoiTrang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBanGhiMoiTrang.Name = "labelBanGhiMoiTrang";
            this.labelBanGhiMoiTrang.Size = new System.Drawing.Size(113, 15);
            this.labelBanGhiMoiTrang.TabIndex = 3;
            this.labelBanGhiMoiTrang.Text = "- Bản ghi mỗi trang:";
            // 
            // labelTuNgay
            // 
            this.labelTuNgay.AutoSize = true;
            this.labelTuNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTuNgay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTuNgay.Location = new System.Drawing.Point(8, 22);
            this.labelTuNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTuNgay.Name = "labelTuNgay";
            this.labelTuNgay.Size = new System.Drawing.Size(80, 15);
            this.labelTuNgay.TabIndex = 1;
            this.labelTuNgay.Text = "- Lọc từ ngày:";
            // 
            // labelTongSoTrang
            // 
            this.labelTongSoTrang.AutoSize = true;
            this.labelTongSoTrang.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTongSoTrang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTongSoTrang.Location = new System.Drawing.Point(8, 105);
            this.labelTongSoTrang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTongSoTrang.Name = "labelTongSoTrang";
            this.labelTongSoTrang.Size = new System.Drawing.Size(92, 15);
            this.labelTongSoTrang.TabIndex = 1;
            this.labelTongSoTrang.Text = "- Tổng số trang:";
            // 
            // ActivityHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(964, 514);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ActivityHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoạt động";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivity)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPageNext;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage3;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage1;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage2;
        private Panel panel7;
        private GroupBox groupBox3;
        private Label labelToiNgay;
        private Label labelTuNgay;
        private Label labelPage;
        private Label labelBanGhiMoiTrang;
        private Label labelTongSoTrang;
        private DataGridView dataGridViewActivity;
        private Panel panel5;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonLoc;
        private DateTimePicker dateTimePickerTuNgay;
        private Label label2;
        private DateTimePicker dateTimePickerToiNgay;
        private Label label3;
        private Button buttonCallFormEmployeeActivities;
        private Button btnChangeNumElmPage;
        private Button buttonDeleteDataActivity;
        private Panel panel6;
        private Label label1;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox inputNumPageGo;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustomGoPage;
    }
}