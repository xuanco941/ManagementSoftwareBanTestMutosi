using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.PLCSetting;
using ManagementSoftware.Properties;

namespace ManagementSoftware.GUI
{
    public partial class Settings : Form
    {

        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;


        void LoadBauNong()
        {
            if (PLCBauNong.plc.IsConnected == true)
            {
                buttonConnectBauNong.Text = "Đã kết nối";
                buttonConnectBauNong.BackColor = Color.Green;
                buttonConnectBauNong.Image = Resources.ico_select_min;
                buttonConnectBauNong.Enabled = false;
                labelBauNong.Text = "PLC Jig Bầu Nóng đã kết nối với PC thành công";
            }
            else
            {
                labelBauNong.Text = PLCBauNong.message;
            }
        }
        void LoadBepTu()
        {
            if (PLCBepTu.plc.IsConnected == true)
            {
                buttonCustomBepTu.Text = "Đã kết nối";
                buttonCustomBepTu.BackColor = Color.Green;
                buttonCustomBepTu.Image = Resources.ico_select_min;
                buttonConnectBauNong.Enabled = false;
                labelBepTu.Text = "PLC Jig Bếp Từ đã kết nối với PC thành công";
            }
            else
            {
                labelBepTu.Text = PLCBepTu.message;
            }
        }
        void LoadCongTac()
        {
            if (PLCCongTac.plc.IsConnected == true)
            {
                buttonCustomCongTac.Text = "Đã kết nối";
                buttonCustomCongTac.BackColor = Color.Green;
                buttonCustomCongTac.Image = Resources.ico_select_min;
                buttonCustomCongTac.Enabled = false;
                labelCongTac.Text = "PLC Jig Công Tắc đã kết nối với PC thành công";
            }
            else
            {
                labelCongTac.Text = PLCCongTac.message;
            }
        }
        void LoadLoiLoc()
        {

            if (PLCJigLoiLoc.plc.IsConnected == true)
            {
                buttonCustomLoiLoc.Text = "Đã kết nối";
                buttonCustomLoiLoc.BackColor = Color.Green;
                buttonCustomLoiLoc.Image = Resources.ico_select_min;
                buttonCustomLoiLoc.Enabled = false;
                labelLoiLoc.Text = "PLC Jig Lõi Lọc đã kết nối với PC thành công";
            }
            else
            {
                labelLoiLoc.Text = PLCJigLoiLoc.message;
            }
        }
        void LoadJigMach()
        {
            if (PLCJigMach.plc.IsConnected == true)
            {
                buttonCustomJigMach.Text = "Đã kết nối";
                buttonCustomJigMach.BackColor = Color.Green;
                buttonCustomJigMach.Image = Resources.ico_select_min;
                buttonCustomJigMach.Enabled = false;
                labelJigMach.Text = "PLC Jig Mạch đã kết nối với PC thành công";
            }
            else
            {
                labelJigMach.Text = PLCJigMach.message;
            }
        }
        void LoadNguon()
        {
            if (PLCNguon.plc.IsConnected == true)
            {
                buttonCustomNguon.Text = "Đã kết nối";
                buttonCustomNguon.BackColor = Color.Green;
                buttonCustomNguon.Image = Resources.ico_select_min;
                buttonCustomNguon.Enabled = false;
                labelNguon.Text = "PLC Jig Nguồn đã kết nối với PC thành công";
            }
            else
            {
                labelNguon.Text = PLCNguon.message;
            }
        }
        public Settings()
        {
            InitializeComponent();
            LoadBauNong();
            LoadBepTu();
            LoadCongTac();
            LoadJigMach();
            LoadLoiLoc();
            LoadNguon();
        }

        private void buttonConnectBauNong_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            ControlAllPLC.RunBauNong();
            if(PLCBauNong.plc.IsConnected == true)
            {
                callAlert?.Invoke("PLC Jig Bầu Nóng đã kết nối", FormAlert.enmType.Success);
            }
            else
            {
                callAlert?.Invoke(PLCBauNong.message, FormAlert.enmType.Error);
            }
            LoadBauNong();
            tableLayoutPanel1.Enabled = true;

        }

        private void buttonCustomBepTu_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            ControlAllPLC.RunBepTu();
            if (PLCBepTu.plc.IsConnected == true)
            {
                callAlert?.Invoke("PLC Jig Bếp Từ đã kết nối", FormAlert.enmType.Success);
            }
            else
            {
                callAlert?.Invoke(PLCBepTu.message, FormAlert.enmType.Error);
            }
            LoadBepTu();
            tableLayoutPanel1.Enabled = true;

        }

        private void buttonCustomCongTac_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            ControlAllPLC.RunCongTac();
            if (PLCCongTac.plc.IsConnected == true)
            {
                callAlert?.Invoke("PLC Jig Công Tắc đã kết nối", FormAlert.enmType.Success);
            }
            else
            {
                callAlert?.Invoke(PLCCongTac.message, FormAlert.enmType.Error);
            }
            LoadCongTac();
            tableLayoutPanel1.Enabled = true;

        }

        private void buttonCustomJigMach_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            ControlAllPLC.RunJigMach();
            if (PLCJigMach.plc.IsConnected == true)
            {
                callAlert?.Invoke("PLC Jig Mạch đã kết nối", FormAlert.enmType.Success);
            }
            else
            {
                callAlert?.Invoke(PLCJigMach.message, FormAlert.enmType.Error);
            }
            LoadJigMach();
            tableLayoutPanel1.Enabled = true;

        }

        private void buttonCustomLoiLoc_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            ControlAllPLC.RunLoiLoc();
            if (PLCJigLoiLoc.plc.IsConnected == true)
            {
                callAlert?.Invoke("PLC Jig Lõi Lọc đã kết nối", FormAlert.enmType.Success);
            }
            else
            {
                callAlert?.Invoke(PLCJigLoiLoc.message, FormAlert.enmType.Error);
            }
            LoadLoiLoc();
            tableLayoutPanel1.Enabled = true;

        }

        private void buttonCustomNguon_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Enabled = false;
            ControlAllPLC.RunNguon();
            if (PLCNguon.plc.IsConnected == true)
            {
                callAlert?.Invoke("PLC Jig Nguồn đã kết nối", FormAlert.enmType.Success);
            }
            else
            {
                callAlert?.Invoke(PLCNguon.message, FormAlert.enmType.Error);
            }
            LoadNguon();
            tableLayoutPanel1.Enabled = true;

        }
    }
}
