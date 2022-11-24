using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.CongTacManagement
{
    public partial class TemplateCongTac2VT : Form
    {
        public TemplateCongTac2VT(int j)
        {
            InitializeComponent();
            labelNameJig.Text = "Jig " + j;

            ActiveToggleButton(toggleButton1,true);
            ActiveToggleButton(toggleButton2,false);
            ActiveToggleButton(toggleButton3, true);
            ActiveToggleButton(toggleButton4, true);
            ActiveToggleButton(toggleButton7, true);


        }


        void ActiveToggleButton(ToggleButton button,bool status)
        {
            //button.Enabled = false;
            button.ActiveState.Text = "ON";


            button.InactiveState.BackColor = Color.White;
            button.InactiveState.BorderColor = Color.FromArgb(150, 150, 150);
            button.InactiveState.ForeColor = Color.FromArgb(80, 80, 80);
            button.InactiveState.HoverColor = Color.White;
            button.InactiveState.Text = "OFF";
            if (status)
            {
                button.ToggleState = ToggleButtonState.Active;

            }
            else
            {
                button.ToggleState = ToggleButtonState.Inactive;
            }
        }
    }
}
