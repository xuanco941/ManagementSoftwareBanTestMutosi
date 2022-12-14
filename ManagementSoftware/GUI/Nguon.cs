using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.NguonManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
using ManagementSoftware.PLCSetting;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class Nguon : Form
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
        Dictionary<TestNguon, List<Models.Nguon>> ListResults;


        public Nguon()
        {
            InitializeComponent();
            NguonTu1Den15 form = new NguonTu1Den15();
            form.TopLevel = false;
            tabPageGiamSat1.Controls.Add(form);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
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


            PaginationNguon pagination = new PaginationNguon();
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
                ItemThongKeNguon form = new ItemThongKeNguon(ListResults.ElementAt(i).Key, ListResults.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
            panel2.Enabled = true;

        }
























        // Giam sat

        private void tabControl1_Selected_1(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageGiamSat1)
            {
                NguonTu1Den15 form = new NguonTu1Den15();
                form.TopLevel = false;
                tabPageGiamSat1.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
                foreach (NguonTu16Den30 f in tabPageGiamSat2.Controls)
                {
                    f.CloseForm();
                    f.Dispose();
                    f.Close();
                }

            }
            else if (tabControl1.SelectedTab == tabPageGiamSat2)
            {
                NguonTu16Den30 form = new NguonTu16Den30();
                form.TopLevel = false;
                tabPageGiamSat2.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
                foreach (NguonTu1Den15 f in tabPageGiamSat1.Controls)
                {
                    f.CloseForm();
                    f.Dispose();
                    f.Close();
                }

            }
            else if (tabControl1.SelectedTab == tabPageThongKe)
            {
                LoadFormThongKe();
                foreach (NguonTu1Den15 f in tabPageGiamSat1.Controls)
                {
                    f.CloseForm();
                    f.Dispose();
                    f.Close();
                }
                foreach (NguonTu16Den30 f in tabPageGiamSat2.Controls)
                {
                    f.CloseForm();
                    f.Dispose();
                    f.Close();
                }

            }
        }
    }


}
