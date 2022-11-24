using ManagementSoftware.Models;
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

namespace ManagementSoftware.GUI.Section.ThongKe
{
    public partial class ItemThongKeJigMach : Form
    {
        public ItemThongKeJigMach(TestJigMach testID, List<Models.JigMachNguon> jigMachNguon, List<Models.JigMachTDS> jigMachTDs)
        {
            InitializeComponent();
            TimeID.Text = $"ID{testID.TestJigMachID} - (" + testID.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture) + ")";


            foreach (var e in jigMachNguon)
            {
                if (e.JigMachNguonName == TenThietBi.JigMachNguon1)
                {
                    JigMachNguon1.Text = e.JigMachNguonName;
                    DongDien1.Text = e.DongDien.ToString();
                    DienAp1.Text = e.DienAp.ToString();
                    CongSuat1.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon2)
                {
                    JigMachNguon2.Text = e.JigMachNguonName;
                    DongDien2.Text = e.DongDien.ToString();
                    DienAp2.Text = e.DienAp.ToString();
                    CongSuat2.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon3)
                {
                    JigMachNguon3.Text = e.JigMachNguonName;
                    DongDien3.Text = e.DongDien.ToString();
                    DienAp3.Text = e.DienAp.ToString();
                    CongSuat3.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon4)
                {
                    JigMachNguon4.Text = e.JigMachNguonName;
                    DongDien4.Text = e.DongDien.ToString();
                    DienAp4.Text = e.DienAp.ToString();
                    CongSuat4.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon5)
                {
                    JigMachNguon5.Text = e.JigMachNguonName;
                    DongDien5.Text = e.DongDien.ToString();
                    DienAp5.Text = e.DienAp.ToString();
                    CongSuat5.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon6)
                {
                    JigMachNguon6.Text = e.JigMachNguonName;
                    DongDien6.Text = e.DongDien.ToString();
                    DienAp6.Text = e.DienAp.ToString();
                    CongSuat6.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon7)
                {
                    JigMachNguon7.Text = e.JigMachNguonName;
                    DongDien7.Text = e.DongDien.ToString();
                    DienAp7.Text = e.DienAp.ToString();
                    CongSuat7.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon8)
                {
                    JigMachNguon8.Text = e.JigMachNguonName;
                    DongDien8.Text = e.DongDien.ToString();
                    DienAp8.Text = e.DienAp.ToString();
                    CongSuat8.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon9)
                {
                    JigMachNguon9.Text = e.JigMachNguonName;
                    DongDien9.Text = e.DongDien.ToString();
                    DienAp9.Text = e.DienAp.ToString();
                    CongSuat9.Text = e.CongSuat.ToString();
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon10)
                {
                    JigMachNguon10.Text = e.JigMachNguonName;
                    DongDien10.Text = e.DongDien.ToString();
                    DienAp10.Text = e.DienAp.ToString();
                    CongSuat10.Text = e.CongSuat.ToString();
                }
            }


            foreach (var e in jigMachTDs)
            {
                if (e.JigMachTDSName == TenThietBi.JigMachTDS1)
                {
                    JigMachTDS1.Text = e.JigMachTDSName;
                    ApDC1.Text = e.ApDC.ToString();
                    Van1.Text = e.Van == true ? "on" : "off";
                    CBApSuat1.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS2)
                {
                    JigMachTDS2.Text = e.JigMachTDSName;
                    ApDC2.Text = e.ApDC.ToString();
                    Van2.Text = e.Van == true ? "on" : "off";
                    CBApSuat2.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS3)
                {
                    JigMachTDS3.Text = e.JigMachTDSName;
                    ApDC3.Text = e.ApDC.ToString();
                    Van3.Text = e.Van == true ? "on" : "off";
                    CBApSuat3.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS4)
                {
                    JigMachTDS4.Text = e.JigMachTDSName;
                    ApDC4.Text = e.ApDC.ToString();
                    Van4.Text = e.Van == true ? "on" : "off";
                    CBApSuat4.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS5)
                {
                    JigMachTDS5.Text = e.JigMachTDSName;
                    ApDC5.Text = e.ApDC.ToString();
                    Van5.Text = e.Van == true ? "on" : "off";
                    CBApSuat5.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS6)
                {
                    JigMachTDS6.Text = e.JigMachTDSName;
                    ApDC6.Text = e.ApDC.ToString();
                    Van6.Text = e.Van == true ? "on" : "off";
                    CBApSuat6.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS7)
                {
                    JigMachTDS7.Text = e.JigMachTDSName;
                    ApDC7.Text = e.ApDC.ToString();
                    Van7.Text = e.Van == true ? "on" : "off";
                    CBApSuat7.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS8)
                {
                    JigMachTDS8.Text = e.JigMachTDSName;
                    ApDC8.Text = e.ApDC.ToString();
                    Van8.Text = e.Van == true ? "on" : "off";
                    CBApSuat8.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS9)
                {
                    JigMachTDS9.Text = e.JigMachTDSName;
                    ApDC9.Text = e.ApDC.ToString();
                    Van9.Text = e.Van == true ? "on" : "off";
                    CBApSuat9.Text = e.CBApSuat == true ? "on" : "off";
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachTDS10)
                {
                    JigMachTDS10.Text = e.JigMachTDSName;
                    ApDC10.Text = e.ApDC.ToString();
                    Van10.Text = e.Van == true ? "on" : "off";
                    CBApSuat10.Text = e.CBApSuat == true ? "on" : "off";
                }

            }



        }
    }
}
