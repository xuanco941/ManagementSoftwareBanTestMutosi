using Syncfusion.DocIO.DLS;
using Syncfusion.Windows.Forms.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ManagementSoftware
{
    public partial class FormTest : Form
    {
        Bitmap MemoryImage;
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        public FormTest()
        {
            InitializeComponent();
            sfBarcode1.Symbology = BarcodeSymbolType.Code128B;
            sfBarcode1.Text = "ABC-123-abc-A123";
            sfBarcode1.TextGapHeight = 5;

            printDocument1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);

        }
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panelPrintBarcode.Width / 2), this.panelPrintBarcode.Location.Y);
        }
        public void Print(Panel pnl)
        {
            Panel pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printDocument1;
            previewdlg.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Print(this.panelPrintBarcode);
        }
    }
}
