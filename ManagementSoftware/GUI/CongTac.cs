using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.CongTacManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
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
            dataGridView1.Columns.Add(lanTest);
            dataGridView1.Columns.Add(dienAp);


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
                    string date = "ID" + item.TestCongTacID + " - " + item.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    foreach (var i in l)
                    {
                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        row.Cells[0].Value = date;
                        row.Cells[1].Value = i.CongTacName + " - " + i.JigCongTac ;
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



        void AddCT(TemplateJigCongTac form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;
            tabPageGiamSat.Controls.Add(form);
            form.Show();
        }
        private void CongTac_Load(object sender, EventArgs e)
        {
            TemplateJigCongTac form10 = new TemplateJigCongTac(104,106,108,110,112,10,1070);
            AddCT(form10);
            TemplateJigCongTac form9 = new TemplateJigCongTac(94, 96, 98, 100, 102, 9,1030);
            AddCT(form9);
            TemplateJigCongTac form8 = new TemplateJigCongTac(84, 86, 88, 90, 92, 8,1035);
            AddCT(form8);

            TemplateJigCongTac form7 = new TemplateJigCongTac(74, 76, 78, 80, 82, 7,1050);
            AddCT(form7);

            TemplateJigCongTac form6 = new TemplateJigCongTac(64, 66, 70, 52, 72, 6,1000);
            AddCT(form6);

            TemplateJigCongTac form5 = new TemplateJigCongTac(40, 42, 44, 46, 48, 5,980);
            AddCT(form5);

            TemplateJigCongTac form4 = new TemplateJigCongTac(30, 32, 34, 36, 38, 4,970);
            AddCT(form4);

            TemplateJigCongTac form3 = new TemplateJigCongTac(20, 22, 24, 26, 28, 3,990);
            AddCT(form3);

            TemplateJigCongTac form2 = new TemplateJigCongTac(50, 12, 14, 16, 18, 2,960);
            AddCT(form2);

            TemplateJigCongTac form1 = new TemplateJigCongTac(0, 2, 4, 6, 8, 1,950);
            AddCT(form1);


            LoadDGV();
            LoadFormThongKe();

        }
    }
}
