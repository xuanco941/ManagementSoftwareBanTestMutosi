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
    public partial class TemplateJigCongTac : Form
    {
        public TemplateJigCongTac(int j)
        {
            InitializeComponent();
            labelNameJig.Text = "Jig " + j;

        }

        private void TemplateJigCongTac_Load(object sender, EventArgs e)
        {

        }
    }
}
