using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.CongTacManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
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



            dataGridView1.RowTemplate.Height = 35;

        }
        void LoadFormThongKe()
        {
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
                    string date = item.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.CongTacName + " - " + i.JigCongTac;
                        row.Cells[2].Value = i.TrangThai == true ? "ON" : "OFF";
                        row.Cells[3].Value = i.LanTestThu;
                        row.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    dataGridView1.Rows.Add();
                }

            }



            panelSearchPage2VT.Enabled = true;
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



        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;
        private async void CongTac_Load(object sender, EventArgs e)
        {
            LoadDGV();
            LoadFormThongKe();

            if (await plc1.Open() == true && await plc2.Open() && await plc3.Open() && await plc4.Open() && await plc5.Open()
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


            Task<List<Models.CongTacModel.CongTac>> task1 = Task.Run(() => plc1.GetData(0, 2, 4, 6, 8, 1));
            Task<List<Models.CongTacModel.CongTac>> task2 = Task.Run(() => plc2.GetData(50, 12, 14, 16, 18, 2));
            Task<List<Models.CongTacModel.CongTac>> task3 = Task.Run(() => plc3.GetData(20, 22, 24, 26, 28, 3));
            Task<List<Models.CongTacModel.CongTac>> task4 = Task.Run(() => plc4.GetData(30, 32, 34, 36, 38, 4));
            Task<List<Models.CongTacModel.CongTac>> task5 = Task.Run(() => plc5.GetData(40, 42, 44, 46, 48, 5));
            Task<List<Models.CongTacModel.CongTac>> task6 = Task.Run(() => plc6.GetData(64, 66, 70, 52, 72, 6));
            Task<List<Models.CongTacModel.CongTac>> task7 = Task.Run(() => plc7.GetData(74, 76, 78, 80, 82, 7));
            Task<List<Models.CongTacModel.CongTac>> task8 = Task.Run(() => plc8.GetData(84, 86, 88, 90, 92, 8));
            Task<List<Models.CongTacModel.CongTac>> task9 = Task.Run(() => plc9.GetData(94, 96, 98, 100, 102, 9));
            Task<List<Models.CongTacModel.CongTac>> task10 = Task.Run(() => plc10.GetData(104, 106, 108, 110, 112, 10));






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

            SetTextControl(SLT1, TT1, list[0]);
            SetTextControl(SLT2, TT2, list[1]);
            SetTextControl(SLT3, TT3, list[2]);
            SetTextControl(SLT4, TT4, list[3]);
            SetTextControl(SLT5, TT5, list[4]);
            SetTextControl(SLT6, TT6, list[5]);
            SetTextControl(SLT7, TT7, list[6]);
            SetTextControl(SLT8, TT8, list[7]);
            SetTextControl(SLT9, TT9, list[8]);
            SetTextControl(SLT10, TT10, list[9]);
            SetTextControl(SLT11, TT11, list[10]);
            SetTextControl(SLT12, TT12, list[11]);
            SetTextControl(SLT13, TT13, list[12]);
            SetTextControl(SLT14, TT14, list[13]);
            SetTextControl(SLT15, TT15, list[14]);
            SetTextControl(SLT16, TT16, list[15]);
            SetTextControl(SLT17, TT17, list[16]);
            SetTextControl(SLT18, TT18, list[17]);
            SetTextControl(SLT19, TT19, list[18]);
            SetTextControl(SLT20, TT20, list[19]);
            SetTextControl(SLT21, TT21, list[20]);
            SetTextControl(SLT22, TT22, list[21]);
            SetTextControl(SLT23, TT23, list[22]);
            SetTextControl(SLT24, TT24, list[23]);
            SetTextControl(SLT25, TT25, list[24]);
            SetTextControl(SLT26, TT26, list[25]);
            SetTextControl(SLT27, TT27, list[26]);
            SetTextControl(SLT28, TT28, list[27]);
            SetTextControl(SLT29, TT29, list[28]);
            SetTextControl(SLT30, TT30, list[29]);
            SetTextControl(SLT31, TT31, list[30]);
            SetTextControl(SLT32, TT32, list[31]);
            SetTextControl(SLT33, TT33, list[32]);
            SetTextControl(SLT34, TT34, list[33]);
            SetTextControl(SLT35, TT35, list[34]);
            SetTextControl(SLT36, TT36, list[35]);
            SetTextControl(SLT37, TT37, list[36]);
            SetTextControl(SLT38, TT38, list[37]);
            SetTextControl(SLT39, TT39, list[38]);
            SetTextControl(SLT40, TT40, list[39]);
            SetTextControl(SLT41, TT41, list[40]);
            SetTextControl(SLT42, TT42, list[41]);
            SetTextControl(SLT43, TT43, list[42]);
            SetTextControl(SLT44, TT44, list[43]);
            SetTextControl(SLT45, TT45, list[44]);
            SetTextControl(SLT46, TT46, list[45]);
            SetTextControl(SLT47, TT47, list[46]);
            SetTextControl(SLT48, TT48, list[47]);
            SetTextControl(SLT49, TT49, list[48]);
            SetTextControl(SLT50, TT50, list[49]);






        }

        private void SetTextControl(Button lanTestThu, Button TrangThai, Models.CongTacModel.CongTac e)
        {

            lanTestThu.Text = e.LanTestThu.ToString();

            TrangThai.Text = e.TrangThai == true ? "ON" : "OFF";

        }



        private async void CongTac_FormClosing(object sender, FormClosingEventArgs e)
        {
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
    }
}
