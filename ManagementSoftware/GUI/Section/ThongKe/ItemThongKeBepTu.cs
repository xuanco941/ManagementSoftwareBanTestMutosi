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
    public partial class ItemThongKeBepTu : Form
    {
        public ItemThongKeBepTu(TestBepTu testID, List<Models.BepTu> bepTus)
        {
            InitializeComponent();
            TimeID.Text = $"ID{testID.TestBepTuID} - (" + testID.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture) + ")";


            foreach (var e in bepTus)
            {
                if (e.BepTuName == TenThietBi.BepTu1)
                {
                    NameBepTu1.Text = e.BepTuName;
                    DongACBep1.Text = e.DongAC.ToString();
                    ApACBep1.Text = e.ApAC.ToString();
                    CongSuatACBep1.Text = e.CongSuatAC.ToString();
                    NhietDoBep1.Text = e.NhietDo.ToString();
                    ThoiGianSoi1.Text = e.ThoiGianSoi.ToString() + " phút";
                    SoLanTest1.Text = e.SoLanTest.ToString();
                }
                else if (e.BepTuName == TenThietBi.BepTu2)
                {
                    NameBepTu2.Text = e.BepTuName;
                    DongACBep2.Text = e.DongAC.ToString();
                    ApACBep2.Text = e.ApAC.ToString();
                    CongSuatACBep2.Text = e.CongSuatAC.ToString();
                    NhietDoBep2.Text = e.NhietDo.ToString();
                    ThoiGianSoi2.Text = e.ThoiGianSoi.ToString() + " phút";
                    SoLanTest2.Text = e.SoLanTest.ToString();
                }

            }

        }
    }
}
