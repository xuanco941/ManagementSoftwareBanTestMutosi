using ManagementSoftware.PLCSetting;
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

namespace ManagementSoftware.GUI.NguonManagement
{
    public partial class FormTestLed : Form
    {
        PLCNguon plc;

        System.Threading.Timer? timer = null;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;
        public FormTestLed()
        {
            InitializeComponent();
            plc = new PLCNguon(ControlAllPLC.ipNguon, ControlAllPLC.PLCNguon);
        }

        private void FormTestLed_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "LED", SortMode = DataGridViewColumnSortMode.NotSortable });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thời gian (giây)", SortMode = DataGridViewColumnSortMode.NotSortable });
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
                dataGridView1.Rows[i].Cells[0].Value = "Nguồn " + (i + 1);
            }
        }

        public async void StartTimer()
        {
            if (await plc.Open() == true)
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

        private void FormTestLed_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer();

        }

        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.LedModel.Led> list = await plc.GetDataLED();
            if (list != null && list.Count > 0)
            {
                UpdateData(list);
            }


            if (timer != null)
            {
                timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }




        private void UpdateData(List<Models.LedModel.Led> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.LedModel.Led>>(UpdateData), list);
                return;
            }


            //update gui


            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = list[i].ThoiGianTest;
                dataGridView1.Rows[i].Cells[2].Value = list[i].LanTestThu;

            }






        }
    }
}
