using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models.BepTuModel;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class BepTu : Form
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
        Dictionary<TestBepTu, List<Models.BepTuModel.BepTu>> ListResults;
        public BepTu()
        {
            InitializeComponent();

            LoadFormThongKe();
        }

        void LoadFormThongKe()
        {
            panel2.Enabled = false;
            foreach (Form item in panelThongKe.Controls)
            {
                item.Close();
                item.Dispose();
            }
            panelThongKe.Controls.Clear();


            PaginationBepTu pagination = new PaginationBepTu();
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
                ItemThongKeBepTu form = new ItemThongKeBepTu(ListResults.ElementAt(i).Key, ListResults.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
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
    }
}
