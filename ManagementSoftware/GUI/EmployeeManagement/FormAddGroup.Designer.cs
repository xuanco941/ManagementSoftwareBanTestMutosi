using System.Windows.Forms;

namespace ManagementSoftware.GUI.EmployeeManagement
{
    partial class FormAddGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddGroup));
            this.checkBoxIsManagementUser = new System.Windows.Forms.CheckBox();
            this.checkBoxIsManagementGroup = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxIsDeleteActivity = new System.Windows.Forms.CheckBox();
            this.checkBoxIsDeleteResult = new System.Windows.Forms.CheckBox();
            this.checkBoxIsViewActivity = new System.Windows.Forms.CheckBox();
            this.checkBoxIsViewResult = new System.Windows.Forms.CheckBox();
            this.checkBoxIsSettingTemplateMachine = new System.Windows.Forms.CheckBox();
            this.checkBoxIsSettingShift = new System.Windows.Forms.CheckBox();
            this.checkBoxIsSettingMachine = new System.Windows.Forms.CheckBox();
            this.checkBoxIsControlMachine = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNameGroup = new LW_PhanMemBaoGia.MyControls.TextBoxT();
            this.buttonAddGroup = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxIsManagementUser
            // 
            this.checkBoxIsManagementUser.AutoSize = true;
            this.checkBoxIsManagementUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsManagementUser.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsManagementUser.Location = new System.Drawing.Point(24, 30);
            this.checkBoxIsManagementUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsManagementUser.Name = "checkBoxIsManagementUser";
            this.checkBoxIsManagementUser.Size = new System.Drawing.Size(188, 29);
            this.checkBoxIsManagementUser.TabIndex = 12;
            this.checkBoxIsManagementUser.Text = "Quản trị nhân viên";
            this.checkBoxIsManagementUser.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsManagementGroup
            // 
            this.checkBoxIsManagementGroup.AutoSize = true;
            this.checkBoxIsManagementGroup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsManagementGroup.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsManagementGroup.Location = new System.Drawing.Point(24, 65);
            this.checkBoxIsManagementGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsManagementGroup.Name = "checkBoxIsManagementGroup";
            this.checkBoxIsManagementGroup.Size = new System.Drawing.Size(211, 29);
            this.checkBoxIsManagementGroup.TabIndex = 13;
            this.checkBoxIsManagementGroup.Text = "Quản trị nhóm quyền";
            this.checkBoxIsManagementGroup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxIsDeleteActivity);
            this.groupBox1.Controls.Add(this.checkBoxIsDeleteResult);
            this.groupBox1.Controls.Add(this.checkBoxIsViewActivity);
            this.groupBox1.Controls.Add(this.checkBoxIsViewResult);
            this.groupBox1.Controls.Add(this.checkBoxIsSettingTemplateMachine);
            this.groupBox1.Controls.Add(this.checkBoxIsSettingShift);
            this.groupBox1.Controls.Add(this.checkBoxIsSettingMachine);
            this.groupBox1.Controls.Add(this.checkBoxIsControlMachine);
            this.groupBox1.Controls.Add(this.checkBoxIsManagementUser);
            this.groupBox1.Controls.Add(this.checkBoxIsManagementGroup);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(155, 175);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(415, 402);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cho phép";
            // 
            // checkBoxIsDeleteActivity
            // 
            this.checkBoxIsDeleteActivity.AutoSize = true;
            this.checkBoxIsDeleteActivity.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsDeleteActivity.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsDeleteActivity.Location = new System.Drawing.Point(24, 342);
            this.checkBoxIsDeleteActivity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsDeleteActivity.Name = "checkBoxIsDeleteActivity";
            this.checkBoxIsDeleteActivity.Size = new System.Drawing.Size(214, 29);
            this.checkBoxIsDeleteActivity.TabIndex = 22;
            this.checkBoxIsDeleteActivity.Text = "Xóa lịch sử hoạt động";
            this.checkBoxIsDeleteActivity.UseVisualStyleBackColor = true;
            this.checkBoxIsDeleteActivity.CheckedChanged += new System.EventHandler(this.checkBoxIsDeleteActivity_CheckedChanged);
            // 
            // checkBoxIsDeleteResult
            // 
            this.checkBoxIsDeleteResult.AutoSize = true;
            this.checkBoxIsDeleteResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsDeleteResult.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsDeleteResult.Location = new System.Drawing.Point(24, 307);
            this.checkBoxIsDeleteResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsDeleteResult.Name = "checkBoxIsDeleteResult";
            this.checkBoxIsDeleteResult.Size = new System.Drawing.Size(159, 29);
            this.checkBoxIsDeleteResult.TabIndex = 21;
            this.checkBoxIsDeleteResult.Text = "Xóa lịch sử nạp";
            this.checkBoxIsDeleteResult.UseVisualStyleBackColor = true;
            this.checkBoxIsDeleteResult.CheckedChanged += new System.EventHandler(this.checkBoxIsDeleteResult_CheckedChanged);
            // 
            // checkBoxIsViewActivity
            // 
            this.checkBoxIsViewActivity.AutoSize = true;
            this.checkBoxIsViewActivity.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsViewActivity.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsViewActivity.Location = new System.Drawing.Point(24, 272);
            this.checkBoxIsViewActivity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsViewActivity.Name = "checkBoxIsViewActivity";
            this.checkBoxIsViewActivity.Size = new System.Drawing.Size(219, 29);
            this.checkBoxIsViewActivity.TabIndex = 20;
            this.checkBoxIsViewActivity.Text = "Xem lịch sử hoạt động";
            this.checkBoxIsViewActivity.UseVisualStyleBackColor = true;
            this.checkBoxIsViewActivity.CheckedChanged += new System.EventHandler(this.checkBoxIsViewActivity_CheckedChanged);
            // 
            // checkBoxIsViewResult
            // 
            this.checkBoxIsViewResult.AutoSize = true;
            this.checkBoxIsViewResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsViewResult.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsViewResult.Location = new System.Drawing.Point(24, 238);
            this.checkBoxIsViewResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsViewResult.Name = "checkBoxIsViewResult";
            this.checkBoxIsViewResult.Size = new System.Drawing.Size(164, 29);
            this.checkBoxIsViewResult.TabIndex = 19;
            this.checkBoxIsViewResult.Text = "Xem lịch sử nạp";
            this.checkBoxIsViewResult.UseVisualStyleBackColor = true;
            this.checkBoxIsViewResult.CheckedChanged += new System.EventHandler(this.checkBoxIsViewResult_CheckedChanged);
            // 
            // checkBoxIsSettingTemplateMachine
            // 
            this.checkBoxIsSettingTemplateMachine.AutoSize = true;
            this.checkBoxIsSettingTemplateMachine.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsSettingTemplateMachine.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsSettingTemplateMachine.Location = new System.Drawing.Point(24, 203);
            this.checkBoxIsSettingTemplateMachine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsSettingTemplateMachine.Name = "checkBoxIsSettingTemplateMachine";
            this.checkBoxIsSettingTemplateMachine.Size = new System.Drawing.Size(147, 29);
            this.checkBoxIsSettingTemplateMachine.TabIndex = 17;
            this.checkBoxIsSettingTemplateMachine.Text = "Thiết lập bình";
            this.checkBoxIsSettingTemplateMachine.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsSettingShift
            // 
            this.checkBoxIsSettingShift.AutoSize = true;
            this.checkBoxIsSettingShift.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsSettingShift.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsSettingShift.Location = new System.Drawing.Point(24, 168);
            this.checkBoxIsSettingShift.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsSettingShift.Name = "checkBoxIsSettingShift";
            this.checkBoxIsSettingShift.Size = new System.Drawing.Size(164, 29);
            this.checkBoxIsSettingShift.TabIndex = 16;
            this.checkBoxIsSettingShift.Text = "Thiết lập ca làm";
            this.checkBoxIsSettingShift.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsSettingMachine
            // 
            this.checkBoxIsSettingMachine.AutoSize = true;
            this.checkBoxIsSettingMachine.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsSettingMachine.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsSettingMachine.Location = new System.Drawing.Point(24, 134);
            this.checkBoxIsSettingMachine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsSettingMachine.Name = "checkBoxIsSettingMachine";
            this.checkBoxIsSettingMachine.Size = new System.Drawing.Size(209, 29);
            this.checkBoxIsSettingMachine.TabIndex = 15;
            this.checkBoxIsSettingMachine.Text = "Cài đặt thông số máy";
            this.checkBoxIsSettingMachine.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsControlMachine
            // 
            this.checkBoxIsControlMachine.AutoSize = true;
            this.checkBoxIsControlMachine.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIsControlMachine.ForeColor = System.Drawing.Color.White;
            this.checkBoxIsControlMachine.Location = new System.Drawing.Point(24, 99);
            this.checkBoxIsControlMachine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxIsControlMachine.Name = "checkBoxIsControlMachine";
            this.checkBoxIsControlMachine.Size = new System.Drawing.Size(161, 29);
            this.checkBoxIsControlMachine.TabIndex = 14;
            this.checkBoxIsControlMachine.Text = "Điều khiển máy";
            this.checkBoxIsControlMachine.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.YellowGreen;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(732, 104);
            this.label8.TabIndex = 32;
            this.label8.Text = "Thêm Nhóm Quyền";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNameGroup
            // 
            this.textBoxNameGroup.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxNameGroup.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.textBoxNameGroup.BorderFocusColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxNameGroup.BorderRadius = 5;
            this.textBoxNameGroup.BorderSize = 1;
            this.textBoxNameGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxNameGroup.Location = new System.Drawing.Point(155, 110);
            this.textBoxNameGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxNameGroup.Multiline = false;
            this.textBoxNameGroup.Name = "textBoxNameGroup";
            this.textBoxNameGroup.Padding = new System.Windows.Forms.Padding(8);
            this.textBoxNameGroup.PasswordChar = false;
            this.textBoxNameGroup.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBoxNameGroup.PlaceholderText = "Tên nhóm quyền";
            this.textBoxNameGroup.Size = new System.Drawing.Size(415, 38);
            this.textBoxNameGroup.TabIndex = 52;
            this.textBoxNameGroup.Texts = "Tên nhóm quyền";
            this.textBoxNameGroup.UnderlinedStyle = false;
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.BackColor = System.Drawing.Color.Green;
            this.buttonAddGroup.BackgroundColor = System.Drawing.Color.Green;
            this.buttonAddGroup.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonAddGroup.BorderRadius = 3;
            this.buttonAddGroup.BorderSize = 0;
            this.buttonAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAddGroup.ForeColor = System.Drawing.Color.White;
            this.buttonAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddGroup.Image")));
            this.buttonAddGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddGroup.Location = new System.Drawing.Point(288, 601);
            this.buttonAddGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(147, 42);
            this.buttonAddGroup.TabIndex = 57;
            this.buttonAddGroup.Text = "Thêm";
            this.buttonAddGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddGroup.TextColor = System.Drawing.Color.White;
            this.buttonAddGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonAddGroup.UseVisualStyleBackColor = false;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 104);
            this.panel1.TabIndex = 58;
            // 
            // FormAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(732, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAddGroup);
            this.Controls.Add(this.textBoxNameGroup);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nhóm quyền";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CheckBox checkBoxIsManagementUser;
        private CheckBox checkBoxIsManagementGroup;
        private GroupBox groupBox1;
        private CheckBox checkBoxIsSettingTemplateMachine;
        private CheckBox checkBoxIsSettingShift;
        private CheckBox checkBoxIsSettingMachine;
        private CheckBox checkBoxIsControlMachine;
        private Label label8;
        private LW_PhanMemBaoGia.MyControls.TextBoxT textBoxNameGroup;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonAddGroup;
        private CheckBox checkBoxIsDeleteResult;
        private CheckBox checkBoxIsViewActivity;
        private CheckBox checkBoxIsViewResult;
        private CheckBox checkBoxIsDeleteActivity;
        private Panel panel1;
    }
}