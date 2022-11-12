using ManagementSoftware.GUI.Section;
using ManagementSoftware.PLCSetting;
using PROFINET_STEP_7.Profinet;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.JigMachManagement
{
    public partial class FormJigMachNguon : Form
    {
        public FormJigMachNguon()
        {
            InitializeComponent();
            timer1.Start();
        }
        public void GetDataJigMachNguon()
        {
            MainPLC.GetDataJigMachNguon();
            dong1.Text = DataPLC.DongDien[0].ToString();
            dong2.Text = DataPLC.DongDien[1].ToString();
            dong3.Text = DataPLC.DongDien[2].ToString();
            dong4.Text = DataPLC.DongDien[3].ToString();
            dong5.Text = DataPLC.DongDien[4].ToString();
            dong6.Text = DataPLC.DongDien[5].ToString();
            dong7.Text = DataPLC.DongDien[6].ToString();
            dong8.Text = DataPLC.DongDien[7].ToString();
            dong9.Text = DataPLC.DongDien[8].ToString();
            dong10.Text = DataPLC.DongDien[9].ToString();

            ap1.Text = DataPLC.DienAp[0].ToString();
            ap2.Text = DataPLC.DienAp[1].ToString();
            ap3.Text = DataPLC.DienAp[2].ToString();
            ap4.Text = DataPLC.DienAp[3].ToString();
            ap5.Text = DataPLC.DienAp[4].ToString();
            ap6.Text = DataPLC.DienAp[5].ToString();
            ap7.Text = DataPLC.DienAp[6].ToString();
            ap8.Text = DataPLC.DienAp[7].ToString();
            ap9.Text = DataPLC.DienAp[8].ToString();
            ap10.Text = DataPLC.DienAp[9].ToString();

            cs1.Text = DataPLC.CongSuat[0].ToString();
            cs2.Text = DataPLC.CongSuat[1].ToString();
            cs3.Text = DataPLC.CongSuat[2].ToString();
            cs4.Text = DataPLC.CongSuat[3].ToString();
            cs5.Text = DataPLC.CongSuat[4].ToString();
            cs6.Text = DataPLC.CongSuat[5].ToString();
            cs7.Text = DataPLC.CongSuat[6].ToString();
            cs8.Text = DataPLC.CongSuat[7].ToString();
            cs9.Text = DataPLC.CongSuat[8].ToString();
            cs10.Text = DataPLC.CongSuat[9].ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GetDataJigMachNguon();
        }
    }
}
