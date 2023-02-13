using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models.BauNongModel;
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
using System.Globalization;
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
            name.HeaderText = "Bếp từ";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Nhiệt độ (°C)";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Điện áp (V)";
            DataGridViewColumn congSuat = new DataGridViewTextBoxColumn();
            congSuat.HeaderText = "Dòng điện (A)";
            DataGridViewColumn ThoiGian = new DataGridViewTextBoxColumn();
            ThoiGian.HeaderText = "Công suất (Kw)";
            DataGridViewColumn cstt = new DataGridViewTextBoxColumn();
            cstt.HeaderText = "Công suất (Kw)";



            dataGridView1.Columns.Add(STT);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(lanTest);
            dataGridView1.Columns.Add(dienAp);
            dataGridView1.Columns.Add(dongDC);
            dataGridView1.Columns.Add(congSuat);
            dataGridView1.Columns.Add(ThoiGian);
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Công suất tiêu thụ(Kwh)" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Trạng thái" });


            dataGridView1.RowTemplate.Height = 35;

        }


        System.Threading.Timer? timer2 = null;

        private void StopTimer()
        {
            if (timer2 != null)
            {
                this.timer2.Change(Timeout.Infinite, Timeout.Infinite);
                timer2.Dispose();
                timer2 = null;
            }
        }
        private void StartTimer()
        {
            if (timer2 == null)
            {
                timer2 = new System.Threading.Timer(Callback2, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
        }

        private async void Callback2(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation
            PaginationBepTu pagination = new PaginationBepTu();
            pagination.Set(page, timeStart, timeEnd);
            // Nếu có dữ liệu mới và khác với dữ liệu cũ
            if (pagination.ListResults != null && pagination.ListResults.Count > 0
                && (!this.ListResults?.SequenceEqual(pagination.ListResults) ?? true))
            {
                this.ListResults = new List<Models.BepTuModel.TestBepTu>(pagination.ListResults);
                this.TotalPages = pagination.TotalPages;
                UpdateData2(pagination.ListResults);
            }


            if (timer2 != null)
            {
                timer2.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }


        void UpdateData2(List<TestBepTu> list)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.BepTuModel.TestBepTu>>(UpdateData2), list);
                return;
            }


            //update gui
            dataGridView1.Rows.Clear();
            lbTotalPages.Text = this.TotalPages.ToString();

            buttonPreviousPage.Enabled = this.page > 1;
            buttonNextPage.Enabled = this.page < this.TotalPages;
            buttonPage.Text = this.page.ToString();

            pageNumberGoto.MinValue = 1;
            pageNumberGoto.MaxValue = this.TotalPages != 0 ? this.TotalPages : 1;


            foreach (var item in list)
            {
                List<Models.BepTuModel.BepTu>? l = new DALBepTu().GetDataFromIDTest(item.TestBepTuID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.BepTuName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.NhietDo;
                        row.Cells[4].Value = i.DienAp;
                        row.Cells[5].Value = i.DongDien;
                        row.Cells[6].Value = i.CongSuat;
                        row.Cells[7].Value = i.CongSuatTieuThu;
                        row.Cells[8].Value = i.TrangThai == true ? "ON" : "OFF";

                        row.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    dataGridView1.Rows.Add();
                }

            }
        }




        void LoadFormThongKe()
        {
            StopTimer();
            panel2.Enabled = false;

            dataGridView1.Rows.Clear();

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




            foreach (var item in this.ListResults)
            {
                List<Models.BepTuModel.BepTu>? l = new DALBepTu().GetDataFromIDTest(item.TestBepTuID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.BepTuName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.NhietDo;
                        row.Cells[4].Value = i.DienAp;
                        row.Cells[5].Value = i.DongDien;
                        row.Cells[6].Value = i.CongSuat;
                        row.Cells[7].Value = i.CongSuatTieuThu;
                        row.Cells[8].Value = i.TrangThai == true ? "ON" : "OFF";

                        row.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    dataGridView1.Rows.Add();
                }

            }







            panel2.Enabled = true;
            StartTimer();
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
            LoadFormThongKe();

            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
        }

        private async void BepTu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            await plc.Close();
        }






        // Giam sat

        PLCBepTu plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;





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


            if (timer != null)
            {
                timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }


        private void UpdateData(List<Models.BepTuModel.BepTu> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.BepTuModel.BepTu>>(UpdateData), list);
                return;
            }

            //update gui


            foreach (Models.BepTuModel.BepTu item in list)
            {
                if (item.BepTuName == TenThietBi.BepTu1)
                {
                    LanTest1.Text = item.LanTestThu.ToString();
                    NhietDo1.Text = String.Format("{0:0.00}", item.NhietDo);
                    DienAp1.Text = String.Format("{0:0.00}", item.DienAp);
                    DongDien1.Text = String.Format("{0:0.00}", item.DongDien);
                    CongSuat1.Text = String.Format("{0:0.00}", item.CongSuat);
                    CongSuatTieuThu1.Text = String.Format("{0:0.00}", item.CongSuatTieuThu);
                    TrangThai1.Text = item.TrangThai == true ? "ON" : "OFF";
                }
                else if (item.BepTuName == TenThietBi.BepTu2)
                {
                    LanTest2.Text = item.LanTestThu.ToString();
                    NhietDo2.Text = String.Format("{0:0.00}", item.NhietDo);
                    DienAp2.Text = String.Format("{0:0.00}", item.DienAp);
                    DongDien2.Text = String.Format("{0:0.00}", item.DongDien);
                    CongSuat2.Text = String.Format("{0:0.00}", item.CongSuat);
                    CongSuatTieuThu2.Text = String.Format("{0:0.00}", item.CongSuatTieuThu);
                    TrangThai2.Text = item.TrangThai == true ? "ON" : "OFF";
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(tabControl1.SelectedTab == tabPageThongKe)
            {
                this.StartTimer();
            }
            else
            {
                this.StopTimer();
            }
        }
    }
}
