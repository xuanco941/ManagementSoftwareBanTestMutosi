namespace ManagementSoftware.GUI.ActivityManagement
{
    partial class FormChangeNumElmOnPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangeNumElmOnPage));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveSetting = new LW_PhanMemBaoGia.MyControls.ButtonCustom();
            this.inputNumPageGo = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(92, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "Số dòng hiển thị :";
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveSetting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSaveSetting.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSaveSetting.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.buttonSaveSetting.BorderRadius = 6;
            this.buttonSaveSetting.BorderSize = 0;
            this.buttonSaveSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonSaveSetting.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveSetting.Image")));
            this.buttonSaveSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveSetting.Location = new System.Drawing.Point(307, 90);
            this.buttonSaveSetting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(88, 40);
            this.buttonSaveSetting.TabIndex = 52;
            this.buttonSaveSetting.Text = "Lưu";
            this.buttonSaveSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSaveSetting.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.buttonSaveSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonSaveSetting.UseVisualStyleBackColor = false;
            this.buttonSaveSetting.Click += new System.EventHandler(this.buttonSaveSetting_Click);
            // 
            // inputNumPageGo
            // 
            this.inputNumPageGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputNumPageGo.BeforeTouchSize = new System.Drawing.Size(207, 38);
            this.inputNumPageGo.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.inputNumPageGo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputNumPageGo.IntegerValue = ((long)(1));
            this.inputNumPageGo.Location = new System.Drawing.Point(92, 92);
            this.inputNumPageGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputNumPageGo.MaxValue = ((long)(2001));
            this.inputNumPageGo.MinValue = ((long)(1));
            this.inputNumPageGo.Multiline = true;
            this.inputNumPageGo.Name = "inputNumPageGo";
            this.inputNumPageGo.Size = new System.Drawing.Size(207, 38);
            this.inputNumPageGo.TabIndex = 54;
            this.inputNumPageGo.Text = "1";
            this.inputNumPageGo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputNumPageGo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputNumPageGo_KeyDown);
            // 
            // FormChangeNumElmOnPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(500, 213);
            this.Controls.Add(this.inputNumPageGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangeNumElmOnPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi số dòng hiển thị trên trang hoạt động";
            ((System.ComponentModel.ISupportInitialize)(this.inputNumPageGo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LW_PhanMemBaoGia.MyControls.ButtonCustom buttonSaveSetting;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox inputNumPageGo;
    }
}