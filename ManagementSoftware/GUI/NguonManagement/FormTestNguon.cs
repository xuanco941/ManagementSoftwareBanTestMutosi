using ManagementSoftware.Models.NguonModel;
using ManagementSoftware.PLCSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.NguonManagement
{
    public partial class FormTestNguon : Form
    {


        // Giam sat

        PLCNguon plc;

        System.Threading.Timer? timer = null;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;

        public FormTestNguon()
        {
            InitializeComponent();
            plc = new PLCNguon(ControlAllPLC.ipNguon, ControlAllPLC.PLCNguon);
        }



        public async void StartTimer()
        {
            if (timer == null && await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
        }

        public async void StopTimer()
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            await plc.Close();
        }




        private void NguonTu1Den15_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer();
        }




        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.NguonModel.Nguon> list = await plc.GetDataNguon();
            if (list != null && list.Count > 0)
            {
                UpdateData(list);
            }


            if (timer != null)
            {
                timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }

        private void UpdateData(List<Models.NguonModel.Nguon> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.NguonModel.Nguon>>(UpdateData), list);
                return;
            }


            //update gui


            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].isOn)
                {
                    dataGridView1.Rows[i].Cells[0].Value = list[i].NguonName;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[0].Value = list[i].NguonName + " (OFF)";
                }
                dataGridView1.Rows[i].Cells[1].Value = String.Format("{0:0.00}", list[i].DongDC);
                dataGridView1.Rows[i].Cells[2].Value = String.Format("{0:0.00}", list[i].DienApDC);
                dataGridView1.Rows[i].Cells[3].Value = String.Format("{0:0.00}", list[i].CongSuat);
                dataGridView1.Rows[i].Cells[4].Value = list[i].ThoiGianTest;
                dataGridView1.Rows[i].Cells[5].Value = list[i].LanTestThu;
                if (list[i].Error != Common.NOT_ERROR_STR)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Crimson;

                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
                }
            }



        }

        private void FormTestNguon_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nguồn", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Dòng DC (A)", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Điện áp DC (V)", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Công suất (W)", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian test (giây)", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Lần test thứ", SortMode = DataGridViewColumnSortMode.NotSortable });




            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkOrange;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);


            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;






            for (int i = 0; i < 30; i++)
            {
                int id = dataGridView1.Rows.Add();
                dataGridView1.Rows[id].DefaultCellStyle.BackColor = Color.FromArgb(41, 44, 51);
            }





        }
    }
}
