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


            formTestNguon.TopLevel = false;
            tabPageGiamSat1.Controls.Add(formTestNguon);
            formTestNguon.FormBorderStyle = FormBorderStyle.None;
            formTestNguon.Dock = DockStyle.Fill;
            formTestNguon.Show();
            formTestNguon.StartTimer();



            formTestLed.TopLevel = false;
            tabPageGiamSatLed.Controls.Add(formTestLed);
            formTestLed.FormBorderStyle = FormBorderStyle.None;
            formTestLed.Dock = DockStyle.Fill;
            formTestLed.Show();

            LoadDGV();
            LoadDGV2();



        }




        System.Threading.Timer? timer1 = null;
        System.Threading.Timer? timer2 = null;

        int TIME_INTERVAL_IN_MILLISECONDS = 0;

        public void StartTimer1()
        {
            timer1 = new System.Threading.Timer(Callback1, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
        }

        public void StopTimer1()
        {
            if (timer1 != null)
            {
                this.timer1.Change(Timeout.Infinite, Timeout.Infinite);
                timer1.Dispose();
                timer1 = null;
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
                timer1.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
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
                        if (i.isErrorDong || i.isErrorAp)
                        {
                            row.DefaultCellStyle.BackColor = Color.Crimson;
                            if (i.isErrorDong)
                            {
                                row.Cells[4].Style.BackColor = Color.Red;
                                row.Cells[4].Style.ForeColor = Color.White;
                            }
                            if (i.isErrorAp)
                            {
                                row.Cells[3].Style.BackColor = Color.Red;
                                row.Cells[3].Style.ForeColor = Color.White;
                            }
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
                this.StartTimer1();
                this.StopTimer2();
                formTestNguon.StopTimer();
                formTestLed.StopTimer();

            }
            else if (tabControl1.SelectedTab == tabPageThongKeLed)
            {
                this.StartTimer2();
                this.StopTimer1();
                formTestNguon.StopTimer();
                formTestLed.StopTimer();

            }
        }

















        public void StartTimer2()
        {
            timer2 = new System.Threading.Timer(Callback2, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
        }

        public void StopTimer2()
        {
            if (timer2 != null)
            {
                this.timer2.Change(Timeout.Infinite, Timeout.Infinite);
                timer2.Dispose();
                timer2 = null;
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
                timer2.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
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
                        if (i.isError)
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
                        if (i.isErrorDong || i.isErrorAp)
                        {
                            row.DefaultCellStyle.BackColor = Color.Crimson;
                            if (i.isErrorDong)
                            {
                                row.Cells[4].Style.BackColor = Color.Red;
                                row.Cells[4].Style.ForeColor = Color.White;
                            }
                            if (i.isErrorAp)
                            {
                                row.Cells[3].Style.BackColor = Color.Red;
                                row.Cells[3].Style.ForeColor = Color.White;
                            }
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
                        row.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    dataGridView2.Rows.Add();
                }



            }


            panelThongKeLed.Enabled = true;
            this.StartTimer2();
        }

    }


}
