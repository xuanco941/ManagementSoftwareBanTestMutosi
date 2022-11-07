using Syncfusion.Windows.Forms.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            sfBarcode1.Symbology = BarcodeSymbolType.Code128B;
            sfBarcode1.Text = "ABC-123-abc-A123";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
