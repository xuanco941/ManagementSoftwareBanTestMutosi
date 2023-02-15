using ClosedXML.Excel;
using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.NguonManagement;
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



        public void StartTimer2()
        {
            if (timer2 == null)
            {
                timer2 = new System.Threading.Timer(Callback2, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
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


           

            PaginationLoiLoc pagination = new PaginationLoiLoc();
            pagination.Set(page, timeStart, timeEnd);

            // Nếu có dữ liệu mới và khác với dữ liệu cũ
            if (pagination.ListResults != null && pagination.ListResults.Count > 0
                && (this.ListResults?.SequenceEqual(pagination.ListResults) == false) )
            {
                this.ListResults = new List<Models.LoiLocModel.LoiLoc>(pagination.ListResults);
                this.TotalPages = pagination.TotalPages;
                UpdateData2(pagination.ListResults);
            }


            if (timer2 != null)
            {
                timer2.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }




        private void UpdateData2(List<Models.LoiLocModel.LoiLoc> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.LoiLocModel.LoiLoc>>(UpdateData2), list);
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






            bool checkColor = false;
            foreach (var item in list)
            {
                string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);

                int rowId = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells[0].Value = date;
                row.Cells[1].Value = item.LoiLocName;
                row.Cells[2].Value = item.SoLanTest;
                row.Cells[3].Value = item.ApSuatTest;
                row.Cells[4].Value = item.ThoiGianNen;
                row.Cells[5].Value = item.ThoiGianGiu;
                row.Cells[6].Value = item.ThoiGianXa;
                if (checkColor == true)
                {
                    row.DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                checkColor = !checkColor;

            }


           


        }




















        private void LoadFormThongKe()
        {
            StopTimer2();
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
                string date = item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);

                int rowId = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowId];

                row.Cells[0].Value = date;
                row.Cells[1].Value = item.LoiLocName;
                row.Cells[2].Value = item.SoLanTest;
                row.Cells[3].Value = item.ApSuatTest;
                row.Cells[4].Value = item.ThoiGianNen;
                row.Cells[5].Value = item.ThoiGianGiu;
                row.Cells[6].Value = item.ThoiGianXa;
                if (checkColor == true)
                {
                    row.DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                checkColor = !checkColor;

            }


            panel2.Enabled = true;
            StartTimer2();
        }





























        // Giam sat

        PLCLoiLoc plc;

        System.Threading.Timer? timer = null;
        System.Threading.Timer? timer2 = null;

        int TIME_INTERVAL_IN_MILLISECONDS = 0;



        public LoiLoc()
        {
            InitializeComponent();

            plc = new PLCLoiLoc(ControlAllPLC.ipLoiLoc, ControlAllPLC.PLCLoiLoc);

            dataGridView1.RowTemplate.Height = 35;
        }


        public async void StartTimer1()
        {
            if (timer == null && await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback1, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
        }

        public async void StopTimer1()
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            await plc.Close();
        }


        private async void LoiLoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer2();
            StopTimer1();

        }

        private async void LoiLoc_Load(object sender, EventArgs e)
        {
            LoadDGV();

            StartTimer1();



        }



        private async void Callback1(Object state)
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


            if (timer != null)
            {
                timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
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

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageGiamSat)
            {
                this.StartTimer1();
                this.StopTimer2();

            }
            else if (tabControl1.SelectedTab == tabPageThongKe)
            {
                LoadFormThongKe();
                this.StopTimer1();
            }
        }















































        //Xuat Excel

        void XuatExcel(string title, DataGridView dgv)
        {
            if (dgv.Rows != null && dgv.Rows.Count != 0)
            {

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel | *.xlsx | Excel 2016 | *.xls" })
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (var workBook = new XLWorkbook())
                            {


                                var ws = workBook.Worksheets.Add("Lịch sử test");

                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = title;
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;


                                for (int i = 0; i < dgv.Columns.Count; i++)
                                {
                                    ws.Cell(2, 1 + i).Value = dgv.Columns[i].HeaderText;
                                }

                                for (int i = 0; i < dgv.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgv.Columns.Count; j++)
                                    {
                                        ws.Cell(i + 3, j + 1).Value = dgv.Rows[i].Cells[j].Value.ToString();
                                        ws.Cell(i + 3, j + 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    }
                                }

                                string tenfile = ".xlsx";
                                workBook.SaveAs(sfd.FileName + DateTime.Now.ToString("dd_mm_yyyy_hhmmss") + tenfile);
                                MessageBox.Show("xuất file thành công");
                            }
                    }
                        catch
                {
                    MessageBox.Show("Không thể xuất file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu để xuất Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void buttonXuatExcel_Click(object sender, EventArgs e)
        {
            StopTimer2();
            XuatExcel("Test Lõi Lọc", dataGridView1);
            StartTimer2();
        }
    }
}
