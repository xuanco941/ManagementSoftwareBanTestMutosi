using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSoftware.GUI.Section;
namespace ManagementSoftware.GUI
{
    public partial class Settings : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        //pagination datagridview setting
        // trang hiện tại
        private int page = 1;
        // tổng số trang
        private int pageSize = 1;

        public Settings()
        {
            InitializeComponent();

            //setting
            //LoadSetting();

            // template setting
            dataGridViewTemplateSetting.RowTemplate.Height = 50;
            //LoadDataGridViewTemplateSetting();

            //shift
            dataGridViewShift.RowTemplate.Height = 50;
            //LoadDataGridViewShift();

            //Setting
            dataGridViewActivitySetting.RowTemplate.Height = 36;
            //GetActivities();


        }

        //textbox only number type tabpage 1
        private void textBoxT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            LW_PhanMemBaoGia.MyControls.TextBoxT textBoxT = sender as LW_PhanMemBaoGia.MyControls.TextBoxT;
            //textbox only number 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //giới hạn length cho text box là 6
            if (textBoxT.Texts.Length > 5)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8 || e.KeyChar == 46)
            {
                e.Handled = false;
            }
        }

    }
}
