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


            giamSatJigMachTDS.TopLevel = false;
            tabPageGiamSatJigTDS.Controls.Add(giamSatJigMachTDS);
            giamSatJigMachTDS.FormBorderStyle = FormBorderStyle.None;
            giamSatJigMachTDS.Dock = DockStyle.Fill;
            giamSatJigMachTDS.Show();

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


            DataTable dt = new DataTable();
            dt.Columns.Add("ID-Date");
            dt.Columns.Add("Jig");
            dt.Columns.Add("Lần test thứ");
            dt.Columns.Add("Điện áp DC (V)");
            dt.Columns.Add("Dòng điện DC (A)");
            dt.Columns.Add("Công suất (W)");
            dt.Columns.Add("Thời gian (giây)");

            foreach (var item in this.ListResults)
            {
                List<Models.JigMachModel.JigMachNguon>? l = DALJigMach.GetDataFromIDTest(item.TestJigMachID);


                string id_date = "ID" + item.TestJigMachID + " - " + item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (l != null && l.Count > 0)
                {
                    foreach (var i in l)
                    {
                        dt.Rows.Add(id_date, i.JigMachNguonName, i.LanTestThu, String.Format("{0:0.00}", i.DienApDC), String.Format("{0:0.00}", i.DongDienDC), String.Format("{0:0.00}", i.CongSuat), i.ThoiGian);
                    }
                }
                dt.Rows.Add("", "", "", "", "", "", "");

            }

            dataGridView1.DataSource = dt;

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

        private void LoadFormThongKeTDS()
        {
            panelSearch2.Enabled = false;

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


            DataTable dt = new DataTable();
            dt.Columns.Add("ID-Date");
            dt.Columns.Add("Jig");
            dt.Columns.Add("Lần test thứ");
            dt.Columns.Add("Van điện từ");
            dt.Columns.Add("Van áp cao");
            dt.Columns.Add("Thời gian (giây)");

            foreach (var item in this.ListResults)
            {
                List<Models.JigMachModel.JigMachTDS>? l = DALJigMach.GetDataFromIDTestTDS(item.TestJigMachID);


                string id_date = "ID" + item.TestJigMachID + " - " + item.CreateAt.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (l != null && l.Count > 0)
                {
                    foreach (var i in l)
                    {
                        string vandt = i.VanDienTu == true ? "on" : "off";
                        string vanapcao = i.VanApCao == true ? "on" : "off";

                        dt.Rows.Add(id_date, i.JigMachTDSName, i.LanTestThu, vandt, vanapcao, i.ThoiGian);
                    }
                }
                dt.Rows.Add("", "", "", "", "", "");

            }

            dataGridView2.DataSource = dt;

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
