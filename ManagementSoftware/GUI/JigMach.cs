using ManagementSoftware.GUI.JigMachManagement;
using ManagementSoftware.GUI.Section;
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
    public partial class JigMach : Form
    {
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        public JigMach()
        {
            InitializeComponent();

            //set new content
            FormJigMachNguon form = new FormJigMachNguon();
            form.TopLevel = false;
            tabPageGiamSatJigMach.Controls.Add(form);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Top;
            form.Show();


            //set new content
            FormJigMachTDS form2 = new FormJigMachTDS();
            form2.TopLevel = false;
            tabPageGiamSatJigMach.Controls.Add(form2);
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Top;
            form2.Show();
            this.Font = Common.FontForm;


            LoadFormThongKe();
        }

        void LoadFormThongKe()
        {
            for (int i = 0; i < 3; i++)
            {
                ItemThongKeJigMach form = new ItemThongKeJigMach();
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
        }

    }
}
