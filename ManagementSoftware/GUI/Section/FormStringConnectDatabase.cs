using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.Section
{
    public partial class FormStringConnectDatabase : Form
    {
        public FormStringConnectDatabase()
        {
            InitializeComponent();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "ConnectStringDB.txt");
            textBox1.Text = File.ReadAllText(path);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "ConnectStringDB.txt");
            File.WriteAllText(path, String.Empty);

            File.WriteAllText(path, textBox1.Text);

            Application.Restart();
        }
    }
}
