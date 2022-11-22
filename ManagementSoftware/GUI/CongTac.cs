using ManagementSoftware.GUI.CongTacManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
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

        public CongTac()
        {
            InitializeComponent();

            LoadFormThongKe2VT();
            LoadFormThongKe3VT();
            LoadTabPageCongTac2VT();
            LoadTabPageCongTac3VT();
        }

        void LoadFormThongKe2VT()
        {
            for (int i = 0; i < 5; i++)
            {
                ItemCongTac2VT form = new ItemCongTac2VT();
                form.TopLevel = false;
                panelThongKe2VT.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
        }
        void LoadFormThongKe3VT()
        {
            for (int i = 0; i < 5; i++)
            {
                ItemCongTac3VT form = new ItemCongTac3VT();
                form.TopLevel = false;
                panelThongKe3VT.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
        }

        void LoadTabPageCongTac2VT()
        {
            for(int i = 10; i >=1; i--)
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

    }
}
