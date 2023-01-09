using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.CongTacManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
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

        void LoadFormThongKe()
        {
            panelSearchPage2VT.Enabled = false;





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

        private void CongTac_Load(object sender, EventArgs e)
        {
            for (int i = 10; i >= 1; i--)
            {
                TemplateJigCongTac form = new TemplateJigCongTac(i);
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                tabPageGiamSat.Controls.Add(form);
                form.Show();

            }


            LoadFormThongKe();

        }

        private void CongTac_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TemplateJigCongTac item in tabPageGiamSat.Controls)
            {
                item.Close();
                item.Dispose();
            }
        }
    }
}
