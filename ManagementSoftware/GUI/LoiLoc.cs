using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
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
        Dictionary<TestLoiLoc, List<Models.LoiLoc>> ListResults;

        Thread ThreadGetDataPLC;
        System.Timers.Timer aTimer;
        public LoiLoc()
        {
            InitializeComponent();

            if (PLCJigLoiLoc.plc.IsConnected == true)
            {
                ThreadGetDataPLC = new Thread(() =>
                {
                    aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(MyTimer_Tick);
                    aTimer.Interval = 500;
                    aTimer.Start();
                });
                ThreadGetDataPLC.Start();
            }
            LoadFormThongKe();


        }
        ~LoiLoc()
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
            ThreadGetDataPLC.Abort();
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

        delegate void SetTextControlCallback(Control control, string text);
        private void SetTextControl(Control control, string text)
        {

            if (control.InvokeRequired)
            {

                SetTextControlCallback d = new SetTextControlCallback(SetTextControl);
                this.Invoke(d, new object[] { control, text });            }
            else
            {
                control.Text = text;
            }

        }


        private void MyTimer_Tick(object sender, EventArgs e)
        {
            PLCJigLoiLoc.GetData();

            if (PLCJigLoiLoc.loiloc.LoiLocName == TenThietBi.LoiLoc1)
            {

                ThoiGianXa1.Invoke(new Action(() =>
                {
                    ThoiGianXa1.Text = PLCJigLoiLoc.loiloc.ThoiGianXa.ToString();
                }));
                ThoiGianNen1.Invoke(new Action(() =>
                {
                    ThoiGianNen1.Text = PLCJigLoiLoc.loiloc.ThoiGianNen.ToString();
                }));
                ThoiGianGiu1.Invoke(new Action(() =>
                {
                    ThoiGianGiu1.Text = PLCJigLoiLoc.loiloc.ThoiGianGiu.ToString();
                }));
                SoLanTestJig1.Invoke(new Action(() =>
                {
                    SoLanTestJig1.Text = PLCJigLoiLoc.loiloc.SoLanTest.ToString();
                }));
                ApSuatTest1.Invoke(new Action(() =>
                {
                    ApSuatTest1.Text = PLCJigLoiLoc.loiloc.ApSuatTest.ToString();
                }));
            }
            else if (PLCJigLoiLoc.loiloc.LoiLocName == TenThietBi.LoiLoc2)
            {
                ThoiGianXa2.Invoke(new Action(() =>
                {
                    ThoiGianXa2.Text = PLCJigLoiLoc.loiloc.ThoiGianXa.ToString();
                }));
                ThoiGianNen2.Invoke(new Action(() =>
                {
                    ThoiGianNen2.Text = PLCJigLoiLoc.loiloc.ThoiGianNen.ToString();
                }));
                ThoiGianGiu2.Invoke(new Action(() =>
                {
                    ThoiGianGiu2.Text = PLCJigLoiLoc.loiloc.ThoiGianGiu.ToString();
                }));
                SoLanTestJig2.Invoke(new Action(() =>
                {
                    SoLanTestJig2.Text = PLCJigLoiLoc.loiloc.SoLanTest.ToString();
                }));
                ApSuatTest2.Invoke(new Action(() =>
                {
                    ApSuatTest2.Text = PLCJigLoiLoc.loiloc.ApSuatTest.ToString();
                }));
            }
            else if (PLCJigLoiLoc.loiloc.LoiLocName == TenThietBi.LoiLoc1va2)
            {
                ThoiGianXa1va2.Invoke(new Action(() =>
                {
                    ThoiGianXa1va2.Text = PLCJigLoiLoc.loiloc.ThoiGianXa.ToString();
                }));
                ThoiGianNen1va2.Invoke(new Action(() =>
                {
                    ThoiGianNen1va2.Text = PLCJigLoiLoc.loiloc.ThoiGianNen.ToString();
                }));
                ThoiGianGiu1va2.Invoke(new Action(() =>
                {
                    ThoiGianGiu1va2.Text = PLCJigLoiLoc.loiloc.ThoiGianGiu.ToString();
                }));
                SoLanTestJig1va2.Invoke(new Action(() =>
                {
                    SoLanTestJig1va2.Text = PLCJigLoiLoc.loiloc.SoLanTest.ToString();
                }));
                ApSuatTest1va2.Invoke(new Action(() =>
                {
                    ApSuatTest1va2.Text = PLCJigLoiLoc.loiloc.ApSuatTest.ToString();
                }));
            }


        }


        private void LoiLoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
        }
    }
}
