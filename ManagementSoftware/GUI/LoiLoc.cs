using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
using ManagementSoftware.PLCSetting;
using System.ComponentModel;
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

        public LoiLoc()
        {
            InitializeComponent();
            LoadFormGiamSat();
            //LoadFormThongKe();
            timer1.Interval = 500;
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
        PLCJigLoiLoc plcLoiLoc = new PLCJigLoiLoc();

        private void LoadFormGiamSat()
        {
            plcLoiLoc.Start();

            if (plcLoiLoc.plc.IsConnected == true)
            {
                timer1.Start();
            }
            else
            {
                MessageBox.Show(plcLoiLoc.message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ThoiGianXa1.Text = "NULL";
            ThoiGianNen1.Text = "NULL";
            ThoiGianGiu1.Text = "NULL";
            SoLanTestJig1.Text = "NULL";
            ApSuatTest1.Text = "NULL";

            ThoiGianXa2.Text = "NULL";
            ThoiGianNen2.Text = "NULL";
            ThoiGianGiu2.Text = "NULL";
            SoLanTestJig2.Text = "NULL";
            ApSuatTest2.Text = "NULL";

            ThoiGianXa1va2.Text = "NULL";
            ThoiGianNen1va2.Text = "NULL";
            ThoiGianGiu1va2.Text = "NULL";
            SoLanTestJig1va2.Text = "NULL";
            ApSuatTest1va2.Text = "NULL";
            if (plcLoiLoc.plc.IsConnected == true)
            {
                plcLoiLoc.GetData();

                if (plcLoiLoc.loiloc.LoiLocName == TenThietBi.LoiLoc1)
                {
                    ThoiGianXa1.Text = plcLoiLoc.loiloc.ThoiGianXa.ToString();
                    ThoiGianNen1.Text = plcLoiLoc.loiloc.ThoiGianNen.ToString();
                    ThoiGianGiu1.Text = plcLoiLoc.loiloc.ThoiGianGiu.ToString();
                    SoLanTestJig1.Text = plcLoiLoc.loiloc.SoLanTest.ToString();
                    ApSuatTest1.Text = plcLoiLoc.loiloc.ApSuatTest.ToString();
                }
                else if (plcLoiLoc.loiloc.LoiLocName == TenThietBi.LoiLoc2)
                {
                    ThoiGianXa2.Text = plcLoiLoc.loiloc.ThoiGianXa.ToString();
                    ThoiGianNen2.Text = plcLoiLoc.loiloc.ThoiGianNen.ToString();
                    ThoiGianGiu2.Text = plcLoiLoc.loiloc.ThoiGianGiu.ToString();
                    SoLanTestJig2.Text = plcLoiLoc.loiloc.SoLanTest.ToString();
                    ApSuatTest2.Text = plcLoiLoc.loiloc.ApSuatTest.ToString();
                }
                else if (plcLoiLoc.loiloc.LoiLocName == TenThietBi.LoiLoc1va2)
                {
                    ThoiGianXa1va2.Text = plcLoiLoc.loiloc.ThoiGianXa.ToString();
                    ThoiGianNen1va2.Text = plcLoiLoc.loiloc.ThoiGianNen.ToString();
                    ThoiGianGiu1va2.Text = plcLoiLoc.loiloc.ThoiGianGiu.ToString();
                    SoLanTestJig1va2.Text = plcLoiLoc.loiloc.SoLanTest.ToString();
                    ApSuatTest1va2.Text = plcLoiLoc.loiloc.ApSuatTest.ToString();
                }
            }
            else
            {
                timer1.Stop();
            }

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPageGiamSat)
                LoadFormGiamSat();
            else if (e.TabPage == tabPageThongKe)
                LoadFormThongKe();
        }
    }
}
