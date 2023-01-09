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
using ManagementSoftware.Models.BauNongModel;
using ManagementSoftware.Models.BepTuModel;
using ManagementSoftware.Models.CongTacModel;
using ManagementSoftware.Models.LoiLocModel;
using ManagementSoftware.Models.NguonModel;
using ManagementSoftware.PLCSetting;
using ManagementSoftware.Properties;

namespace ManagementSoftware.GUI
{
    public partial class Settings : Form
    {

        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        public PLCBauNong plcBauNong = new PLCBauNong(ControlAllPLC.ipBauNong, ControlAllPLC.PLCBauNong);
        public PLCBepTu plcBepTu = new PLCBepTu(ControlAllPLC.ipBepTu, ControlAllPLC.PLCBepTu);
        public PLCCongTac plcCongTac = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
        public PLCLoiLoc plcLoiLoc = new PLCLoiLoc(ControlAllPLC.ipLoiLoc, ControlAllPLC.PLCLoiLoc);
        public PLCMach plcMach = new PLCMach(ControlAllPLC.ipMach, ControlAllPLC.PLCMach);
        public PLCNguon plcNguon = new PLCNguon(ControlAllPLC.ipNguon, ControlAllPLC.PLCNguon);

        async void LoadBauNong()
        {
            if (await plcBauNong.Open() == true)
            {
                buttonConnectBauNong.Text = "Đã kết nối";
                buttonConnectBauNong.BackColor = Color.Green;
                buttonConnectBauNong.Image = Resources.ico_select_min;
                labelBauNong.Text = "PLC Jig Bầu Nóng đã kết nối với PC thành công";
            }
            else
            {
                labelBauNong.Text = "Chưa thể kết nối tới " + plcBauNong.plcName;
            }
        }
        async void LoadBepTu()
        {
            if (await plcBepTu.Open() == true)
            {
                buttonCustomBepTu.Text = "Đã kết nối";
                buttonCustomBepTu.BackColor = Color.Green;
                buttonCustomBepTu.Image = Resources.ico_select_min;
                labelBepTu.Text = "PLC Jig Bếp Từ đã kết nối với PC thành công";
            }
            else
            {
                labelBepTu.Text = "Chưa thể kết nối tới " + plcBepTu.plcName;
            }
        }
        async void LoadCongTac()
        {
            if (await plcCongTac.Open() == true)
            {
                buttonCustomCongTac.Text = "Đã kết nối";
                buttonCustomCongTac.BackColor = Color.Green;
                buttonCustomCongTac.Image = Resources.ico_select_min;
                labelCongTac.Text = "PLC Jig Công Tắc đã kết nối với PC thành công";
            }
            else
            {
                labelCongTac.Text = "Chưa thể kết nối tới " + plcCongTac.plcName;
            }
        }
        async void LoadLoiLoc()
        {

            if (await plcLoiLoc.Open() == true)
            {
                buttonCustomLoiLoc.Text = "Đã kết nối";
                buttonCustomLoiLoc.BackColor = Color.Green;
                buttonCustomLoiLoc.Image = Resources.ico_select_min;
                labelLoiLoc.Text = "PLC Jig Lõi Lọc đã kết nối với PC thành công";
            }
            else
            {
                labelLoiLoc.Text = "Chưa thể kết nối tới " + plcLoiLoc.plcName;
            }
        }
        async void LoadJigMach()
        {
            if (await plcMach.Open() == true)
            {
                buttonCustomJigMach.Text = "Đã kết nối";
                buttonCustomJigMach.BackColor = Color.Green;
                buttonCustomJigMach.Image = Resources.ico_select_min;
                labelJigMach.Text = "PLC Jig Mạch đã kết nối với PC thành công";
            }
            else
            {
                labelJigMach.Text = "Chưa thể kết nối tới " + plcMach.plcName;
            }
        }
        async void LoadNguon()
        {
            if (await plcNguon.Open() == true)
            {
                buttonCustomNguon.Text = "Đã kết nối";
                buttonCustomNguon.BackColor = Color.Green;
                buttonCustomNguon.Image = Resources.ico_select_min;
                labelNguon.Text = "PLC Jig Nguồn đã kết nối với PC thành công";
            }
            else
            {
                labelNguon.Text = "Chưa thể kết nối tới " + plcNguon.plcName;
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

        
    }
}
