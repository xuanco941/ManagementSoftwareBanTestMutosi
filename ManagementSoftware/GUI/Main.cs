using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSoftware.GUI.Section;

namespace ManagementSoftware.GUI
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();

            //fullscreen
            this.WindowState = FormWindowState.Maximized;
         
        }


        public void Alert(string msg, FormAlert.enmType type)
        {
            FormAlert frm = new FormAlert();
            frm.showAlert(msg, type);
            panelAleart.Controls.Add(frm);
        }

        private void ChangeFormContent(Form form, object sender)
        {
            //focus button
            Button button = sender as Button;

            labelHeader.Text = button.Text;
            foreach (Control control in panelItemMenu.Controls)
            {
                control.BackColor = Color.FromArgb(41, 44, 51);
                if (control.Text == button.Text)
                {
                    control.BackColor = Color.FromArgb(69, 73, 82);
                }
            }


            List<Form> oldForms = new List<Form>();
            foreach (Form oldForm in panelContent.Controls)
            {
                oldForms.Add(oldForm);
            }

            // Đóng/loại bỏ các FormItemPO cũ khỏi panelMain.Controls
            foreach (Form oldForm in oldForms)
            {
                oldForm.Close();
                oldForm.Dispose();
            }

            ////remove controls in panel

            //foreach (Form mainScreen in panelContent.Controls)
            //{
            //    mainScreen.Close();
            //    mainScreen.Dispose();
            //}

            //set new content
            form.TopLevel = false;
            panelContent.Controls.Add(form);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();

        }



        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            Employee form = new Employee();
            form.callAlert = new Employee.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonActivity_Click(object sender, EventArgs e)
        {
            ActivityHistory form = new ActivityHistory();
            form.callAlert = new ActivityHistory.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            form.callAlert = new Settings.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonDangXuat_Click(object sender, EventArgs e)
        {
            Common.USERSESSION = null;

            List<Form> oldForms = new List<Form>();
            foreach (Form oldForm in panelContent.Controls)
            {
                oldForms.Add(oldForm);
            }

            // Đóng/loại bỏ các FormItemPO cũ khỏi panelMain.Controls
            foreach (Form oldForm in oldForms)
            {
                oldForm.Close();
                oldForm.Dispose();
            }



            this.Close();
            Application.ExitThread();
        }

        private void buttonJigMach_Click(object sender, EventArgs e)
        {
            JigMach form = new JigMach();
            form.callAlert = new JigMach.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonLoiLoc_Click(object sender, EventArgs e)
        {
            LoiLoc form = new LoiLoc();
            form.callAlert = new LoiLoc.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonBauNong_Click(object sender, EventArgs e)
        {
            BauNong form = new BauNong();
            form.callAlert = new BauNong.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonBepTu_Click(object sender, EventArgs e)
        {
            BepTu form = new BepTu();
            form.callAlert = new BepTu.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonCongTac_Click(object sender, EventArgs e)
        {
            CongTac form = new CongTac();
            form.callAlert = new CongTac.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonNguon_Click(object sender, EventArgs e)
        {
            Nguon form = new Nguon();
            form.callAlert = new Nguon.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void buttonXoaData_Click(object sender, EventArgs e)
        {
            CaiDat form = new CaiDat();
            form.callAlert = new CaiDat.CallAlert(Alert);
            ChangeFormContent(form, sender);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //set new content
            Hello form = new Hello();
            form.TopLevel = false;
            panelContent.Controls.Add(form);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();

            this.Font = Common.FontForm;

        }
    }
}
