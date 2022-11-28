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


        void LoadTabPageCongTac2VT()
        {
            for (int i = 10; i >= 1; i--)
            {
                TemplateCongTac2VT form = new TemplateCongTac2VT(i);
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                tabPageCT2ViTri.Controls.Add(form);
                form.Show();

            }
        }

        void LoadTabPageCongTac3VT()
        {
            for (int i = 10; i >= 1; i--)
            {
                TemplateCongTac3VT form = new TemplateCongTac3VT(i);
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                tabPageCT3ViTri.Controls.Add(form);
                form.Show();
            }
        }





        //CT2VT
        private DateTime? timeStart2VT = null;
        private DateTime? timeEnd2VT = null;
        private int page2VT = 1;
        private int TotalPages2VT = 0;
        Dictionary<TestCongTac2VT, List<Models.CongTac2VT>> ListResults2VT;

        //CT3VT
        private DateTime? timeStart3VT = null;
        private DateTime? timeEnd3VT = null;
        private int page3VT = 1;
        private int TotalPages3VT = 0;
        Dictionary<TestCongTac3VT, List<Models.CongTac3VT>> ListResults3VT;

        public CongTac()
        {
            InitializeComponent();

            LoadTabPageCongTac2VT();
            LoadTabPageCongTac3VT();
            LoadFormThongKe2VT();
            LoadFormThongKe3VT();
        }

        void LoadFormThongKe2VT()
        {
            panelSearchPage2VT.Enabled = false;
            foreach (Form item in panelThongKe2VT.Controls)
            {
                item.Close();
                item.Dispose();
            }
            panelThongKe2VT.Controls.Clear();


            PaginationCongTac2VT pagination = new PaginationCongTac2VT();
            pagination.Set(page2VT, timeStart2VT, timeEnd2VT);
            this.ListResults2VT = pagination.ListResults;
            this.TotalPages2VT = pagination.TotalPages;
            lbTotalPages2VT.Text = this.TotalPages2VT.ToString();

            buttonPreviousPage2VT.Enabled = this.page2VT > 1;
            buttonNextPage2VT.Enabled = this.page2VT < this.TotalPages2VT;
            buttonPage2VT.Text = this.page2VT.ToString();

            pageNumberGoto2VT.MinValue = 1;
            pageNumberGoto2VT.MaxValue = this.TotalPages2VT != 0 ? this.TotalPages2VT : 1;

            for (int i = ListResults2VT.Count - 1; i >= 0; i--)
            {
                ItemCongTac2VT form = new ItemCongTac2VT(ListResults2VT.ElementAt(i).Key, ListResults2VT.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe2VT.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
            panelSearchPage2VT.Enabled = true;
        }

        void LoadFormThongKe3VT()
        {
            panelSearchPage3VT.Enabled = false;
            foreach (Form item in panelThongKe3VT.Controls)
            {
                item.Close();
                item.Dispose();
            }
            panelThongKe3VT.Controls.Clear();


            PaginationCongTac3VT pagination = new PaginationCongTac3VT();
            pagination.Set(page3VT, timeStart3VT, timeEnd3VT);
            this.ListResults3VT = pagination.ListResults;
            this.TotalPages3VT = pagination.TotalPages;
            lbTotalPages3VT.Text = this.TotalPages3VT.ToString();

            buttonPreviousPage3VT.Enabled = this.page3VT > 1;
            buttonNextPage3VT.Enabled = this.page3VT < this.TotalPages3VT;
            buttonPage3VT.Text = this.page3VT.ToString();

            pageNumberGoto3VT.MinValue = 1;
            pageNumberGoto3VT.MaxValue = this.TotalPages3VT != 0 ? this.TotalPages3VT : 1;

            for (int i = ListResults3VT.Count - 1; i >= 0; i--)
            {
                ItemCongTac3VT form = new ItemCongTac3VT(ListResults3VT.ElementAt(i).Key, ListResults3VT.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe3VT.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
            panelSearchPage3VT.Enabled = true;
        }


        private void buttonPreviousPage2VT_Click(object sender, EventArgs e)
        {
            if (this.page2VT > 1)
            {
                this.page2VT = this.page2VT - 1;
                LoadFormThongKe2VT();
            }
        }

        private void buttonNextPage2VT_Click(object sender, EventArgs e)
        {
            if (this.page2VT < this.TotalPages2VT)
            {
                this.page2VT = this.page2VT + 1;
                LoadFormThongKe2VT();
            }
        }

        private void buttonSearch2VT_Click(object sender, EventArgs e)
        {
            timeStart2VT = TimeStart2VT.Value;
            timeEnd2VT = TimeEnd2VT.Value;
            LoadFormThongKe2VT();
        }

        private void buttonGoto2VT_Click(object sender, EventArgs e)
        {
            this.page2VT = int.Parse(pageNumberGoto2VT.Text);
            LoadFormThongKe2VT();
        }
        private void buttonPreviousPage3VT_Click(object sender, EventArgs e)
        {
            if (this.page3VT > 1)
            {
                this.page3VT = this.page3VT - 1;
                LoadFormThongKe3VT();
            }
        }
        private void buttonNextPage3VT_Click(object sender, EventArgs e)
        {
            if (this.page3VT < this.TotalPages3VT)
            {
                this.page3VT = this.page3VT + 1;
                LoadFormThongKe3VT();
            }
        }

        private void buttonSearch3VT_Click(object sender, EventArgs e)
        {
            timeStart3VT = TimeStart3VT.Value;
            timeEnd3VT = TimeEnd3VT.Value;
            LoadFormThongKe3VT();
        }

        private void buttonGoto3VT_Click(object sender, EventArgs e)
        {
            this.page3VT = int.Parse(pageNumberGoto3VT.Text);
            LoadFormThongKe3VT();
        }
    }
}
