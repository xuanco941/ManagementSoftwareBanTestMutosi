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
    public partial class ItemThongKeNguon : Form
    {
        public ItemThongKeNguon(TestNguon testID, List<Models.Nguon> nguon)
        {
            InitializeComponent();
            TimeID.Text = $"ID{testID.TestNguonID} - (" + testID.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture) + ")";

            foreach (var e in nguon)
            {
                if (e.NguonName == TenThietBi.Nguon1)
                {
                    DongDC1.Text = e.DongDC.ToString();
                    DienAp1.Text = e.DienApDC.ToString();
                    CongSuat1.Text = e.CongSuat.ToString();
                    ThoiGianTest1.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest1.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon2)
                {
                    DongDC2.Text = e.DongDC.ToString();
                    DienAp2.Text = e.DienApDC.ToString();
                    CongSuat2.Text = e.CongSuat.ToString();
                    ThoiGianTest2.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest2.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon3)
                {
                    DongDC3.Text = e.DongDC.ToString();
                    DienAp3.Text = e.DienApDC.ToString();
                    CongSuat3.Text = e.CongSuat.ToString();
                    ThoiGianTest3.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest3.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon4)
                {
                    DongDC4.Text = e.DongDC.ToString();
                    DienAp4.Text = e.DienApDC.ToString();
                    CongSuat4.Text = e.CongSuat.ToString();
                    ThoiGianTest4.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest4.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon5)
                {
                    DongDC5.Text = e.DongDC.ToString();
                    DienAp5.Text = e.DienApDC.ToString();
                    CongSuat5.Text = e.CongSuat.ToString();
                    ThoiGianTest5.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest5.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon6)
                {
                    DongDC6.Text = e.DongDC.ToString();
                    DienAp6.Text = e.DienApDC.ToString();
                    CongSuat6.Text = e.CongSuat.ToString();
                    ThoiGianTest6.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest6.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon7)
                {
                    DongDC7.Text = e.DongDC.ToString();
                    DienAp7.Text = e.DienApDC.ToString();
                    CongSuat7.Text = e.CongSuat.ToString();
                    ThoiGianTest7.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest7.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon8)
                {
                    DongDC8.Text = e.DongDC.ToString();
                    DienAp8.Text = e.DienApDC.ToString();
                    CongSuat8.Text = e.CongSuat.ToString();
                    ThoiGianTest8.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest8.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon9)
                {
                    DongDC9.Text = e.DongDC.ToString();
                    DienAp9.Text = e.DienApDC.ToString();
                    CongSuat9.Text = e.CongSuat.ToString();
                    ThoiGianTest9.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest9.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon10)
                {
                    DongDC10.Text = e.DongDC.ToString();
                    DienAp10.Text = e.DienApDC.ToString();
                    CongSuat10.Text = e.CongSuat.ToString();
                    ThoiGianTest10.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest10.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon11)
                {
                    DongDC11.Text = e.DongDC.ToString();
                    DienAp11.Text = e.DienApDC.ToString();
                    CongSuat11.Text = e.CongSuat.ToString();
                    ThoiGianTest11.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest11.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon12)
                {
                    DongDC12.Text = e.DongDC.ToString();
                    DienAp12.Text = e.DienApDC.ToString();
                    CongSuat12.Text = e.CongSuat.ToString();
                    ThoiGianTest12.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest12.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon13)
                {
                    DongDC13.Text = e.DongDC.ToString();
                    DienAp13.Text = e.DienApDC.ToString();
                    CongSuat13.Text = e.CongSuat.ToString();
                    ThoiGianTest13.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest13.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon14)
                {
                    DongDC14.Text = e.DongDC.ToString();
                    DienAp14.Text = e.DienApDC.ToString();
                    CongSuat14.Text = e.CongSuat.ToString();
                    ThoiGianTest14.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest14.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon15)
                {
                    DongDC15.Text = e.DongDC.ToString();
                    DienAp15.Text = e.DienApDC.ToString();
                    CongSuat15.Text = e.CongSuat.ToString();
                    ThoiGianTest15.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest15.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon16)
                {
                    DongDC16.Text = e.DongDC.ToString();
                    DienAp16.Text = e.DienApDC.ToString();
                    CongSuat16.Text = e.CongSuat.ToString();
                    ThoiGianTest16.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest16.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon17)
                {
                    DongDC17.Text = e.DongDC.ToString();
                    DienAp17.Text = e.DienApDC.ToString();
                    CongSuat17.Text = e.CongSuat.ToString();
                    ThoiGianTest17.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest17.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon18)
                {
                    DongDC18.Text = e.DongDC.ToString();
                    DienAp18.Text = e.DienApDC.ToString();
                    CongSuat18.Text = e.CongSuat.ToString();
                    ThoiGianTest18.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest18.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon19)
                {
                    DongDC19.Text = e.DongDC.ToString();
                    DienAp19.Text = e.DienApDC.ToString();
                    CongSuat19.Text = e.CongSuat.ToString();
                    ThoiGianTest19.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest19.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon20)
                {
                    DongDC20.Text = e.DongDC.ToString();
                    DienAp20.Text = e.DienApDC.ToString();
                    CongSuat20.Text = e.CongSuat.ToString();
                    ThoiGianTest20.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest20.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon21)
                {
                    DongDC21.Text = e.DongDC.ToString();
                    DienAp21.Text = e.DienApDC.ToString();
                    CongSuat21.Text = e.CongSuat.ToString();
                    ThoiGianTest21.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest21.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon22)
                {
                    DongDC22.Text = e.DongDC.ToString();
                    DienAp22.Text = e.DienApDC.ToString();
                    CongSuat22.Text = e.CongSuat.ToString();
                    ThoiGianTest22.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest22.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon23)
                {
                    DongDC23.Text = e.DongDC.ToString();
                    DienAp23.Text = e.DienApDC.ToString();
                    CongSuat23.Text = e.CongSuat.ToString();
                    ThoiGianTest23.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest23.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon24)
                {
                    DongDC24.Text = e.DongDC.ToString();
                    DienAp24.Text = e.DienApDC.ToString();
                    CongSuat24.Text = e.CongSuat.ToString();
                    ThoiGianTest24.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest24.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon25)
                {
                    DongDC25.Text = e.DongDC.ToString();
                    DienAp25.Text = e.DienApDC.ToString();
                    CongSuat25.Text = e.CongSuat.ToString();
                    ThoiGianTest25.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest25.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon26)
                {
                    DongDC26.Text = e.DongDC.ToString();
                    DienAp26.Text = e.DienApDC.ToString();
                    CongSuat26.Text = e.CongSuat.ToString();
                    ThoiGianTest26.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest26.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon27)
                {
                    DongDC27.Text = e.DongDC.ToString();
                    DienAp27.Text = e.DienApDC.ToString();
                    CongSuat27.Text = e.CongSuat.ToString();
                    ThoiGianTest27.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest27.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon28)
                {
                    DongDC28.Text = e.DongDC.ToString();
                    DienAp28.Text = e.DienApDC.ToString();
                    CongSuat28.Text = e.CongSuat.ToString();
                    ThoiGianTest28.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest28.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon29)
                {
                    DongDC29.Text = e.DongDC.ToString();
                    DienAp29.Text = e.DienApDC.ToString();
                    CongSuat29.Text = e.CongSuat.ToString();
                    ThoiGianTest29.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest29.Text = e.SoLanTest.ToString();
                }
                else if (e.NguonName == TenThietBi.Nguon30)
                {
                    DongDC30.Text = e.DongDC.ToString();
                    DienAp30.Text = e.DienApDC.ToString();
                    CongSuat30.Text = e.CongSuat.ToString();
                    ThoiGianTest30.Text = e.ThoiGianTest.ToString() + " giây";
                    SoLanTest30.Text = e.SoLanTest.ToString();
                }
            }
        }
    }
}
