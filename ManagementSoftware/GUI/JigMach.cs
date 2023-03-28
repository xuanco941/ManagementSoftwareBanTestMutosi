using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.JigMachManagement;
using ManagementSoftware.GUI.NguonManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
using ManagementSoftware.Models.JigMachModel;
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
    public partial class JigMach : Form
    {
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;



        public JigMach()
        {
            InitializeComponent();
            giamSatJigMachNguon = new GiamSatJigMachNguon();
            giamSatJigMachTDS = new GiamSatJigMachTDS();

        }
        private void JigMach_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            LoadDGV();
            LoadDGV2();

            giamSatJigMachNguon.TopLevel = false;
            tabPageGiamSatJigNguon.Controls.Add(giamSatJigMachNguon);
            giamSatJigMachNguon.FormBorderStyle = FormBorderStyle.None;
            giamSatJigMachNguon.Dock = DockStyle.Fill;
            giamSatJigMachNguon.Show();
            giamSatJigMachNguon.StartTimer();

            giamSatJigMachTDS.TopLevel = false;
            tabPageGiamSatJigTDS.Controls.Add(giamSatJigMachTDS);
            giamSatJigMachTDS.FormBorderStyle = FormBorderStyle.None;
            giamSatJigMachTDS.Dock = DockStyle.Fill;
            giamSatJigMachTDS.Show();

        }
        void LoadDGV()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Jig";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Dòng áp DC (V)";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Dòng điện DC (A)";
            DataGridViewColumn congSuat = new DataGridViewTextBoxColumn();
            congSuat.HeaderText = "Công suất (W)";
            DataGridViewColumn ThoiGian = new DataGridViewTextBoxColumn();
            ThoiGian.HeaderText = "Thời gian (giây)";



            dataGridView1.Columns.Add(STT);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(lanTest);
            dataGridView1.Columns.Add(dienAp);
            dataGridView1.Columns.Add(dongDC);
            dataGridView1.Columns.Add(congSuat);
            dataGridView1.Columns.Add(ThoiGian);
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình trạng"});



            dataGridView1.RowTemplate.Height = 35;

        }
        // ngày để query 
        private DateTime? timeStart = null;
        private DateTime? timeEnd = null;
        // trang hiện tại
        private int page = 1;



        // tổng số trang
        private int TotalPages = 0;
        //Data
        List<TestJigMach> ListResults = new List<TestJigMach>();

        private void LoadFormThongKe()
        {
            StopTimer1();
            panel2.Enabled = false;

            dataGridView1.Rows.Clear();


            PaginationJigMach pagination = new PaginationJigMach();
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
                List<Models.JigMachModel.JigMachNguon>? l = new DALJigMach().GetDataFromIDTest(item.TestJigMachID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        if (i.isOn)
                        {
                            row.Cells[1].Value = i.JigMachNguonName;
                        }
                        else
                        {
                            row.Cells[1].Value = i.JigMachNguonName + " (OFF)";
                        }
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = String.Format("{0:0.00}", i.DienApDC);
                        row.Cells[4].Value = String.Format("{0:0.00}", i.DongDienDC);
                        row.Cells[5].Value = String.Format("{0:0.00}", i.CongSuat);
                        row.Cells[6].Value = i.ThoiGian;
                        row.Cells[7].Value = i.Error;

                        if (i.Error != Common.NOT_ERROR_STR && i.isOn == true )
                        {
                            row.DefaultCellStyle.BackColor = Color.Crimson;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                    }
                    dataGridView1.Rows.Add();
                }

            }

            panel2.Enabled = true;
            StartTimer1();
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



        GiamSatJigMachNguon giamSatJigMachNguon;
        GiamSatJigMachTDS giamSatJigMachTDS;


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageGiamSatJigNguon)
            {
                giamSatJigMachNguon.StartTimer();
                giamSatJigMachTDS.StopTimer();
                StopTimer1();
                StopTimer2();

            }
            else if (tabControl1.SelectedTab == tabPageGiamSatJigTDS)
            {
                giamSatJigMachTDS.StartTimer();
                giamSatJigMachNguon.StopTimer();
                StopTimer1();
                StopTimer2();

            }
            else if (tabControl1.SelectedTab == tabPageThongKe)
            {
                LoadFormThongKe();
                giamSatJigMachTDS.StopTimer();
                giamSatJigMachNguon.StopTimer();
                StopTimer2();


            }
            else if (tabControl1.SelectedTab == tabPageThongKeTDS)
            {
                LoadFormThongKeTDS();
                giamSatJigMachTDS.StopTimer();
                giamSatJigMachNguon.StopTimer();
                StopTimer1();

            }

        }















        // ngày để query 
        private DateTime? timeStart2 = null;
        private DateTime? timeEnd2 = null;
        // trang hiện tại
        private int page2 = 1;



        // tổng số trang
        private int TotalPages2 = 0;
        //Data
        List<TestJigMachTDS> ListResults2 = new List<TestJigMachTDS>();


        void LoadDGV2()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Jig";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Van điện từ";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Van áp cao";
            DataGridViewColumn ThoiGian = new DataGridViewTextBoxColumn();
            ThoiGian.HeaderText = "Thời gian (giây)";



            dataGridView2.Columns.Add(STT);
            dataGridView2.Columns.Add(name);
            dataGridView2.Columns.Add(lanTest);
            dataGridView2.Columns.Add(dienAp);
            dataGridView2.Columns.Add(dongDC);
            dataGridView2.Columns.Add(ThoiGian);
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình trạng" });



            dataGridView2.RowTemplate.Height = 35;

        }

        private void LoadFormThongKeTDS()
        {
            StopTimer2();
            panelSearch2.Enabled = false;

            dataGridView2.Rows.Clear();


            PaginationJigMachTDS pagination = new PaginationJigMachTDS();
            pagination.Set(page2, timeStart2, timeEnd2);
            this.ListResults2 = pagination.ListResults;
            this.TotalPages2 = pagination.TotalPages;
            lbTotalPages2.Text = this.TotalPages2.ToString();

            buttonPreviousPage2.Enabled = this.page2 > 1;
            buttonNextPage2.Enabled = this.page2 < this.TotalPages2;
            buttonPage2.Text = this.page2.ToString();

            pageNumberGoto2.MinValue = 1;
            pageNumberGoto2.MaxValue = this.TotalPages2 != 0 ? this.TotalPages2 : 1;




            foreach (var item in this.ListResults2)
            {
                List<Models.JigMachModel.JigMachTDS>? l = new DALJigMach().GetDataFromIDTestTDS(item.TestJigMachTDSID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[rowId];

                        row.Cells[0].Value = date;
                        if (i.isOn)
                        {
                            row.Cells[1].Value = i.JigMachTDSName;
                        }
                        else
                        {
                            row.Cells[1].Value = i.JigMachTDSName + " (OFF)";
                        }
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.VanDienTu == true ? "ON" : "OFF";
                        row.Cells[4].Value = i.VanApCao == true ? "ON" : "OFF";
                        row.Cells[5].Value = i.ThoiGian;
                        row.Cells[6].Value = i.Error;

                        if (i.Error != Common.NOT_ERROR_STR && i.isOn == true )
                        {
                            row.DefaultCellStyle.BackColor = Color.Crimson;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                    }
                    dataGridView2.Rows.Add();
                }

            }

            panelSearch2.Enabled = true;
            StartTimer2();
        }

        private void buttonPreviousPage2_Click(object sender, EventArgs e)
        {
            if (this.page2 > 1)
            {
                this.page2 = this.page2 - 1;
                LoadFormThongKeTDS();
            }
        }

        private void buttonNextPage2_Click(object sender, EventArgs e)
        {
            if (this.page2 < this.TotalPages2)
            {
                this.page2 = this.page2 + 1;
                LoadFormThongKeTDS();
            }
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            timeStart2 = TimeStart2.Value;
            timeEnd2 = TimeEnd2.Value;
            LoadFormThongKeTDS();
        }

        private void buttonGoto2_Click(object sender, EventArgs e)
        {
            this.page2 = int.Parse(pageNumberGoto2.Text);
            LoadFormThongKeTDS();
        }























        System.Threading.Timer? timer1 = null;
        System.Threading.Timer? timer2 = null;



        public void StartTimer1()
        {
            if (timer1 == null)
            {
                timer1 = new System.Threading.Timer(Callback1, null, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY, Timeout.Infinite);
                buttonUpdateHistory.BackColor = Color.Thistle;
                buttonUpdateHistory.Text = "Stop Update";
            }
        }

        public void StopTimer1()
        {
            if (timer1 != null)
            {
                this.timer1.Change(Timeout.Infinite, Timeout.Infinite);
                timer1.Dispose();
                timer1 = null;
                buttonUpdateHistory.BackColor = Color.Crimson;
                buttonUpdateHistory.Text = "Start Update";
            }
        }

        public void StartTimer2()
        {
            if (timer2 == null)
            {
                timer2 = new System.Threading.Timer(Callback2, null, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY, Timeout.Infinite);
                buttonUpdateHistoryTDS.BackColor = Color.Thistle;
                buttonUpdateHistoryTDS.Text = "Stop Update";
            }
        }

        public void StopTimer2()
        {
            if (timer2 != null)
            {
                this.timer2.Change(Timeout.Infinite, Timeout.Infinite);
                timer2.Dispose();
                timer2 = null;
                buttonUpdateHistoryTDS.BackColor = Color.Crimson;
                buttonUpdateHistoryTDS.Text = "Start Update";
            }
        }



        private async void Callback1(Object state)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            PaginationJigMach pagination = new PaginationJigMach();
            pagination.Set(page, timeStart, timeEnd);

            // Nếu có dữ liệu mới và khác với dữ liệu cũ
            if (pagination.ListResults != null && pagination.ListResults.Count > 0
                && (!this.ListResults?.SequenceEqual(pagination.ListResults) ?? true))
            {
                this.ListResults = new List<Models.JigMachModel.TestJigMach>(pagination.ListResults);
                this.TotalPages = pagination.TotalPages;
                UpdateData1(pagination.ListResults);
            }

            watch.Stop();

            if (timer1 != null)
            {
                timer1.Change(Math.Max(0, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }



        private void UpdateData1(List<Models.JigMachModel.TestJigMach> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.JigMachModel.TestJigMach>>(UpdateData1), list);
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
                List<Models.JigMachModel.JigMachNguon>? l = new DALJigMach().GetDataFromIDTest(item.TestJigMachID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        if (i.isOn)
                        {
                            row.Cells[1].Value = i.JigMachNguonName;
                        }
                        else
                        {
                            row.Cells[1].Value = i.JigMachNguonName + " (OFF)";
                        }
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = String.Format("{0:0.00}", i.DienApDC);
                        row.Cells[4].Value = String.Format("{0:0.00}", i.DongDienDC);
                        row.Cells[5].Value = String.Format("{0:0.00}", i.CongSuat);
                        row.Cells[6].Value = i.ThoiGian;
                        row.Cells[7].Value = i.Error;

                        if (i.Error != Common.NOT_ERROR_STR && i.isOn == true)
                        {
                            row.DefaultCellStyle.BackColor = Color.Crimson;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                    }
                    dataGridView1.Rows.Add();
                }

            }
        }



        private async void Callback2(Object state)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            PaginationJigMachTDS pagination = new PaginationJigMachTDS();
            pagination.Set(page2, timeStart2, timeEnd2);

            // Nếu có dữ liệu mới và khác với dữ liệu cũ
            if (pagination.ListResults != null && pagination.ListResults.Count > 0
                && (!this.ListResults2?.SequenceEqual(pagination.ListResults) ?? true))
            {
                this.ListResults2 = new List<Models.JigMachModel.TestJigMachTDS>(pagination.ListResults);
                this.TotalPages2 = pagination.TotalPages;
                UpdateData2(pagination.ListResults);
            }

            watch.Stop();

            if (timer2 != null)
            {
                timer2.Change(Math.Max(0, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }



        private void UpdateData2(List<Models.JigMachModel.TestJigMachTDS> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.JigMachModel.TestJigMachTDS>>(UpdateData2), list);
                return;
            }


            //update gui
            dataGridView2.Rows.Clear();
            lbTotalPages2.Text = this.TotalPages2.ToString();

            buttonPreviousPage2.Enabled = this.page2 > 1;
            buttonNextPage2.Enabled = this.page2 < this.TotalPages2;
            buttonPage2.Text = this.page2.ToString();

            pageNumberGoto2.MinValue = 1;
            pageNumberGoto2.MaxValue = this.TotalPages2 != 0 ? this.TotalPages2 : 1;






            foreach (var item in this.ListResults2)
            {
                List<Models.JigMachModel.JigMachTDS>? l = new DALJigMach().GetDataFromIDTestTDS(item.TestJigMachTDSID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[rowId];

                        row.Cells[0].Value = date;
                        if (i.isOn)
                        {
                            row.Cells[1].Value = i.JigMachTDSName;
                        }
                        else
                        {
                            row.Cells[1].Value = i.JigMachTDSName + " (OFF)";
                        }
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.VanDienTu == true ? "ON" : "OFF";
                        row.Cells[4].Value = i.VanApCao == true ? "ON" : "OFF";
                        row.Cells[5].Value = i.ThoiGian;
                        row.Cells[6].Value = i.Error;

                        if (i.Error != Common.NOT_ERROR_STR && i.isOn == true)
                        {
                            row.DefaultCellStyle.BackColor = Color.Crimson;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                    }
                    dataGridView2.Rows.Add();
                }

            }
        }

        private void JigMach_FormClosing(object sender, FormClosingEventArgs e)
        {
            giamSatJigMachNguon.StopTimer();
            giamSatJigMachNguon.Close();
            giamSatJigMachNguon.Dispose();

            giamSatJigMachTDS.StopTimer();
            giamSatJigMachTDS.Close();
            giamSatJigMachTDS.Dispose();

            this.StopTimer1();
            this.StopTimer2();
        }































        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            StopTimer1();
            new XuatExcel().Xuat("Test Jig Mạch Nguồn", dataGridView1);
            StartTimer1();
        }

        private void buttonUpdateHistory_Click(object sender, EventArgs e)
        {
            if (timer1 != null)
            {
                StopTimer1();

            }
            else
            {
                StartTimer1();

            }
        }

        private void buttonXuatExcelTDS_Click(object sender, EventArgs e)
        {
            StopTimer2();
            new XuatExcel().Xuat("Test Jig Mạch TDS", dataGridView2);
            StartTimer2();
        }

        private void buttonUpdateHistoryTDS_Click(object sender, EventArgs e)
        {
            if (timer2 != null)
            {
                StopTimer2();

            }
            else
            {
                StartTimer2();

            }
        }
    }
}
