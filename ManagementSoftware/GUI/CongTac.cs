using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
using ManagementSoftware.Models.BepTuModel;
using ManagementSoftware.Models.CongTacModel;
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
    public partial class CongTac : Form
    {
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;





        //CT2VT
        private DateTime? timeStart = null;
        private DateTime? timeEnd = null;
        private int page = 1;
        private int TotalPages = 0;
        List<Models.CongTacModel.TestCongTac> ListResults = new List<Models.CongTacModel.TestCongTac>();



        public CongTac()
        {
            InitializeComponent();
            plc1 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc2 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc3 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc4 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc5 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc6 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc7 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc8 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc9 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            plc10 = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);


        }
        void LoadDGV()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Công tắc";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Trạng thái";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";



            dataGridView1.Columns.Add(STT);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(dienAp);
            dataGridView1.Columns.Add(lanTest);
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình trạng" });


            dataGridView1.RowTemplate.Height = 35;

        }
        void LoadFormThongKe()
        {
            StopTimer2();
            panelSearchPage2VT.Enabled = false;

            dataGridView1.Rows.Clear();



            PaginationCongTac pagination = new PaginationCongTac();
            pagination.Set(page, timeStart, timeEnd);
            this.ListResults = pagination.ListResults;
            this.TotalPages = pagination.TotalPages;
            lbTotalPages2VT.Text = this.TotalPages.ToString();

            buttonPreviousPage2VT.Enabled = this.page > 1;
            buttonNextPage2VT.Enabled = this.page < this.TotalPages;
            buttonPage2VT.Text = this.page.ToString();

            pageNumberGoto2VT.MinValue = 1;
            pageNumberGoto2VT.MaxValue = this.TotalPages != 0 ? this.TotalPages : 1;


            foreach (var item in this.ListResults)
            {
                List<Models.CongTacModel.CongTac>? l = new DALCongTac().GetDataFromIDTest(item.TestCongTacID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.CongTacName + " - " + i.JigCongTac;
                        row.Cells[2].Value = i.TrangThai == true ? "ON" : "OFF";
                        row.Cells[3].Value = i.LanTestThu;
                        row.Cells[4].Value = i.Error;

                        if (i.Error != Common.NOT_ERROR_STR)
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



            panelSearchPage2VT.Enabled = true;
            StartTimer2();
        }






        private void StopTimer2()
        {
            if (timer2 != null)
            {
                this.timer2.Change(Timeout.Infinite, Timeout.Infinite);
                timer2.Dispose();
                timer2 = null;
                buttonUpdateHistory.BackColor = Color.Crimson;
                buttonUpdateHistory.Text = "Start Update";
            }
        }
        private void StartTimer2()
        {
            if (timer2 == null)
            {
                timer2 = new System.Threading.Timer(Callback2, null, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY, Timeout.Infinite);
                buttonUpdateHistory.BackColor = Color.Thistle;
                buttonUpdateHistory.Text = "Stop Update";
            }
        }

        private async void Callback2(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation
            PaginationCongTac pagination = new PaginationCongTac();
            pagination.Set(page, timeStart, timeEnd);
            // Nếu có dữ liệu mới và khác với dữ liệu cũ
            if (pagination.ListResults != null && pagination.ListResults.Count > 0
                && (!this.ListResults?.SequenceEqual(pagination.ListResults) ?? true))
            {
                this.ListResults = new List<Models.CongTacModel.TestCongTac>(pagination.ListResults);
                this.TotalPages = pagination.TotalPages;
                UpdateData2(pagination.ListResults);
            }


            if (timer2 != null)
            {
                timer2.Change(Math.Max(0, Common.TIME_INTERVAL_UPDATE_DATA_ON_HISTORY - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }


        void UpdateData2(List<TestCongTac> list)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.CongTacModel.TestCongTac>>(UpdateData2), list);
                return;
            }


            //update gui
            dataGridView1.Rows.Clear();
            lbTotalPages2VT.Text = this.TotalPages.ToString();

            buttonPreviousPage2VT.Enabled = this.page > 1;
            buttonNextPage2VT.Enabled = this.page < this.TotalPages;
            buttonPage2VT.Text = this.page.ToString();

            pageNumberGoto2VT.MinValue = 1;
            pageNumberGoto2VT.MaxValue = this.TotalPages != 0 ? this.TotalPages : 1;


            foreach (var item in this.ListResults)
            {
                List<Models.CongTacModel.CongTac>? l = new DALCongTac().GetDataFromIDTest(item.TestCongTacID);

                if (l != null && l.Count > 0)
                {
                    string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.CongTacName + " - " + i.JigCongTac;
                        row.Cells[2].Value = i.TrangThai == true ? "ON" : "OFF";
                        row.Cells[3].Value = i.LanTestThu;
                        row.Cells[4].Value = i.Error;

                        if (i.Error != Common.NOT_ERROR_STR)
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


































        private void buttonPreviousPage2VT_Click(object sender, EventArgs e)
        {
            if (this.page > 1)
            {
                this.page = this.page - 1;
                LoadFormThongKe();
            }
        }

        private void buttonNextPage2VT_Click(object sender, EventArgs e)
        {
            if (this.page < this.TotalPages)
            {
                this.page = this.page + 1;
                LoadFormThongKe();
            }
        }

        private void buttonSearch2VT_Click(object sender, EventArgs e)
        {
            timeStart = TimeStart2VT.Value;
            timeEnd = TimeEnd2VT.Value;
            LoadFormThongKe();
        }

        private void buttonGoto2VT_Click(object sender, EventArgs e)
        {
            this.page = int.Parse(pageNumberGoto2VT.Text);
            LoadFormThongKe();
        }

        PLCCongTac plc1;
        PLCCongTac plc2;
        PLCCongTac plc3;
        PLCCongTac plc4;
        PLCCongTac plc5;
        PLCCongTac plc6;
        PLCCongTac plc7;
        PLCCongTac plc8;
        PLCCongTac plc9;
        PLCCongTac plc10;



        System.Threading.Timer? timer = null;
        System.Threading.Timer? timer2 = null;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;
        private async void CongTac_Load(object sender, EventArgs e)
        {

            dataGridViewGiamSat.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Công tắc", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridViewGiamSat.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Trạng thái", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridViewGiamSat.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Lần test thứ", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridViewGiamSat.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Tình trạng", SortMode = DataGridViewColumnSortMode.NotSortable });




            dataGridViewGiamSat.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            dataGridViewGiamSat.EnableHeadersVisualStyles = false;
            dataGridViewGiamSat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGiamSat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGiamSat.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);


            dataGridViewGiamSat.RowTemplate.Height = 40;
            dataGridViewGiamSat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewGiamSat.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewGiamSat.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dataGridViewGiamSat.AllowUserToAddRows = false;
            dataGridViewGiamSat.AllowUserToDeleteRows = false;
            dataGridViewGiamSat.ReadOnly = true;
            dataGridViewGiamSat.RowHeadersVisible = false;

            dataGridView1.ReadOnly = true;




            int jig = 1;
            int ct  = 1;
            for (int i = 0; i < 50; i++)
            {
                int id = dataGridViewGiamSat.Rows.Add();
                dataGridViewGiamSat.Rows[id].DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
                dataGridViewGiamSat.Rows[i].Cells[0].Value = "Jig "+jig + " - " + "Công tắc "+ct;

                ct++;
                if (ct == 6)
                {
                    jig++;
                    ct = 1;
                }
            }







            LoadDGV();

            if (timer == null && await plc1.Open() == true && await plc2.Open() && await plc3.Open() && await plc4.Open() && await plc5.Open()
                && await plc6.Open() && await plc7.Open() && await plc8.Open() && await plc9.Open() && await plc10.Open())
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }




        }


        private void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation


            Task<List<Models.CongTacModel.CongTac>> task1 = Task.Run(() => plc1.GetData(0, 2, 4, 6, 8, 1, 120));
            Task<List<Models.CongTacModel.CongTac>> task2 = Task.Run(() => plc2.GetData(50, 12, 14, 16, 18, 2, 130));
            Task<List<Models.CongTacModel.CongTac>> task3 = Task.Run(() => plc3.GetData(20, 22, 24, 26, 28, 3, 140));
            Task<List<Models.CongTacModel.CongTac>> task4 = Task.Run(() => plc4.GetData(30, 32, 34, 36, 38, 4, 150));
            Task<List<Models.CongTacModel.CongTac>> task5 = Task.Run(() => plc5.GetData(40, 42, 44, 46, 48, 5, 160));
            Task<List<Models.CongTacModel.CongTac>> task6 = Task.Run(() => plc6.GetData(64, 66, 70, 52, 72, 6, 170));
            Task<List<Models.CongTacModel.CongTac>> task7 = Task.Run(() => plc7.GetData(74, 76, 78, 80, 82, 7, 180));
            Task<List<Models.CongTacModel.CongTac>> task8 = Task.Run(() => plc8.GetData(84, 86, 88, 90, 92, 8, 190));
            Task<List<Models.CongTacModel.CongTac>> task9 = Task.Run(() => plc9.GetData(94, 96, 98, 100, 102, 9, 200));
            Task<List<Models.CongTacModel.CongTac>> task10 = Task.Run(() => plc10.GetData(104, 106, 108, 110, 112, 10, 210));






            Task.WhenAll(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10).ContinueWith((t) =>
                {
                    List<Models.CongTacModel.CongTac> list = new List<Models.CongTacModel.CongTac>();
                    list.AddRange(task1.Result);
                    list.AddRange(task2.Result);
                    list.AddRange(task3.Result);
                    list.AddRange(task4.Result);
                    list.AddRange(task5.Result);
                    list.AddRange(task6.Result);
                    list.AddRange(task7.Result);
                    list.AddRange(task8.Result);
                    list.AddRange(task9.Result);
                    list.AddRange(task10.Result);

                    // Code here will run after all tasks complete
                    if (list != null && list.Count > 0)
                    {
                        UpdateData(list);
                    }

                    if (timer != null)
                    {
                        timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
                    }
                });






        }

        private void UpdateData(List<Models.CongTacModel.CongTac> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.CongTacModel.CongTac>>(UpdateData), list);
                return;
            }


            //update gui

            for (int i = 0; i < list.Count; i++)
            {
                dataGridViewGiamSat.Rows[i].Cells[1].Value = list[i].TrangThai == true ? "ON" : "OFF";
                dataGridViewGiamSat.Rows[i].Cells[2].Value = list[i].LanTestThu;
                dataGridViewGiamSat.Rows[i].Cells[3].Value = list[i].Error;

                if (list[i].Error != Common.NOT_ERROR_STR)
                {
                    dataGridViewGiamSat.Rows[i].DefaultCellStyle.BackColor = Color.Crimson;
                }
                else
                {
                    dataGridViewGiamSat.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
                }
            }






        }


        private async void CongTac_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            StopTimer2();
            await plc1.Close();
            await plc2.Close();
            await plc3.Close();
            await plc4.Close();
            await plc5.Close();
            await plc6.Close();
            await plc7.Close();
            await plc8.Close();
            await plc9.Close();
            await plc10.Close();

        }

        private async void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageThongKe)
            {
                LoadFormThongKe();
                if (timer != null)
                {
                    this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                    timer.Dispose();
                    timer = null;
                }
                await plc1.Close();
                await plc2.Close();
                await plc3.Close();
                await plc4.Close();
                await plc5.Close();
                await plc6.Close();
                await plc7.Close();
                await plc8.Close();
                await plc9.Close();
                await plc10.Close();
            }
            else
            {
                this.StopTimer2();
                if (timer == null && await plc1.Open() == true && await plc2.Open() && await plc3.Open() && await plc4.Open() && await plc5.Open()
                    && await plc6.Open() && await plc7.Open() && await plc8.Open() && await plc9.Open() && await plc10.Open())
                {
                    timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
                }
            }
        }



























        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            StopTimer2();
            new XuatExcel().Xuat("Test Công Tắc", dataGridView1);
            StartTimer2();
        }

        private void buttonUpdateHistory_Click(object sender, EventArgs e)
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
