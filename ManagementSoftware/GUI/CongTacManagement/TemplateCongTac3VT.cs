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
    public partial class TemplateCongTac3VT : Form
    {
        public TemplateCongTac3VT(int j)
        {
            InitializeComponent();
            labelNameJig.Text = "Jig " + j;
        }
    }
}
