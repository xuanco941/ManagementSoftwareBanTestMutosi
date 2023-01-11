using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models.BepTuModel;
using ManagementSoftware.PLCSetting;
using S7.Net;
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
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class BepTu : Form
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
        List<TestBepTu> ListResults = new List<TestBepTu>();
        public BepTu()
        {
            InitializeComponent();

            plc = new PLCBepTu(ControlAllPLC.ipBepTu, ControlAllPLC.PLCBepTu);
        }
        void LoadDGV()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Bầu nóng";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Dòng điện AC (A)";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Nhiệt độ (°C)";
            DataGridViewColumn congSuat = new DataGridViewTextBoxColumn();
            congSuat.HeaderText = "Nhiệt độ ngắt cb nhiệt (°C)";
            DataGridViewColumn ThoiGian = new DataGridViewTextBoxColumn();
            ThoiGian.HeaderText = "Trạng thái cb nhiệt";



            dataGridView1.Columns.Add(STT);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(lanTest);
            dataGridView1.Columns.Add(dienAp);
            dataGridView1.Columns.Add(dongDC);
            dataGridView1.Columns.Add(congSuat);
            dataGridView1.Columns.Add(ThoiGian);


            dataGridView1.RowTemplate.Height = 35;

        }
        void LoadFormThongKe()
        {
            panel2.Enabled = false;



            PaginationBepTu pagination = new PaginationBepTu();
            pagination.Set(page, timeStart, timeEnd);
            this.ListResults = pagination.ListResults;
            this.TotalPages = pagination.TotalPages;
            lbTotalPages.Text = this.TotalPages.ToString();

            buttonPreviousPage.Enabled = this.page > 1;
            buttonNextPage.Enabled = this.page < this.TotalPages;
            buttonPage.Text = this.page.ToString();

            pageNumberGoto.MinValue = 1;
            pageNumberGoto.MaxValue = this.TotalPages != 0 ? this.TotalPages : 1;


            panel2.Enabled = true;
        }

        private void buttonPreviousPage_Click_1(object sender, EventArgs e)
        {
            if (this.page > 1)
            {
                this.page = this.page - 1;
                LoadFormThongKe();
            }
        }

        private void buttonNextPage_Click_1(object sender, EventArgs e)
        {
            if (this.page < this.TotalPages)
            {
                this.page = this.page + 1;
                LoadFormThongKe();
            }
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            timeStart = TimeStart.Value;
            timeEnd = TimeEnd.Value;
            LoadFormThongKe();
        }

        private void buttonGoto_Click_1(object sender, EventArgs e)
        {
            this.page = int.Parse(pageNumberGoto.Text);
            LoadFormThongKe();
        }

        private async void BepTu_Load(object sender, EventArgs e)
        {
            LoadDGV();
            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
            LoadFormThongKe();
        }

        private async void BepTu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            await plc.Close();
        }






        // Giam sat

        PLCBepTu plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 1000;





        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.BepTuModel.BepTu> list = await plc.GetAllData();
            if (list != null && list.Count > 0)
            {
                UpdateData(list);
            }


            timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
        }



        private void SetTextControl(Button dongAC, Button nhietDo, Button nhietdoNgatCB, Button soLanTest, Button cbNhiet, Models.BauNongModel.BauNong bauNong)
        {
            dongAC.Text = String.Format("{0:0.00}", bauNong.DongDien) + " A";
            nhietDo.Text = String.Format("{0:0.00}", bauNong.NhietDo) + " °C";
            nhietdoNgatCB.Text = bauNong.NhietDoNgatCBNhiet.ToString() + " °C";
            soLanTest.Text = bauNong.LanTestThu.ToString();
            cbNhiet.Text = bauNong.TrangThaiCBNhiet == true ? "ON" : "OFF";

        }


        private void UpdateData(List<Models.BepTuModel.BepTu> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.BepTuModel.BepTu>>(UpdateData), list);
                return;
            }

            //update gui

            //update gui
            //foreach (var item in list)
            //{
            //    if (item.BauNongName == TenThietBi.BauNong1)
            //    {
            //        SetTextControl(DongAC1, NhietDo1, NhietDoNgatCB1, SoLanTest1, CBNhiet1, item);
            //    }
            //}
        }
    }
}
