using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models.BauNongModel;
using ManagementSoftware.PLCSetting;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        Dictionary<TestBauNong, List<Models.BauNongModel.BauNong>> ListResults;


        public BauNong()
        {
            InitializeComponent();

            plc = new PLCBauNong(ControlAllPLC.ipBauNong, ControlAllPLC.PLCBauNong);
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

        PLCBauNong plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 1000;





        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.BauNongModel.BauNong> list = await plc.GetAllData();
            if (list != null && list.Count > 0)
            {
                UpdateData(list);
            }


            timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
        }



        private void SetTextControl(Button dongAC, Button nhietDo, Button nhietDoNgatCB, Button soLanTest, Button cbNhiet, Models.BauNongModel.BauNong bauNong)
        {
            dongAC.Text = bauNong.DongDienAC.ToString();
            nhietDo.Text = bauNong.NhietDo.ToString();
            nhietDoNgatCB.Text = bauNong.NhietDoNgatCBNhiet.ToString();
            soLanTest.Text = bauNong.SoLanTest.ToString();
            cbNhiet.Text = bauNong.CBNhietThanBauNong == true ? "on" : "off";
          
        }


        private void UpdateData(List<Models.BauNongModel.BauNong> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.BauNongModel.BauNong>>(UpdateData), list);
                return;
            }


            //update gui
            foreach (var item in list)
            {
                if (item.BauNongName == TenThietBi.BauNong1)
                {
                    SetTextControl(DongAC1, NhietDo1, NhietDoNgatCB1, SoLanTest1, CBNhiet1, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong2)
                {
                    SetTextControl(DongAC2, NhietDo2, NhietDoNgatCB2, SoLanTest2, CBNhiet2, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong3)
                {
                    SetTextControl(DongAC3, NhietDo3, NhietDoNgatCB3, SoLanTest3, CBNhiet3, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong4)
                {
                    SetTextControl(DongAC4, NhietDo4, NhietDoNgatCB4, SoLanTest4, CBNhiet4, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong5)
                {
                    SetTextControl(DongAC5, NhietDo5, NhietDoNgatCB5, SoLanTest5, CBNhiet5, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong6)
                {
                    SetTextControl(DongAC6, NhietDo6, NhietDoNgatCB6, SoLanTest6, CBNhiet6, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong7)
                {
                    SetTextControl(DongAC7, NhietDo7, NhietDoNgatCB7, SoLanTest7, CBNhiet7, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong8)
                {
                    SetTextControl(DongAC8, NhietDo8, NhietDoNgatCB8, SoLanTest8, CBNhiet8, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong9)
                {
                    SetTextControl(DongAC9, NhietDo9, NhietDoNgatCB9, SoLanTest9, CBNhiet9, item);
                }
                else if (item.BauNongName == TenThietBi.BauNong10)
                {
                    SetTextControl(DongAC10, NhietDo10, NhietDoNgatCB10, SoLanTest10, CBNhiet10, item);
                }
            }



        }

        private async void BauNong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
            }
            await plc.Close();
        }

        private async void BauNong_Load(object sender, EventArgs e)
        {
            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
            else
            {
                if (CheckLoad.checkBauNong == false)
                {
                    MessageBox.Show("Không thể kết nối tới " + plc.plcName, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CheckLoad.checkBauNong = true;
                }
            }

            LoadFormThongKe();
        }
    }
}
