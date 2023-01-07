using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models.LoiLocModel;
using ManagementSoftware.PLCSetting;
using System.ComponentModel;
using System.Diagnostics;
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
        Dictionary<TestLoiLoc, List<Models.LoiLocModel.LoiLoc>> ListResults;


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



        private void LoadFormThongKe()
        {
            panel2.Enabled = false;
            foreach (Form item in panelThongKe.Controls)
            {
                item.Close();
                item.Dispose();
            }
            panelThongKe.Controls.Clear();


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

            for (int i = ListResults.Count - 1; i >= 0; i--)
            {
                ItemThongKeLoiLoc form = new ItemThongKeLoiLoc(ListResults.ElementAt(i).Key, ListResults.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
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
        }



        private async void LoiLoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
            }
            await plc.Close();

        }

        private async void LoiLoc_Load(object sender, EventArgs e)
        {


            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
            else
            {
                if (CheckLoad.checkLoiLoc == false)
                {
                    MessageBox.Show("Không thể kết nối tới " + plc.plcName, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CheckLoad.checkLoiLoc = true;
                }
            }

            LoadFormThongKe();

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

                ThoiGianXa1.Text = loiloc.ThoiGianXa.ToString() + " s";

                ThoiGianNen1.Text = loiloc.ThoiGianNen.ToString() + " s";

                ThoiGianGiu1.Text = loiloc.ThoiGianGiu.ToString() + " s";

                SoLanTestJig1.Text = loiloc.SoLanTest.ToString();

                ApSuatTest1.Text = loiloc.ApSuatTest.ToString() + " bar";
            }
            else if (loiloc.LoiLocName == TenThietBi.LoiLoc2)
            {

                ThoiGianXa2.Text = loiloc.ThoiGianXa.ToString() + " s";

                ThoiGianNen2.Text = loiloc.ThoiGianNen.ToString() + " s";

                ThoiGianGiu2.Text = loiloc.ThoiGianGiu.ToString() + " s";
                SoLanTestJig2.Text = loiloc.SoLanTest.ToString();

                ApSuatTest2.Text = loiloc.ApSuatTest.ToString() + " bar";
            }
            else
            {
                ThoiGianXa1va2.Text = loiloc.ThoiGianXa.ToString() + " s";
                ThoiGianNen1va2.Text = loiloc.ThoiGianNen.ToString() + " s";
                ThoiGianGiu1va2.Text = loiloc.ThoiGianGiu.ToString() + " s";

                SoLanTestJig1va2.Text = loiloc.SoLanTest.ToString();

                ApSuatTest1va2.Text = loiloc.ApSuatTest.ToString() + " bar";
            }
        }




    }
}
