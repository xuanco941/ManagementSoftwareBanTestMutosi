using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelItemMenu = new System.Windows.Forms.Panel();
            this.buttonDangXuat = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.buttonActivity = new System.Windows.Forms.Button();
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.buttonCongTac = new System.Windows.Forms.Button();
            this.buttonJigMach = new System.Windows.Forms.Button();
            this.buttonNguon = new System.Windows.Forms.Button();
            this.buttonBauNong = new System.Windows.Forms.Button();
            this.buttonBepTu = new System.Windows.Forms.Button();
            this.buttonLoiLoc = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelAleart = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelItemMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panelItemMenu);
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(211, 478);
            this.panelMenu.TabIndex = 0;
            // 
            // panelItemMenu
            // 
            this.panelItemMenu.AutoScroll = true;
            this.panelItemMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItemMenu.Controls.Add(this.buttonDangXuat);
            this.panelItemMenu.Controls.Add(this.buttonSetting);
            this.panelItemMenu.Controls.Add(this.buttonActivity);
            this.panelItemMenu.Controls.Add(this.buttonEmployee);
            this.panelItemMenu.Controls.Add(this.buttonCongTac);
            this.panelItemMenu.Controls.Add(this.buttonJigMach);
            this.panelItemMenu.Controls.Add(this.buttonNguon);
            this.panelItemMenu.Controls.Add(this.buttonBauNong);
            this.panelItemMenu.Controls.Add(this.buttonBepTu);
            this.panelItemMenu.Controls.Add(this.buttonLoiLoc);
            this.panelItemMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelItemMenu.Location = new System.Drawing.Point(0, 76);
            this.panelItemMenu.Name = "panelItemMenu";
            this.panelItemMenu.Size = new System.Drawing.Size(211, 402);
            this.panelItemMenu.TabIndex = 1;
            // 
            // buttonDangXuat
            // 
            this.buttonDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDangXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDangXuat.FlatAppearance.BorderSize = 0;
            this.buttonDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDangXuat.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDangXuat.ForeColor = System.Drawing.Color.White;
            this.buttonDangXuat.Image = global::ManagementSoftware.Properties.Resources.red_x_10333;
            this.buttonDangXuat.Location = new System.Drawing.Point(0, 711);
            this.buttonDangXuat.Name = "buttonDangXuat";
            this.buttonDangXuat.Size = new System.Drawing.Size(192, 79);
            this.buttonDangXuat.TabIndex = 12;
            this.buttonDangXuat.Text = "Đăng xuất";
            this.buttonDangXuat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDangXuat.UseVisualStyleBackColor = true;
            this.buttonDangXuat.Click += new System.EventHandler(this.buttonDangXuat_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSetting.FlatAppearance.BorderSize = 0;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSetting.ForeColor = System.Drawing.Color.White;
            this.buttonSetting.Image = global::ManagementSoftware.Properties.Resources.setting_24;
            this.buttonSetting.Location = new System.Drawing.Point(0, 632);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(192, 79);
            this.buttonSetting.TabIndex = 11;
            this.buttonSetting.Text = "Cài đặt";
            this.buttonSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // buttonActivity
            // 
            this.buttonActivity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonActivity.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonActivity.FlatAppearance.BorderSize = 0;
            this.buttonActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActivity.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonActivity.ForeColor = System.Drawing.Color.White;
            this.buttonActivity.Image = global::ManagementSoftware.Properties.Resources.button3_Image;
            this.buttonActivity.Location = new System.Drawing.Point(0, 553);
            this.buttonActivity.Name = "buttonActivity";
            this.buttonActivity.Size = new System.Drawing.Size(192, 79);
            this.buttonActivity.TabIndex = 10;
            this.buttonActivity.Text = "Hoạt động";
            this.buttonActivity.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonActivity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonActivity.UseVisualStyleBackColor = true;
            this.buttonActivity.Click += new System.EventHandler(this.buttonActivity_Click);
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEmployee.FlatAppearance.BorderSize = 0;
            this.buttonEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmployee.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEmployee.ForeColor = System.Drawing.Color.White;
            this.buttonEmployee.Image = global::ManagementSoftware.Properties.Resources.button2_Image;
            this.buttonEmployee.Location = new System.Drawing.Point(0, 474);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(192, 79);
            this.buttonEmployee.TabIndex = 9;
            this.buttonEmployee.Text = "Quản lý nhân sự";
            this.buttonEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // buttonCongTac
            // 
            this.buttonCongTac.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCongTac.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCongTac.FlatAppearance.BorderSize = 0;
            this.buttonCongTac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCongTac.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCongTac.ForeColor = System.Drawing.Color.White;
            this.buttonCongTac.Image = ((System.Drawing.Image)(resources.GetObject("buttonCongTac.Image")));
            this.buttonCongTac.Location = new System.Drawing.Point(0, 395);
            this.buttonCongTac.Name = "buttonCongTac";
            this.buttonCongTac.Size = new System.Drawing.Size(192, 79);
            this.buttonCongTac.TabIndex = 8;
            this.buttonCongTac.Text = "Công tắc";
            this.buttonCongTac.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCongTac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCongTac.UseVisualStyleBackColor = true;
            this.buttonCongTac.Click += new System.EventHandler(this.buttonCongTac_Click);
            // 
            // buttonJigMach
            // 
            this.buttonJigMach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonJigMach.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonJigMach.FlatAppearance.BorderSize = 0;
            this.buttonJigMach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonJigMach.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonJigMach.ForeColor = System.Drawing.Color.White;
            this.buttonJigMach.Image = ((System.Drawing.Image)(resources.GetObject("buttonJigMach.Image")));
            this.buttonJigMach.Location = new System.Drawing.Point(0, 316);
            this.buttonJigMach.Name = "buttonJigMach";
            this.buttonJigMach.Size = new System.Drawing.Size(192, 79);
            this.buttonJigMach.TabIndex = 15;
            this.buttonJigMach.Text = "Jig mạch";
            this.buttonJigMach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonJigMach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonJigMach.UseVisualStyleBackColor = true;
            this.buttonJigMach.Click += new System.EventHandler(this.buttonJigMach_Click);
            // 
            // buttonNguon
            // 
            this.buttonNguon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNguon.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNguon.FlatAppearance.BorderSize = 0;
            this.buttonNguon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNguon.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNguon.ForeColor = System.Drawing.Color.White;
            this.buttonNguon.Image = ((System.Drawing.Image)(resources.GetObject("buttonNguon.Image")));
            this.buttonNguon.Location = new System.Drawing.Point(0, 237);
            this.buttonNguon.Name = "buttonNguon";
            this.buttonNguon.Size = new System.Drawing.Size(192, 79);
            this.buttonNguon.TabIndex = 17;
            this.buttonNguon.Text = "Nguồn";
            this.buttonNguon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNguon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonNguon.UseVisualStyleBackColor = true;
            this.buttonNguon.Click += new System.EventHandler(this.buttonNguon_Click);
            // 
            // buttonBauNong
            // 
            this.buttonBauNong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBauNong.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBauNong.FlatAppearance.BorderSize = 0;
            this.buttonBauNong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBauNong.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBauNong.ForeColor = System.Drawing.Color.White;
            this.buttonBauNong.Image = ((System.Drawing.Image)(resources.GetObject("buttonBauNong.Image")));
            this.buttonBauNong.Location = new System.Drawing.Point(0, 158);
            this.buttonBauNong.Name = "buttonBauNong";
            this.buttonBauNong.Size = new System.Drawing.Size(192, 79);
            this.buttonBauNong.TabIndex = 16;
            this.buttonBauNong.Text = "Bầu nóng";
            this.buttonBauNong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBauNong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonBauNong.UseVisualStyleBackColor = true;
            this.buttonBauNong.Click += new System.EventHandler(this.buttonBauNong_Click);
            // 
            // buttonBepTu
            // 
            this.buttonBepTu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBepTu.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBepTu.FlatAppearance.BorderSize = 0;
            this.buttonBepTu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBepTu.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBepTu.ForeColor = System.Drawing.Color.White;
            this.buttonBepTu.Image = ((System.Drawing.Image)(resources.GetObject("buttonBepTu.Image")));
            this.buttonBepTu.Location = new System.Drawing.Point(0, 79);
            this.buttonBepTu.Name = "buttonBepTu";
            this.buttonBepTu.Size = new System.Drawing.Size(192, 79);
            this.buttonBepTu.TabIndex = 14;
            this.buttonBepTu.Text = "Bếp từ";
            this.buttonBepTu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonBepTu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonBepTu.UseVisualStyleBackColor = true;
            this.buttonBepTu.Click += new System.EventHandler(this.buttonBepTu_Click);
            // 
            // buttonLoiLoc
            // 
            this.buttonLoiLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.buttonLoiLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoiLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLoiLoc.FlatAppearance.BorderSize = 0;
            this.buttonLoiLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoiLoc.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoiLoc.ForeColor = System.Drawing.Color.White;
            this.buttonLoiLoc.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoiLoc.Image")));
            this.buttonLoiLoc.Location = new System.Drawing.Point(0, 0);
            this.buttonLoiLoc.Name = "buttonLoiLoc";
            this.buttonLoiLoc.Size = new System.Drawing.Size(192, 79);
            this.buttonLoiLoc.TabIndex = 7;
            this.buttonLoiLoc.Text = "Lõi lọc";
            this.buttonLoiLoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonLoiLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonLoiLoc.UseVisualStyleBackColor = false;
            this.buttonLoiLoc.Click += new System.EventHandler(this.buttonLoiLoc_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 76);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.Color.LightGray;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(187, 70);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "Bàn test";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.panelContent);
            this.panelContainer.Controls.Add(this.panelHeader);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(211, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(970, 478);
            this.panelContainer.TabIndex = 3;
            // 
            // panelContent
            // 
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelContent.Location = new System.Drawing.Point(0, 76);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(970, 402);
            this.panelContent.TabIndex = 5;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.tableLayoutPanel1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(970, 76);
            this.panelHeader.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelAleart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(970, 76);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelAleart
            // 
            this.panelAleart.AutoScroll = true;
            this.panelAleart.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAleart.Location = new System.Drawing.Point(547, 3);
            this.panelAleart.MaximumSize = new System.Drawing.Size(1260, 70);
            this.panelAleart.MinimumSize = new System.Drawing.Size(420, 70);
            this.panelAleart.Name = "panelAleart";
            this.panelAleart.Size = new System.Drawing.Size(420, 70);
            this.panelAleart.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 70);
            this.panel2.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1181, 478);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Jig";
            this.panelMenu.ResumeLayout(false);
            this.panelItemMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelHeader;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelAleart;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Panel panelItemMenu;
        private Button buttonDangXuat;
        private Button buttonSetting;
        private Button buttonActivity;
        private Button buttonEmployee;
        private Button buttonCongTac;
        private Button buttonLoiLoc;
        private Button buttonJigMach;
        private Button buttonBepTu;
        private Button buttonBauNong;
        private Button buttonNguon;
    }
}

