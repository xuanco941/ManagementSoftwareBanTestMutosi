using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.JigMachManagement;
using ManagementSoftware.GUI.NguonManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
using ManagementSoftware.Models.JigMachModel;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class JigMach : Form
    {
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;



        public JigMach()
        {
            InitializeComponent();
            giamSatJigMachNguon = new GiamSatJigMachNguon();
            giamSatJigMachTDS = new GiamSatJigMachTDS();

        }
        private void JigMach_Load(object sender, EventArgs e)
        {
            giamSatJigMachNguon.TopLevel = false;
            tabPageGiamSatJigNguon.Controls.Add(giamSatJigMachNguon);
            giamSatJigMachNguon.FormBorderStyle = FormBorderStyle.None;
            giamSatJigMachNguon.Dock = DockStyle.Fill;
            giamSatJigMachNguon.Show();
            giamSatJigMachNguon.StartTimer();

            giamSatJigMachTDS.TopLevel = false;
            tabPageGiamSatJigTDS.Controls.Add(giamSatJigMachTDS);
            giamSatJigMachTDS.FormBorderStyle = FormBorderStyle.None;
            giamSatJigMachTDS.Dock = DockStyle.Fill;
            giamSatJigMachTDS.Show();

            LoadDGV();
            LoadDGV2();

        }
        void LoadDGV()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Jig";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Dòng áp DC (V)";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Dòng điện DC (A)";
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
        // ngày để query 
        private DateTime? timeStart = null;
        private DateTime? timeEnd = null;
        // trang hiện tại
        private int page = 1;



        // tổng số trang
        private int TotalPages = 0;
        //Data
        List<TestJigMach> ListResults = new List<TestJigMach>();

        private void LoadFormThongKe()
        {
            panel2.Enabled = false;

            dataGridView1.Rows.Clear();


            PaginationJigMach pagination = new PaginationJigMach();
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
                List<Models.JigMachModel.JigMachNguon>? l = new DALJigMach().GetDataFromIDTest(item.TestJigMachID);

                if (l != null && l.Count > 0)
                {
                    string date = "ID" + item.TestJigMachID + " - " + item.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.JigMachNguonName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = String.Format("{0:0.00}", i.DienApDC);
                        row.Cells[4].Value = String.Format("{0:0.00}", i.DongDienDC);
                        row.Cells[5].Value = String.Format("{0:0.00}", i.CongSuat);
                        row.Cells[6].Value = i.ThoiGian;
                        row.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    dataGridView1.Rows.Add();
                }

            }

            panel2.Enabled = true;
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



        GiamSatJigMachNguon giamSatJigMachNguon;
        GiamSatJigMachTDS giamSatJigMachTDS;


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageGiamSatJigNguon)
            {
                giamSatJigMachNguon.StartTimer();
                giamSatJigMachTDS.StopTimer();

            }
            else if (tabControl1.SelectedTab == tabPageGiamSatJigTDS)
            {
                giamSatJigMachTDS.StartTimer();
                giamSatJigMachNguon.StopTimer();

            }
            else if (tabControl1.SelectedTab == tabPageThongKe)
            {
                LoadFormThongKe();
                giamSatJigMachTDS.StopTimer();
                giamSatJigMachNguon.StopTimer();


            }
            else if (tabControl1.SelectedTab == tabPageThongKeTDS)
            {
                LoadFormThongKeTDS();
                giamSatJigMachTDS.StopTimer();
                giamSatJigMachNguon.StopTimer();

            }

        }















        // ngày để query 
        private DateTime? timeStart2 = null;
        private DateTime? timeEnd2 = null;
        // trang hiện tại
        private int page2 = 1;



        // tổng số trang
        private int TotalPages2 = 0;
        //Data
        List<TestJigMach> ListResults2 = new List<TestJigMach>();


        void LoadDGV2()
        {
            DataGridViewColumn STT = new DataGridViewTextBoxColumn();
            STT.HeaderText = "ID-Date";
            DataGridViewColumn name = new DataGridViewTextBoxColumn();
            name.HeaderText = "Jig";
            DataGridViewColumn lanTest = new DataGridViewTextBoxColumn();
            lanTest.HeaderText = "Lần test thứ";
            DataGridViewColumn dienAp = new DataGridViewTextBoxColumn();
            dienAp.HeaderText = "Van điện từ";
            DataGridViewColumn dongDC = new DataGridViewTextBoxColumn();
            dongDC.HeaderText = "Van áp cao";
            DataGridViewColumn ThoiGian = new DataGridViewTextBoxColumn();
            ThoiGian.HeaderText = "Thời gian (giây)";



            dataGridView2.Columns.Add(STT);
            dataGridView2.Columns.Add(name);
            dataGridView2.Columns.Add(lanTest);
            dataGridView2.Columns.Add(dienAp);
            dataGridView2.Columns.Add(dongDC);
            dataGridView2.Columns.Add(ThoiGian);


            dataGridView2.RowTemplate.Height = 35;

        }

        private void LoadFormThongKeTDS()
        {
            panelSearch2.Enabled = false;

            dataGridView2.Rows.Clear();


            PaginationJigMach pagination = new PaginationJigMach();
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
                List<Models.JigMachModel.JigMachTDS>? l = new DALJigMach().GetDataFromIDTestTDS(item.TestJigMachID);

                if (l != null && l.Count > 0)
                {
                    string date = "ID" + item.TestJigMachID + " - " + item.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.JigMachTDSName;
                        row.Cells[2].Value = i.LanTestThu;
                        row.Cells[3].Value = i.VanDienTu == true ? "ON" : "OFF";
                        row.Cells[4].Value = i.VanApCao == true ? "ON" : "OFF";
                        row.Cells[5].Value = i.ThoiGian;
                        row.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    dataGridView2.Rows.Add();
                }

            }

            panelSearch2.Enabled = true;
        }

        private void buttonPreviousPage2_Click(object sender, EventArgs e)
        {
            if (this.page2 > 1)
            {
                this.page2 = this.page2 - 1;
                LoadFormThongKeTDS();
            }
        }

        private void buttonNextPage2_Click(object sender, EventArgs e)
        {
            if (this.page2 < this.TotalPages2)
            {
                this.page2 = this.page2 + 1;
                LoadFormThongKeTDS();
            }
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            timeStart2 = TimeStart2.Value;
            timeEnd2 = TimeEnd2.Value;
            LoadFormThongKeTDS();
        }

        private void buttonGoto2_Click(object sender, EventArgs e)
        {
            this.page2 = int.Parse(pageNumberGoto2.Text);
            LoadFormThongKeTDS();
        }
    }
}
