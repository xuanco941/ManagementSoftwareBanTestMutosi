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
    public partial class ItemThongKeBauNong : Form
    {
        public ItemThongKeBauNong(TestBauNong testID, List<Models.BauNong> bauNongs)
        {
            InitializeComponent();
            TimeID.Text = $"ID{testID.TestBauNongID} - (" + testID.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture) + ")";

            foreach (var e in bauNongs)
            {
                if (e.BauNongName == TenThietBi.BauNong1)
                {
                    nameBauNong1.Text = e.BauNongName;
                    DongAC1.Text = e.DongDienAC.ToString();
                    NhietDo1.Text = e.NhietDo.ToString();
                    ThoiGianNgat1.Text = e.SoLanTest.ToString();
                    CamBienNhiet1.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB1.Text = e.NhietDoNgatCBNhiet.ToString();
                }
                else if (e.BauNongName == TenThietBi.BauNong2)
                {
                    nameBauNong2.Text = e.BauNongName;
                    DongAC2.Text = e.DongDienAC.ToString();
                    NhietDo2.Text = e.NhietDo.ToString();
                    ThoiGianNgat2.Text = e.SoLanTest.ToString();
                    CamBienNhiet2.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB2.Text = e.NhietDoNgatCBNhiet.ToString();

                }
                else if (e.BauNongName == TenThietBi.BauNong3)
                {
                    nameBauNong3.Text = e.BauNongName;
                    DongAC3.Text = e.DongDienAC.ToString();
                    NhietDo3.Text = e.NhietDo.ToString();
                    ThoiGianNgat3.Text = e.SoLanTest.ToString();
                    CamBienNhiet3.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB3.Text = e.NhietDoNgatCBNhiet.ToString();

                }
                else if (e.BauNongName == TenThietBi.BauNong4)
                {
                    nameBauNong4.Text = e.BauNongName;
                    DongAC4.Text = e.DongDienAC.ToString();
                    NhietDo4.Text = e.NhietDo.ToString();
                    ThoiGianNgat4.Text = e.SoLanTest.ToString();
                    CamBienNhiet4.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB4.Text = e.NhietDoNgatCBNhiet.ToString();

                }
                else if (e.BauNongName == TenThietBi.BauNong5)
                {
                    nameBauNong5.Text = e.BauNongName;
                    DongAC5.Text = e.DongDienAC.ToString();
                    NhietDo5.Text = e.NhietDo.ToString();
                    ThoiGianNgat5.Text = e.SoLanTest.ToString();
                    CamBienNhiet5.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB5.Text = e.NhietDoNgatCBNhiet.ToString();

                }
                else if (e.BauNongName == TenThietBi.BauNong6)
                {
                    nameBauNong6.Text = e.BauNongName;
                    DongAC6.Text = e.DongDienAC.ToString();
                    NhietDo6.Text = e.NhietDo.ToString();
                    ThoiGianNgat6.Text = e.SoLanTest.ToString();
                    CamBienNhiet6.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB6.Text = e.NhietDoNgatCBNhiet.ToString();
                }
                else if (e.BauNongName == TenThietBi.BauNong7)
                {
                    nameBauNong7.Text = e.BauNongName;
                    DongAC7.Text = e.DongDienAC.ToString();
                    NhietDo7.Text = e.NhietDo.ToString();
                    ThoiGianNgat7.Text = e.SoLanTest.ToString();
                    CamBienNhiet7.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB7.Text = e.NhietDoNgatCBNhiet.ToString();
                }
                else if (e.BauNongName == TenThietBi.BauNong8)
                {
                    nameBauNong8.Text = e.BauNongName;
                    DongAC8.Text = e.DongDienAC.ToString();
                    NhietDo8.Text = e.NhietDo.ToString();
                    ThoiGianNgat8.Text = e.SoLanTest.ToString();
                    CamBienNhiet8.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB8.Text = e.NhietDoNgatCBNhiet.ToString();

                }
                else if (e.BauNongName == TenThietBi.BauNong9)
                {
                    nameBauNong9.Text = e.BauNongName;
                    DongAC9.Text = e.DongDienAC.ToString();
                    NhietDo9.Text = e.NhietDo.ToString();
                    ThoiGianNgat9.Text = e.SoLanTest.ToString();
                    CamBienNhiet9.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB9.Text = e.NhietDoNgatCBNhiet.ToString();

                }
                else if (e.BauNongName == TenThietBi.BauNong10)
                {
                    nameBauNong10.Text = e.BauNongName;
                    DongAC10.Text = e.DongDienAC.ToString();
                    NhietDo10.Text = e.NhietDo.ToString();
                    ThoiGianNgat10.Text = e.SoLanTest.ToString();
                    CamBienNhiet10.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    NhietDoCB10.Text = e.NhietDoNgatCBNhiet.ToString();
                }

            }
        }
    }
}
