using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.NguonManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
using ManagementSoftware.PLCSetting;
using S7.Net;
using Syncfusion.XPS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class Nguon : Form
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
        List<Models.NguonModel.TestNguon> ListResults = new List<Models.NguonModel.TestNguon>();
        FormTestNguon formTestNguon;
        FormTestLed formTestLed;

        public Nguon()
        {
            InitializeComponent();
            formTestNguon = new FormTestNguon();
            formTestLed = new FormTestLed();
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



        void LoadDGV()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Nguồn";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Điện áp DC (V)";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Dòng DC (A)";
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
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Lỗi"});



            dataGridView1.RowTemplate.Height = 35;

        }




        void LoadDGV2()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "LED";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn ThoiGian = new DataGridViewTextBoxColumn();
            ThoiGian.HeaderText = "Thời gian (giây)";



            dataGridView2.Columns.Add(STT);
            dataGridView2.Columns.Add(name);
            dataGridView2.Columns.Add(lanTest);
            dataGridView2.Columns.Add(ThoiGian);
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Lỗi" });


            dataGridView2.RowTemplate.Height = 35;

        }


        // ngày để query 
        private DateTime? timeStart2 = null;
        private DateTime? timeEnd2 = null;
        // trang hiện tại
        private int page2 = 1;



        // tổng số trang
        private int TotalPages2 = 0;

        List<Models.LedModel.TestLed> ListResults2 = new List<Models.LedModel.TestLed>();



        private void buttonPreviousPage2_Click(object sender, EventArgs e)
        {
            if (this.page2 > 1)
            {
                this.page2 = this.page2 - 1;
                LoadFormThongKe2();
            }
        }

        private void buttonNextPage2_Click(object sender, EventArgs e)
        {
            if (this.page2 < this.TotalPages2)
            {
                this.page2 = this.page2 + 1;
                LoadFormThongKe2();
            }
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            timeStart2 = TimeStart2.Value;
            timeEnd2 = TimeEnd2.Value;
            LoadFormThongKe2();
        }

        private void buttonGoto2_Click(object sender, EventArgs e)
        {
            this.page2 = int.Parse(pageNumberGoto2.Text);
            LoadFormThongKe2();
        }

        private void Nguon_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            LoadDGV();
            LoadDGV2();

            formTestNguon.TopLevel = false;
            tabPageGiamSat1.Controls.Add(formTestNguon);
            formTestNguon.FormBorderStyle = FormBorderStyle.None;
            formTestNguon.Dock = DockStyle.Fill;
            formTestNguon.Show();


            formTestLed.TopLevel = false;
            tabPageGiamSatLed.Controls.Add(formTestLed);
            formTestLed.FormBorderStyle = FormBorderStyle.None;
            formTestLed.Dock = DockStyle.Fill;
            formTestLed.Show();


            formTestNguon.StartTimer();






            






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

        private async void Callback1(Object state)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            PaginationNguon pagination = new PaginationNguon();
            pagination.Set(page, timeStart, timeEnd);

            // Nếu có dữ liệu mới và khác với dữ liệu cũ
            if (pagination.ListResults != null && pagination.ListResults.Count > 0
                && (!this.ListResults?.SequenceEqual(pagination.ListResults) ?? true))
            {
                this.ListResults = new List<Models.NguonModel.TestNguon>(pagination.ListResults);
                this.TotalPages = pagination.TotalPages;
                UpdateData1(pagination.ListResults);
            }

            if (timer1 != null)
            {
                timer1.Change(Math.Max(0, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }



        private void UpdateData1(List<Models.NguonModel.TestNguon> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.NguonModel.TestNguon>>(UpdateData1), list);
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
                List<Models.NguonModel.Nguon>? l = new DALNguon().GetDataFromIDTest(item.TestNguonID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.NguonName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.DienApDC;
                        row.Cells[4].Value = i.DongDC;
                        row.Cells[5].Value = i.CongSuat;
                        row.Cells[6].Value = i.ThoiGianTest;
                        row.Cells[7].Value = i.Error;

                        if (i.Error != "Không")
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



































        private void tabControl1_Selected_1(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageGiamSat1)
            {
                formTestNguon.StartTimer();
                formTestLed.StopTimer();
                this.StopTimer1();
                this.StopTimer2();

            }
            else if (tabControl1.SelectedTab == tabPageGiamSatLed)
            {
                formTestNguon.StopTimer();
                formTestLed.StartTimer();
                this.StopTimer1();
                this.StopTimer2();
            }
            else if (tabControl1.SelectedTab == tabPageThongKe)
            {
                LoadFormThongKe();
                this.StopTimer2();
                formTestNguon.StopTimer();
                formTestLed.StopTimer();

            }
            else if (tabControl1.SelectedTab == tabPageThongKeLed)
            {
                this.LoadFormThongKe2();
                this.StopTimer1();
                formTestNguon.StopTimer();
                formTestLed.StopTimer();

            }
        }

















        public void StartTimer2()
        {
            if (timer2 == null)
            {
                timer2 = new System.Threading.Timer(Callback2, null, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY, Timeout.Infinite);
                buttonUpdateHistory2.BackColor = Color.Thistle;
                buttonUpdateHistory2.Text = "Stop Update";
            }
        }

        public void StopTimer2()
        {
            if (timer2 != null)
            {
                this.timer2.Change(Timeout.Infinite, Timeout.Infinite);
                timer2.Dispose();
                timer2 = null;
                buttonUpdateHistory2.BackColor = Color.Crimson;
                buttonUpdateHistory2.Text = "Start Update";
            }
        }

        private async void Callback2(Object state)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            PaginationLed pagination = new PaginationLed();
            pagination.Set(page2, timeStart2, timeEnd2);

            // Nếu có dữ liệu mới và khác với dữ liệu cũ
            if (pagination.ListResults != null && pagination.ListResults.Count > 0
                && (!this.ListResults2?.SequenceEqual(pagination.ListResults) ?? true))
            {
                this.ListResults2 = new List<Models.LedModel.TestLed>(pagination.ListResults);
                this.TotalPages2 = pagination.TotalPages;
                UpdateData2(pagination.ListResults);
            }

            if (timer2 != null)
            {
                timer2.Change(Math.Max(0, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }



        private void UpdateData2(List<Models.LedModel.TestLed> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.LedModel.TestLed>>(UpdateData2), list);
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






            foreach (var item in list)
            {
                List<Models.LedModel.Led>? l = new DALLed().GetDataFromIDTest(item.TestLedID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.LedName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.ThoiGianTest;
                        row.Cells[4].Value = i.Error;

                        if (i.Error != "Không")
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






















        ///
        private void LoadFormThongKe()
        {
            this.StopTimer1();
            panel2.Enabled = false;
            dataGridView1.Rows.Clear();

            PaginationNguon pagination = new PaginationNguon();
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
                List<Models.NguonModel.Nguon>? l = new DALNguon().GetDataFromIDTest(item.TestNguonID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.NguonName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.DienApDC;
                        row.Cells[4].Value = i.DongDC;
                        row.Cells[5].Value = i.CongSuat;
                        row.Cells[6].Value = i.ThoiGianTest;
                        row.Cells[7].Value = i.Error;

                        if (i.Error != "Không")
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
            this.StartTimer1();
        }





        //


        private void LoadFormThongKe2()
        {
            this.StopTimer2();
            panelThongKeLed.Enabled = false;
            dataGridView2.Rows.Clear();

            PaginationLed pagination = new PaginationLed();
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
                List<Models.LedModel.Led>? l = new DALLed().GetDataFromIDTest(item.TestLedID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.LedName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.ThoiGianTest;
                        row.Cells[4].Value = i.Error;

                        if (i.Error != "Không")
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


            panelThongKeLed.Enabled = true;
            this.StartTimer2();
        }

        private void Nguon_FormClosing(object sender, FormClosingEventArgs e)
        {
            formTestNguon.Close();
            formTestLed.Close();
        }



















        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            StopTimer1();
            new XuatExcel().Xuat("Test Nguồn", dataGridView1);
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

        private void buttonXuatExcel2_Click(object sender, EventArgs e)
        {
            StopTimer2();
            new XuatExcel().Xuat("Test LED", dataGridView2);
            StartTimer2();
        }

        private void buttonUpdateHistory2_Click(object sender, EventArgs e)
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
