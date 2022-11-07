using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;

namespace ManagementSoftware.GUI.ActivityManagement
{
    public partial class FormChangeNumElmOnPage : Form
    {
        // Define delegate
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);

        // Create instance (null)
        public ChangeData changeData;

        public FormChangeNumElmOnPage()
        {
            InitializeComponent();
            inputNumPageGo.MinValue = 1;
            inputNumPageGo.MaxValue = 9999;
            inputNumPageGo.DefaultValue = PaginationActivity.NumberRows;
            inputNumPageGo.Text = PaginationActivity.NumberRows.ToString();
            label1.Text = $"Số dòng hiển thị (hiện tại là {PaginationActivity.NumberRows}):";
        }

        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            PaginationActivity.NumberRows = (int) inputNumPageGo.IntegerValue;
            changeData.Invoke("Cập nhật số dòng hiển thị trang hoạt động là: " + (int)inputNumPageGo.IntegerValue, FormAlert.enmType.Success);
            this.Close();
        }

        private void inputNumPageGo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PaginationActivity.NumberRows = (int)inputNumPageGo.IntegerValue;
                changeData.Invoke("Cập nhật số dòng hiển thị trang hoạt động là: " + (int)inputNumPageGo.IntegerValue, FormAlert.enmType.Success);
                this.Close();
            }

        }
    }
}
