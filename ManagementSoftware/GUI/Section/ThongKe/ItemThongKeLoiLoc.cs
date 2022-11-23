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
    public partial class ItemThongKeLoiLoc : Form
    {
        public ItemThongKeLoiLoc(TestLoiLoc testID, List<Models.LoiLoc> loiLoc)
        {
            InitializeComponent();

            TimeID.Text = $"ID{testID.TestLoiLocID}(" + testID.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture) + ")";

            foreach (var e in loiLoc)
            {
                if (e.LoiLocName == TenThietBi.LoiLoc1)
                {
                    nameLoiLoc1.Text = e.LoiLocName;
                    SoLanTest1.Text = e.SoLanTest.ToString();
                    ApSuatTest1.Text = e.ApSuatTest.ToString();
                    ThoiGianNen1.Text = e.ThoiGianNen.ToString();
                    ThoiGianXa1.Text = e.ThoiGianXa.ToString();
                    ThoiGianGiu1.Text = e.ThoiGianGiu.ToString();
                }
                if (e.LoiLocName == TenThietBi.LoiLoc2)
                {
                    nameLoiLoc2.Text = e.LoiLocName;
                    SoLanTest2.Text = e.SoLanTest.ToString();
                    ApSuatTest2.Text = e.ApSuatTest.ToString();
                    ThoiGianNen2.Text = e.ThoiGianNen.ToString();
                    ThoiGianXa2.Text = e.ThoiGianXa.ToString();
                    ThoiGianGiu2.Text = e.ThoiGianGiu.ToString();
                }
                if (e.LoiLocName == TenThietBi.LoiLoc1va2)
                {
                    nameLoiLoc1va2.Text = e.LoiLocName;
                    SoLanTest1va2.Text = e.SoLanTest.ToString();
                    ApSuatTest1va2.Text = e.ApSuatTest.ToString();
                    ThoiGianNen1va2.Text = e.ThoiGianNen.ToString();
                    ThoiGianXa1va2.Text = e.ThoiGianXa.ToString();
                    ThoiGianGiu1va2.Text = e.ThoiGianGiu.ToString();
                }

            }

        }
    }
}
