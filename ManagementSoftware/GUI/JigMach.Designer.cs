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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGiamSatJigMach = new System.Windows.Forms.TabPage();
            this.tabPageThongKe = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageGiamSatJigMach.SuspendLayout();
            this.tabPageThongKe.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.tabPageGiamSatJigMach.Controls.Add(this.panel1);
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
            this.tabPageThongKe.Controls.Add(this.panel2);
            this.tabPageThongKe.Location = new System.Drawing.Point(4, 24);
            this.tabPageThongKe.Name = "tabPageThongKe";
            this.tabPageThongKe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageThongKe.Size = new System.Drawing.Size(980, 503);
            this.tabPageThongKe.TabIndex = 1;
            this.tabPageThongKe.Text = "Thống kê";
            this.tabPageThongKe.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 41);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(974, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giám sát";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(974, 41);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(974, 41);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thống kê";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tabPageGiamSatJigMach.ResumeLayout(false);
            this.tabPageThongKe.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageGiamSatJigMach;
        private TabPage tabPageThongKe;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
    }
}