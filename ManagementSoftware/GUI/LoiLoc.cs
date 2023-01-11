using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models.LoiLocModel;
using ManagementSoftware.PLCSetting;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Timers;
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class LoiLoc : Form
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
        List<Models.LoiLocModel.LoiLoc> ListResults = new List<Models.LoiLocModel.LoiLoc>();


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
            name.HeaderText = "Lõi lọc";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Áp suất test (bar)";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Thời gian cấp (giây)";
            DataGridViewColumn congSuat = new DataGridViewTextBoxColumn();
            congSuat.HeaderText = "Thời gian giữ (giây)";
            DataGridViewColumn ThoiGian = new DataGridViewTextBoxColumn();
            ThoiGian.HeaderText = "Thời gian xả (giây)";



            dataGridView1.Columns.Add(STT);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(lanTest);
            dataGridView1.Columns.Add(dienAp);
            dataGridView1.Columns.Add(dongDC);
            dataGridView1.Columns.Add(congSuat);
            dataGridView1.Columns.Add(ThoiGian);


            dataGridView1.RowTemplate.Height = 35;

        }

        private void LoadFormThongKe()
        {
            panel2.Enabled = false;

            dataGridView1.Rows.Clear();

            PaginationLoiLoc pagination = new PaginationLoiLoc();
            pagination.Set(page, timeStart, timeEnd);
            this.ListResults = pagination.ListResults;
            this.TotalPages = pagination.TotalPages;
            lbTotalPages.Text = this.TotalPages.ToString();

            buttonPreviousPage.Enabled = this.page > 1;
            buttonNextPage.Enabled = this.page < this.TotalPages;
            buttonPage.Text = this.page.ToString();

            pageNumberGoto.MinValue = 1;
            pageNumberGoto.MaxValue = this.TotalPages != 0 ? this.TotalPages : 1;





            bool checkColor = false;
            foreach (var item in this.ListResults)
            {
                string date = "ID" + item.LoiLocID + " - " + item.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);

                int rowId = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells[0].Value = date;
                row.Cells[1].Value = item.LoiLocName;
                row.Cells[2].Value = item.SoLanTest;
                row.Cells[3].Value = item.ApSuatTest;
                row.Cells[4].Value = item.ThoiGianNen;
                row.Cells[5].Value = item.ThoiGianGiu;
                row.Cells[6].Value = item.ThoiGianXa;
                if(checkColor == true)
                {
                    row.DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                checkColor = !checkColor;

            }

            panel2.Enabled = true;
        }




















        // Giam sat

        PLCLoiLoc plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 1000;



        public LoiLoc()
        {
            InitializeComponent();

            plc = new PLCLoiLoc(ControlAllPLC.ipLoiLoc, ControlAllPLC.PLCLoiLoc);

            dataGridView1.RowTemplate.Height = 35;
        }



        private async void LoiLoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            await plc.Close();

        }

        private async void LoiLoc_Load(object sender, EventArgs e)
        {

            LoadDGV();
            LoadFormThongKe();

            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }



        }



        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            Models.LoiLocModel.LoiLoc loiLoc = await plc.GetData();
            if (loiLoc != null)
            {
                UpdateData(loiLoc);
            }


            timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
        }



        private void UpdateData(Models.LoiLocModel.LoiLoc loiloc)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<Models.LoiLocModel.LoiLoc>(UpdateData), loiloc);
                return;
            }


            //update gui

            if (loiloc.LoiLocName == TenThietBi.LoiLoc1)
            {

                ThoiGianXa1.Text = loiloc.ThoiGianXa.ToString();

                ThoiGianNen1.Text = loiloc.ThoiGianNen.ToString();

                ThoiGianGiu1.Text = loiloc.ThoiGianGiu.ToString();

                SoLanTestJig1.Text = loiloc.SoLanTest.ToString();

                ApSuatTest1.Text = loiloc.ApSuatTest.ToString();
            }
            else if (loiloc.LoiLocName == TenThietBi.LoiLoc2)
            {

                ThoiGianXa2.Text = loiloc.ThoiGianXa.ToString();

                ThoiGianNen2.Text = loiloc.ThoiGianNen.ToString();

                ThoiGianGiu2.Text = loiloc.ThoiGianGiu.ToString();
                SoLanTestJig2.Text = loiloc.SoLanTest.ToString();

                ApSuatTest2.Text = loiloc.ApSuatTest.ToString();
            }
            else
            {
                ThoiGianXa1va2.Text = loiloc.ThoiGianXa.ToString();
                ThoiGianNen1va2.Text = loiloc.ThoiGianNen.ToString();
                ThoiGianGiu1va2.Text = loiloc.ThoiGianGiu.ToString();

                SoLanTestJig1va2.Text = loiloc.SoLanTest.ToString();

                ApSuatTest1va2.Text = loiloc.ApSuatTest.ToString();
            }
        }




    }
}
