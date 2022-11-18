using ManagementSoftware.GUI.JigMachManagement;
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
    public partial class LoiLoc : Form
    {
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        public LoiLoc()
        {
            InitializeComponent();

            LoadFormThongKe();
        }

        void LoadFormThongKe()
        {
            for (int i = 0; i < 3; i++)
            {
                ItemThongKeLoiLoc form = new ItemThongKeLoiLoc();
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
        }

    }
}
