using ManagementSoftware.DAL.DALPagination;
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
        private int TotalPages = 1;
        //Data
        Dictionary<TestLoiLoc, List<Models.LoiLoc>> ListResults;

        public LoiLoc()
        {
            InitializeComponent();

            LoadFormThongKe();
        }

        void LoadFormThongKe()
        {
            PaginationLoiLoc pagination = new PaginationLoiLoc();
            pagination.Set(page,timeStart,timeEnd);
            this.ListResults = pagination.ListResults;
            this.TotalPages = pagination.TotalPages;


            foreach (var e in this.ListResults)
            {
                ItemThongKeLoiLoc form = new ItemThongKeLoiLoc(e.Key,e.Value);
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
        }

    }
}
