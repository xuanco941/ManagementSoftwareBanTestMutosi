namespace ManagementSoftware.GUI
{
    partial class Nguon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nguon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGiamSat1 = new System.Windows.Forms.TabPage();
            this.tabPageGiamSat2 = new System.Windows.Forms.TabPage();
            this.tabPageThongKe = new System.Windows.Forms.TabPage();
            this.panelThongKe = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.panel392 = new System.Windows.Forms.Panel();
            this.label181 = new System.Windows.Forms.Label();
            this.panel393 = new System.Windows.Forms.Panel();
            this.lbTotalPages = new System.Windows.Forms.Label();
            this.panel394 = new System.Windows.Forms.Panel();
            this.buttonGoto = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.pageNumberGoto = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.panel395 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            this.panel396 = new System.Windows.Forms.Panel();
            this.TimeEnd = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.panel397 = new System.Windows.Forms.Panel();
            this.TimeStart = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.panel398 = new System.Windows.Forms.Panel();
            this.label183 = new System.Windows.Forms.Label();
            this.panel399 = new System.Windows.Forms.Panel();
            this.label184 = new System.Windows.Forms.Label();
            this.buttonSearch = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.panel400 = new System.Windows.Forms.Panel();
            this.buttonPage = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonNextPage = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPreviousPage = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonCustomGoPage = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.inputNumPageGo = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageThongKe.SuspendLayout();
            this.panelThongKe.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tableLayoutPanel32.SuspendLayout();
            this.panel392.SuspendLayout();
            this.panel393.SuspendLayout();
            this.panel394.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberGoto)).BeginInit();
            this.panel395.SuspendLayout();
            this.tableLayoutPanel33.SuspendLayout();
            this.panel396.SuspendLayout();
            this.panel397.SuspendLayout();
            this.panel398.SuspendLayout();
            this.panel399.SuspendLayout();
            this.panel400.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGiamSat1);
            this.tabControl1.Controls.Add(this.tabPageGiamSat2);
            this.tabControl1.Controls.Add(this.tabPageThongKe);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1057, 478);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected_1);
            // 
            // tabPageGiamSat1
            // 
            this.tabPageGiamSat1.Location = new System.Drawing.Point(4, 34);
            this.tabPageGiamSat1.Name = "tabPageGiamSat1";
            this.tabPageGiamSat1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGiamSat1.Size = new System.Drawing.Size(1049, 440);
            this.tabPageGiamSat1.TabIndex = 2;
            this.tabPageGiamSat1.Text = "Giám sát Nguồn 1-15";
            this.tabPageGiamSat1.UseVisualStyleBackColor = true;
            // 
            // tabPageGiamSat2
            // 
            this.tabPageGiamSat2.AutoScroll = true;
            this.tabPageGiamSat2.Location = new System.Drawing.Point(4, 34);
            this.tabPageGiamSat2.Name = "tabPageGiamSat2";
            this.tabPageGiamSat2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGiamSat2.Size = new System.Drawing.Size(1049, 440);
            this.tabPageGiamSat2.TabIndex = 0;
            this.tabPageGiamSat2.Text = "Giám sát Nguồn 16-30";
            this.tabPageGiamSat2.UseVisualStyleBackColor = true;
            // 
            // tabPageThongKe
            // 
            this.tabPageThongKe.Controls.Add(this.panelThongKe);
            this.tabPageThongKe.Controls.Add(this.panel2);
            this.tabPageThongKe.Location = new System.Drawing.Point(4, 34);
            this.tabPageThongKe.Name = "tabPageThongKe";
            this.tabPageThongKe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThongKe.Size = new System.Drawing.Size(1049, 440);
            this.tabPageThongKe.TabIndex = 1;
            this.tabPageThongKe.Text = "Thống kê";
            this.tabPageThongKe.UseVisualStyleBackColor = true;
            // 
            // panelThongKe
            // 
            this.panelThongKe.AutoScroll = true;
            this.panelThongKe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongKe.Controls.Add(this.dataGridView1);
            this.panelThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelThongKe.Location = new System.Drawing.Point(3, 3);
            this.panelThongKe.Name = "panelThongKe";
            this.panelThongKe.Size = new System.Drawing.Size(1043, 374);
            this.panelThongKe.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableLayoutPanel31);
            this.panel2.Controls.Add(this.buttonCustomGoPage);
            this.panel2.Controls.Add(this.inputNumPageGo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 377);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 60);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.ColumnCount = 4;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel31.Controls.Add(this.tableLayoutPanel32, 1, 0);
            this.tableLayoutPanel31.Controls.Add(this.panel394, 3, 0);
            this.tableLayoutPanel31.Controls.Add(this.panel395, 2, 0);
            this.tableLayoutPanel31.Controls.Add(this.panel400, 0, 0);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 1;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(1041, 58);
            this.tableLayoutPanel31.TabIndex = 35;
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.ColumnCount = 1;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.Controls.Add(this.panel392, 0, 0);
            this.tableLayoutPanel32.Controls.Add(this.panel393, 0, 1);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(232, 3);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 2;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel32.Size = new System.Drawing.Size(98, 52);
            this.tableLayoutPanel32.TabIndex = 4;
            // 
            // panel392
            // 
            this.panel392.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel392.Controls.Add(this.label181);
            this.panel392.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel392.Location = new System.Drawing.Point(3, 3);
            this.panel392.Name = "panel392";
            this.panel392.Size = new System.Drawing.Size(92, 14);
            this.panel392.TabIndex = 0;
            // 
            // label181
            // 
            this.label181.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label181.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label181.ForeColor = System.Drawing.Color.SkyBlue;
            this.label181.Location = new System.Drawing.Point(0, 0);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(90, 12);
            this.label181.TabIndex = 4;
            this.label181.Text = "Tổng trang";
            this.label181.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel393
            // 
            this.panel393.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel393.Controls.Add(this.lbTotalPages);
            this.panel393.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel393.Location = new System.Drawing.Point(3, 23);
            this.panel393.Name = "panel393";
            this.panel393.Size = new System.Drawing.Size(92, 26);
            this.panel393.TabIndex = 1;
            // 
            // lbTotalPages
            // 
            this.lbTotalPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotalPages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTotalPages.ForeColor = System.Drawing.Color.SpringGreen;
            this.lbTotalPages.Location = new System.Drawing.Point(0, 0);
            this.lbTotalPages.Name = "lbTotalPages";
            this.lbTotalPages.Size = new System.Drawing.Size(90, 24);
            this.lbTotalPages.TabIndex = 5;
            this.lbTotalPages.Text = "1";
            this.lbTotalPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel394
            // 
            this.panel394.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel394.Controls.Add(this.buttonGoto);
            this.panel394.Controls.Add(this.pageNumberGoto);
            this.panel394.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel394.Location = new System.Drawing.Point(887, 3);
            this.panel394.Name = "panel394";
            this.panel394.Size = new System.Drawing.Size(151, 52);
            this.panel394.TabIndex = 2;
            // 
            // buttonGoto
            // 
            this.buttonGoto.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonGoto.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.buttonGoto.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonGoto.BorderRadius = 3;
            this.buttonGoto.BorderSize = 0;
            this.buttonGoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGoto.ForeColor = System.Drawing.Color.Black;
            this.buttonGoto.Image = ((System.Drawing.Image)(resources.GetObject("buttonGoto.Image")));
            this.buttonGoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGoto.Location = new System.Drawing.Point(0, 25);
            this.buttonGoto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonGoto.Name = "buttonGoto";
            this.buttonGoto.Size = new System.Drawing.Size(149, 25);
            this.buttonGoto.TabIndex = 34;
            this.buttonGoto.Text = "Tới trang";
            this.buttonGoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGoto.TextColor = System.Drawing.Color.Black;
            this.buttonGoto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonGoto.UseVisualStyleBackColor = false;
            this.buttonGoto.Click += new System.EventHandler(this.buttonGoto_Click);
            // 
            // pageNumberGoto
            // 
            this.pageNumberGoto.BeforeTouchSize = new System.Drawing.Size(66, 35);
            this.pageNumberGoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageNumberGoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageNumberGoto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pageNumberGoto.IntegerValue = ((long)(1));
            this.pageNumberGoto.Location = new System.Drawing.Point(0, 0);
            this.pageNumberGoto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pageNumberGoto.Name = "pageNumberGoto";
            this.pageNumberGoto.Size = new System.Drawing.Size(149, 25);
            this.pageNumberGoto.TabIndex = 7;
            this.pageNumberGoto.Text = "1";
            this.pageNumberGoto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel395
            // 
            this.panel395.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel395.Controls.Add(this.tableLayoutPanel33);
            this.panel395.Controls.Add(this.buttonSearch);
            this.panel395.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel395.Location = new System.Drawing.Point(336, 3);
            this.panel395.Name = "panel395";
            this.panel395.Size = new System.Drawing.Size(545, 52);
            this.panel395.TabIndex = 1;
            // 
            // tableLayoutPanel33
            // 
            this.tableLayoutPanel33.ColumnCount = 2;
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.Controls.Add(this.panel396, 1, 1);
            this.tableLayoutPanel33.Controls.Add(this.panel397, 0, 1);
            this.tableLayoutPanel33.Controls.Add(this.panel398, 1, 0);
            this.tableLayoutPanel33.Controls.Add(this.panel399, 0, 0);
            this.tableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel33.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel33.Name = "tableLayoutPanel33";
            this.tableLayoutPanel33.RowCount = 2;
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel33.Size = new System.Drawing.Size(438, 50);
            this.tableLayoutPanel33.TabIndex = 33;
            // 
            // panel396
            // 
            this.panel396.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel396.Controls.Add(this.TimeEnd);
            this.panel396.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel396.Location = new System.Drawing.Point(222, 23);
            this.panel396.Name = "panel396";
            this.panel396.Size = new System.Drawing.Size(213, 24);
            this.panel396.TabIndex = 3;
            // 
            // TimeEnd
            // 
            this.TimeEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeEnd.Location = new System.Drawing.Point(0, 0);
            this.TimeEnd.Name = "TimeEnd";
            this.TimeEnd.Size = new System.Drawing.Size(211, 22);
            this.TimeEnd.TabIndex = 35;
            // 
            // panel397
            // 
            this.panel397.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel397.Controls.Add(this.TimeStart);
            this.panel397.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel397.Location = new System.Drawing.Point(3, 23);
            this.panel397.Name = "panel397";
            this.panel397.Size = new System.Drawing.Size(213, 24);
            this.panel397.TabIndex = 2;
            // 
            // TimeStart
            // 
            this.TimeStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeStart.Location = new System.Drawing.Point(0, 0);
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.Size = new System.Drawing.Size(211, 22);
            this.TimeStart.TabIndex = 34;
            // 
            // panel398
            // 
            this.panel398.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel398.Controls.Add(this.label183);
            this.panel398.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel398.Location = new System.Drawing.Point(222, 3);
            this.panel398.Name = "panel398";
            this.panel398.Size = new System.Drawing.Size(213, 14);
            this.panel398.TabIndex = 1;
            // 
            // label183
            // 
            this.label183.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label183.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label183.ForeColor = System.Drawing.Color.SkyBlue;
            this.label183.Location = new System.Drawing.Point(0, 0);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(211, 12);
            this.label183.TabIndex = 4;
            this.label183.Text = "Đến ngày";
            this.label183.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel399
            // 
            this.panel399.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel399.Controls.Add(this.label184);
            this.panel399.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel399.Location = new System.Drawing.Point(3, 3);
            this.panel399.Name = "panel399";
            this.panel399.Size = new System.Drawing.Size(213, 14);
            this.panel399.TabIndex = 0;
            // 
            // label184
            // 
            this.label184.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label184.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label184.ForeColor = System.Drawing.Color.SkyBlue;
            this.label184.Location = new System.Drawing.Point(0, 0);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(211, 12);
            this.label184.TabIndex = 3;
            this.label184.Text = "Từ ngày";
            this.label184.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonSearch.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonSearch.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonSearch.BorderRadius = 3;
            this.buttonSearch.BorderSize = 0;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.ForeColor = System.Drawing.Color.Black;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(438, 0);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(105, 50);
            this.buttonSearch.TabIndex = 32;
            this.buttonSearch.Text = "Tìm kiếm";
            this.buttonSearch.TextColor = System.Drawing.Color.Black;
            this.buttonSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panel400
            // 
            this.panel400.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel400.Controls.Add(this.buttonPage);
            this.panel400.Controls.Add(this.buttonNextPage);
            this.panel400.Controls.Add(this.buttonPreviousPage);
            this.panel400.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel400.Location = new System.Drawing.Point(3, 3);
            this.panel400.Name = "panel400";
            this.panel400.Size = new System.Drawing.Size(223, 52);
            this.panel400.TabIndex = 0;
            // 
            // buttonPage
            // 
            this.buttonPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonPage.BorderRadius = 3;
            this.buttonPage.BorderSize = 0;
            this.buttonPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPage.Enabled = false;
            this.buttonPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPage.ForeColor = System.Drawing.Color.Black;
            this.buttonPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPage.Location = new System.Drawing.Point(60, 0);
            this.buttonPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage.Name = "buttonPage";
            this.buttonPage.Size = new System.Drawing.Size(101, 50);
            this.buttonPage.TabIndex = 32;
            this.buttonPage.Text = "1";
            this.buttonPage.TextColor = System.Drawing.Color.Black;
            this.buttonPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage.UseVisualStyleBackColor = false;
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNextPage.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNextPage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonNextPage.BorderRadius = 3;
            this.buttonNextPage.BorderSize = 0;
            this.buttonNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNextPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextPage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonNextPage.ForeColor = System.Drawing.Color.Black;
            this.buttonNextPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNextPage.Location = new System.Drawing.Point(161, 0);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(60, 50);
            this.buttonNextPage.TabIndex = 31;
            this.buttonNextPage.Text = ">";
            this.buttonNextPage.TextColor = System.Drawing.Color.Black;
            this.buttonNextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonNextPage.UseVisualStyleBackColor = false;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPreviousPage.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPreviousPage.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonPreviousPage.BorderRadius = 3;
            this.buttonPreviousPage.BorderSize = 0;
            this.buttonPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPreviousPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPreviousPage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPreviousPage.ForeColor = System.Drawing.Color.Black;
            this.buttonPreviousPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPreviousPage.Location = new System.Drawing.Point(0, 0);
            this.buttonPreviousPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(60, 50);
            this.buttonPreviousPage.TabIndex = 29;
            this.buttonPreviousPage.Text = "<";
            this.buttonPreviousPage.TextColor = System.Drawing.Color.Black;
            this.buttonPreviousPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPreviousPage.UseVisualStyleBackColor = false;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
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
            this.buttonCustomGoPage.Location = new System.Drawing.Point(2379, -70);
            this.buttonCustomGoPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCustomGoPage.Name = "buttonCustomGoPage";
            this.buttonCustomGoPage.Size = new System.Drawing.Size(93, 35);
            this.buttonCustomGoPage.TabIndex = 33;
            this.buttonCustomGoPage.Text = "Đi";
            this.buttonCustomGoPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCustomGoPage.TextColor = System.Drawing.Color.Black;
            this.buttonCustomGoPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCustomGoPage.UseVisualStyleBackColor = false;
            // 
            // inputNumPageGo
            // 
            this.inputNumPageGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputNumPageGo.BeforeTouchSize = new System.Drawing.Size(66, 35);
            this.inputNumPageGo.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.inputNumPageGo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputNumPageGo.IntegerValue = ((long)(1));
            this.inputNumPageGo.Location = new System.Drawing.Point(2309, -68);
            this.inputNumPageGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputNumPageGo.Multiline = true;
            this.inputNumPageGo.Name = "inputNumPageGo";
            this.inputNumPageGo.Size = new System.Drawing.Size(66, 35);
            this.inputNumPageGo.TabIndex = 32;
            this.inputNumPageGo.Text = "1";
            this.inputNumPageGo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 372);
            this.dataGridView1.TabIndex = 1;
            // 
            // Nguon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1057, 478);
            this.Controls.Add(this.tabControl1);
            this.Name = "Nguon";
            this.Text = "JigMach";
            this.Load += new System.EventHandler(this.Nguon_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageThongKe.ResumeLayout(false);
            this.panelThongKe.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutPanel32.ResumeLayout(false);
            this.panel392.ResumeLayout(false);
            this.panel393.ResumeLayout(false);
            this.panel394.ResumeLayout(false);
            this.panel394.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberGoto)).EndInit();
            this.panel395.ResumeLayout(false);
            this.tableLayoutPanel33.ResumeLayout(false);
            this.panel396.ResumeLayout(false);
            this.panel397.ResumeLayout(false);
            this.panel398.ResumeLayout(false);
            this.panel399.ResumeLayout(false);
            this.panel400.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageGiamSat2;
        private TabPage tabPageThongKe;
        private TabPage tabPageGiamSat1;
        private Panel panelThongKe;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel31;
        private TableLayoutPanel tableLayoutPanel32;
        private Panel panel392;
        private Label label181;
        private Panel panel393;
        private Label lbTotalPages;
        private Panel panel394;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonGoto;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox pageNumberGoto;
        private Panel panel395;
        private TableLayoutPanel tableLayoutPanel33;
        private Panel panel396;
        private Syncfusion.WinForms.Input.SfDateTimeEdit TimeEnd;
        private Panel panel397;
        private Syncfusion.WinForms.Input.SfDateTimeEdit TimeStart;
        private Panel panel398;
        private Label label183;
        private Panel panel399;
        private Label label184;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonSearch;
        private Panel panel400;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonNextPage;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPreviousPage;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustomGoPage;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox inputNumPageGo;
        private DataGridView dataGridView1;
    }
}