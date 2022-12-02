using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
using ManagementSoftware.PLCSetting;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class BauNong : Form
    {
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        // ngày để query 
        private DateTime? timeStart = null;
        private DateTime? timeEnd = null;
        // trang hiện tại
        private int page = 1;



        // tổng số trang
        private int TotalPages = 0;
        //Data
        Dictionary<TestBauNong, List<Models.BauNong>> ListResults;
        public BauNong()
        {
            InitializeComponent();

            LoadFormGiamSat();
            //LoadFormThongKe();
            timer1.Interval = 500;
        }

        void LoadFormThongKe()
        {
            panel2.Enabled = false;
            foreach (Form item in panelThongKe.Controls)
            {
                item.Close();
                item.Dispose();
            }
            panelThongKe.Controls.Clear();


            PaginationBauNong pagination = new PaginationBauNong();
            pagination.Set(page, timeStart, timeEnd);
            this.ListResults = pagination.ListResults;
            this.TotalPages = pagination.TotalPages;
            lbTotalPages.Text = this.TotalPages.ToString();

            buttonPreviousPage.Enabled = this.page > 1;
            buttonNextPage.Enabled = this.page < this.TotalPages;
            buttonPage.Text = this.page.ToString();

            pageNumberGoto.MinValue = 1;
            pageNumberGoto.MaxValue = this.TotalPages != 0 ? this.TotalPages : 1;
            
            for (int i = ListResults.Count - 1; i >= 0; i--)
            {
                ItemThongKeBauNong form = new ItemThongKeBauNong(ListResults.ElementAt(i).Key, ListResults.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
            panel2.Enabled = true;
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (this.page > 1)
            {
                this.page = this.page - 1;
                LoadFormThongKe();
            }
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (this.page < this.TotalPages)
            {
                this.page = this.page + 1;
                LoadFormThongKe();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            timeStart = TimeStart.Value;
            timeEnd = TimeEnd.Value;
            LoadFormThongKe();
        }

        private void buttonGoto_Click(object sender, EventArgs e)
        {
            this.page = int.Parse(pageNumberGoto.Text);
            LoadFormThongKe();
        }


















        // Giam sat
        PLCBauNong plcMain = new PLCBauNong();

        bool checkFisrtGetPageAndConnectPLCError = false;
        private void LoadFormGiamSat()
        {
            if (checkFisrtGetPageAndConnectPLCError == false)
            {
                plcMain.Start();

                if (plcMain.plc.IsConnected == true)
                {
                    if (timer1.Enabled == false)
                    {
                        timer1.Start();
                    }
                }
                else
                {
                    MessageBox.Show(plcMain.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkFisrtGetPageAndConnectPLCError = true;
                }
            }

        }

        private void tabControl1_Selected_1(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPageGiamSat)
            {
                LoadFormGiamSat();
            }
            else if (e.TabPage == tabPageThongKe)
            {
                if (timer1.Enabled == true)
                {
                    timer1.Stop();
                }
                LoadFormThongKe();
            }
        }

        private void timer1_Tick(object sender, EventArgs ea)
        {
            if (plcMain.plc.IsConnected == true)
            {
                plcMain.GetData();

                foreach (Models.BauNong e in plcMain.listBauNong)
                {
                    if (e.BauNongName == TenThietBi.BauNong1)
                    {
                        DongAC1.Text = e.DongDienAC.ToString();
                        NhietDo1.Text = e.NhietDo.ToString();
                        NhietDoNgatCB1.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest1.Text = e.SoLanTest.ToString();
                        CBNhiet1.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong2)
                    {
                        DongAC2.Text = e.DongDienAC.ToString();
                        NhietDo2.Text = e.NhietDo.ToString();
                        NhietDoNgatCB2.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest2.Text = e.SoLanTest.ToString();
                        CBNhiet2.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong3)
                    {
                        DongAC3.Text = e.DongDienAC.ToString();
                        NhietDo3.Text = e.NhietDo.ToString();
                        NhietDoNgatCB3.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest3.Text = e.SoLanTest.ToString();
                        CBNhiet3.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong4)
                    {
                        DongAC4.Text = e.DongDienAC.ToString();
                        NhietDo4.Text = e.NhietDo.ToString();
                        NhietDoNgatCB4.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest4.Text = e.SoLanTest.ToString();
                        CBNhiet4.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong5)
                    {
                        DongAC5.Text = e.DongDienAC.ToString();
                        NhietDo5.Text = e.NhietDo.ToString();
                        NhietDoNgatCB5.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest5.Text = e.SoLanTest.ToString();
                        CBNhiet5.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong6)
                    {
                        DongAC6.Text = e.DongDienAC.ToString();
                        NhietDo6.Text = e.NhietDo.ToString();
                        NhietDoNgatCB6.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest6.Text = e.SoLanTest.ToString();
                        CBNhiet6.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong7)
                    {
                        DongAC7.Text = e.DongDienAC.ToString();
                        NhietDo7.Text = e.NhietDo.ToString();
                        NhietDoNgatCB7.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest7.Text = e.SoLanTest.ToString();
                        CBNhiet7.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong8)
                    {
                        DongAC8.Text = e.DongDienAC.ToString();
                        NhietDo8.Text = e.NhietDo.ToString();
                        NhietDoNgatCB8.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest8.Text = e.SoLanTest.ToString();
                        CBNhiet8.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong9)
                    {
                        DongAC9.Text = e.DongDienAC.ToString();
                        NhietDo9.Text = e.NhietDo.ToString();
                        NhietDoNgatCB9.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest9.Text = e.SoLanTest.ToString();
                        CBNhiet9.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                    else if (e.BauNongName == TenThietBi.BauNong10)
                    {
                        DongAC10.Text = e.DongDienAC.ToString();
                        NhietDo10.Text = e.NhietDo.ToString();
                        NhietDoNgatCB10.Text = e.NhietDoNgatCBNhiet.ToString();
                        SoLanTest10.Text = e.SoLanTest.ToString();
                        CBNhiet10.Text = e.CBNhietThanBauNong == true ? "on" : "off";
                    }
                }
            }
            else
            {
                timer1.Stop();
            }
        }

    }
}
