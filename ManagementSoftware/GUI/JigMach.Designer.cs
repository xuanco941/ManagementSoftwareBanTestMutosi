namespace ManagementSoftware.GUI
{
    partial class JigMach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JigMach));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGiamSatJigMach = new System.Windows.Forms.TabPage();
            this.tabPageThongKe = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCustomGoPage = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.inputNumPageGo = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.buttonPageNext = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage3 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage1 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.buttonPage2 = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.panelThongKe = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPageThongKe.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGiamSatJigMach);
            this.tabControl1.Controls.Add(this.tabPageThongKe);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(988, 531);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageGiamSatJigMach
            // 
            this.tabPageGiamSatJigMach.AutoScroll = true;
            this.tabPageGiamSatJigMach.Location = new System.Drawing.Point(4, 24);
            this.tabPageGiamSatJigMach.Name = "tabPageGiamSatJigMach";
            this.tabPageGiamSatJigMach.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGiamSatJigMach.Size = new System.Drawing.Size(980, 503);
            this.tabPageGiamSatJigMach.TabIndex = 0;
            this.tabPageGiamSatJigMach.Text = "Giám sát Jig Mạch";
            this.tabPageGiamSatJigMach.UseVisualStyleBackColor = true;
            // 
            // tabPageThongKe
            // 
            this.tabPageThongKe.Controls.Add(this.panelThongKe);
            this.tabPageThongKe.Controls.Add(this.panel2);
            this.tabPageThongKe.Location = new System.Drawing.Point(4, 24);
            this.tabPageThongKe.Name = "tabPageThongKe";
            this.tabPageThongKe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThongKe.Size = new System.Drawing.Size(980, 503);
            this.tabPageThongKe.TabIndex = 1;
            this.tabPageThongKe.Text = "Thống kê";
            this.tabPageThongKe.UseVisualStyleBackColor = true;
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
            this.panel2.Location = new System.Drawing.Point(3, 452);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 48);
            this.panel2.TabIndex = 1;
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
            this.buttonCustomGoPage.Location = new System.Drawing.Point(1387, -40);
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
            this.inputNumPageGo.Location = new System.Drawing.Point(1317, -38);
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
            this.buttonPageNext.Location = new System.Drawing.Point(243, 8);
            this.buttonPageNext.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPageNext.Name = "buttonPageNext";
            this.buttonPageNext.Size = new System.Drawing.Size(74, 35);
            this.buttonPageNext.TabIndex = 28;
            this.buttonPageNext.Text = ">>";
            this.buttonPageNext.TextColor = System.Drawing.Color.Black;
            this.buttonPageNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPageNext.UseVisualStyleBackColor = false;
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
            this.buttonPage3.Location = new System.Drawing.Point(163, 8);
            this.buttonPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage3.Name = "buttonPage3";
            this.buttonPage3.Size = new System.Drawing.Size(74, 35);
            this.buttonPage3.TabIndex = 27;
            this.buttonPage3.Text = "3";
            this.buttonPage3.TextColor = System.Drawing.Color.Black;
            this.buttonPage3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage3.UseVisualStyleBackColor = false;
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
            this.buttonPage1.Location = new System.Drawing.Point(3, 8);
            this.buttonPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage1.Name = "buttonPage1";
            this.buttonPage1.Size = new System.Drawing.Size(74, 35);
            this.buttonPage1.TabIndex = 26;
            this.buttonPage1.Text = "1";
            this.buttonPage1.TextColor = System.Drawing.Color.Black;
            this.buttonPage1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage1.UseVisualStyleBackColor = false;
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
            this.buttonPage2.Location = new System.Drawing.Point(82, 8);
            this.buttonPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPage2.Name = "buttonPage2";
            this.buttonPage2.Size = new System.Drawing.Size(74, 35);
            this.buttonPage2.TabIndex = 25;
            this.buttonPage2.Text = "2";
            this.buttonPage2.TextColor = System.Drawing.Color.Black;
            this.buttonPage2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonPage2.UseVisualStyleBackColor = false;
            // 
            // panelThongKe
            // 
            this.panelThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelThongKe.Location = new System.Drawing.Point(3, 3);
            this.panelThongKe.Name = "panelThongKe";
            this.panelThongKe.Size = new System.Drawing.Size(974, 449);
            this.panelThongKe.TabIndex = 2;
            // 
            // JigMach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(988, 531);
            this.Controls.Add(this.tabControl1);
            this.Name = "JigMach";
            this.Text = "JigMach";
            this.tabControl1.ResumeLayout(false);
            this.tabPageThongKe.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageGiamSatJigMach;
        private TabPage tabPageThongKe;
        private Panel panelThongKe;
        private Panel panel2;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonCustomGoPage;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox inputNumPageGo;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPageNext;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage3;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage1;
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonPage2;
    }
}