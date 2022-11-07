using System.Windows.Forms;

namespace ManagementSoftware.GUI.ActivityManagement
{
    partial class FormEmployeeActivities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeActivities));
            this.panelUser = new System.Windows.Forms.Panel();
            this.dataGridViewUserActivity = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonPageNext = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage3 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage1 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage2 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserActivity)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUser
            // 
            this.panelUser.AutoScroll = true;
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelUser.Location = new System.Drawing.Point(798, 0);
            this.panelUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(277, 515);
            this.panelUser.TabIndex = 0;
            // 
            // dataGridViewUserActivity
            // 
            this.dataGridViewUserActivity.AllowUserToAddRows = false;
            this.dataGridViewUserActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserActivity.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUserActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUserActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUserActivity.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUserActivity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewUserActivity.Name = "dataGridViewUserActivity";
            this.dataGridViewUserActivity.ReadOnly = true;
            this.dataGridViewUserActivity.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewUserActivity.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUserActivity.RowTemplate.Height = 25;
            this.dataGridViewUserActivity.Size = new System.Drawing.Size(798, 515);
            this.dataGridViewUserActivity.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridViewUserActivity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 515);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonPageNext);
            this.panel2.Controls.Add(this.buttonPage3);
            this.panel2.Controls.Add(this.buttonPage1);
            this.panel2.Controls.Add(this.buttonPage2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 457);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 58);
            this.panel2.TabIndex = 2;
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
            this.buttonPageNext.Location = new System.Drawing.Point(243, 10);
            this.buttonPageNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPageNext.Name = "buttonPageNext";
            this.buttonPageNext.Size = new System.Drawing.Size(74, 35);
            this.buttonPageNext.TabIndex = 32;
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
            this.buttonPage3.Location = new System.Drawing.Point(163, 10);
            this.buttonPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage3.Name = "buttonPage3";
            this.buttonPage3.Size = new System.Drawing.Size(74, 35);
            this.buttonPage3.TabIndex = 31;
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
            this.buttonPage1.Location = new System.Drawing.Point(3, 10);
            this.buttonPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage1.Name = "buttonPage1";
            this.buttonPage1.Size = new System.Drawing.Size(74, 35);
            this.buttonPage1.TabIndex = 30;
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
            this.buttonPage2.Location = new System.Drawing.Point(82, 10);
            this.buttonPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage2.Name = "buttonPage2";
            this.buttonPage2.Size = new System.Drawing.Size(74, 35);
            this.buttonPage2.TabIndex = 29;
            this.buttonPage2.Text = "2";
            this.buttonPage2.TextColor = System.Drawing.Color.Black;
            this.buttonPage2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage2.UseVisualStyleBackColor = false;
            this.buttonPage2.Click += new System.EventHandler(this.buttonPage1_Click);
            // 
            // FormEmployeeActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1075, 515);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelUser);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormEmployeeActivities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hoạt động của nhân viên vận hành";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserActivity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelUser;
        private DataGridView dataGridViewUserActivity;
        private Panel panel1;
        private Panel panel2;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPageNext;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage3;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage1;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage2;
    }
}