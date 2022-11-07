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
using ManagementSoftware.GUI.ActivityManagement;
using ManagementSoftware.Models;
using ManagementSoftware.BUS;
using ManagementSoftware.DAL.DALPagination;
namespace ManagementSoftware.GUI
{
    public partial class ActivityHistory : Form
    {
        // Aleart
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;


        // ngày để query 
        private DateTime? timeStart = null;
        private DateTime? timeEnd = null;
        // trang hiện tại
        private int page = 1;
        // tổng số trang
        private int TotalPages = 1;

        public ActivityHistory()
        {
            InitializeComponent();

            //setting header column
            dataGridViewActivity.ColumnHeadersDefaultCellStyle.Font = Common.FontHeaderColumnDGV;
            dataGridViewActivity.RowTemplate.Height = 35;

            inputNumPageGo.DefaultValue = 1;
            inputNumPageGo.MinValue = 1;

            GetActivities();
        }

        private void LoadForm(List<Activity>? activities)
        {
            //
            labelBanGhiMoiTrang.Text = "- Tổng số trang: " + this.TotalPages + ".";
            labelTongSoTrang.Text = "- Bản ghi mỗi trang: " + PaginationActivity.NumberRows + ".";
            labelPage.Text = "- Đang ở trang: " + this.page + ".";

            //
            if (timeStart != null && timeEnd != null)
            {
                labelTuNgay.Text = "- Lọc từ ngày: " + timeStart?.Day + "-" + timeStart?.Month + "-" + timeStart?.Year + ".";
                labelToiNgay.Text = "- Lọc tới ngày: " + timeEnd?.Day + "-" + timeEnd?.Month + "-" + timeEnd?.Year + ".";
            }
            else
            {
                labelTuNgay.Text = "- Lọc từ ngày: trống.";
                labelToiNgay.Text = "- Lọc tới ngày: trống.";
            }

            //
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Loại");
            dt.Columns.Add("Mô tả");
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Người thực hiện");

            if (activities != null)
            {
                // load datagridview từ tham số activities truyền vào
                activities.ForEach(delegate (Activity activity)
                {
                    string? fullnameButton = activity.Username;
                    User? user = BUSUser.GetUserFromUsername(activity.Username);
                    if (String.IsNullOrEmpty(activity.Username) == false && user != null)
                    {
                        fullnameButton = user.FullName;
                    }
                    else
                    {
                        fullnameButton = activity.Username + " (không tồn tại)";
                    }
                    //format date từ sql -> c#
                    string createAt = activity.CreateAt.ToString("hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dt.Rows.Add(activity.ActivityID, activity.ActivityName, activity.Description, createAt, fullnameButton);
                });
            }
            dataGridViewActivity.DataSource = dt;
        }

        private void GetActivities()
        {

            try
            {
                PaginationActivity paginationActivity = BUSActivity.GetData(this.page, timeStart?.AddDays(-1), timeEnd);
                List<Activity>? activities = paginationActivity.ListResults;
                //số trang max
                inputNumPageGo.MaxValue = paginationActivity.TotalPages != 0 ? paginationActivity.TotalPages : 1;

                // pagesize bằng tổng số activity chia cho số phần tử mỗi trang
                this.TotalPages = paginationActivity.TotalPages;
                if (this.TotalPages == 0)
                {
                    buttonPage1.Enabled = false;
                    buttonPage2.Enabled = false;
                    buttonPage3.Enabled = false;
                    buttonPageNext.Enabled = false;
                }
                else if (this.TotalPages == 1)
                {
                    buttonPage1.Enabled = true;
                    buttonPage2.Enabled = false;
                    buttonPage3.Enabled = false;
                    buttonPageNext.Enabled = false;
                }
                else if (this.TotalPages == 2)
                {
                    buttonPage1.Enabled = true;
                    buttonPage2.Enabled = true;
                    buttonPage3.Enabled = false;
                    buttonPageNext.Enabled = false;
                }
                else if (this.TotalPages == 3)
                {
                    buttonPage1.Enabled = true;
                    buttonPage2.Enabled = true;
                    buttonPage3.Enabled = true;
                    buttonPageNext.Enabled = false;
                }
                else
                {
                    buttonPage1.Enabled = true;
                    buttonPage2.Enabled = true;
                    buttonPage3.Enabled = true;
                    buttonPageNext.Enabled = true;
                }

                LoadForm(activities);

            }
            catch
            {
                // Lỗi
                MessageBox.Show("Lỗi truy xuất liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLoc_Click(object sender, EventArgs e)
        {
            //lấy ngày ở datetimepicker rồi chuyển về dạng yyyy-mm-dd, lưu vào các strdatetime, field của lớp
            timeStart = dateTimePickerTuNgay.Value;
            timeEnd = dateTimePickerToiNgay.Value;

            //đặt page về trang 1, đặt các button về mặc định
            this.page = 1;
            buttonPage1.Text = 1.ToString();
            buttonPage2.Text = 2.ToString();
            buttonPage3.Text = 3.ToString();

            GetActivities();
        }

        private void buttonPage1_Click(object sender, EventArgs e)
        {
            // select button trang
            Button button = sender as Button;

            if (this.page > this.TotalPages)
            {
                this.page = this.TotalPages;
            }
            else
            {
                this.page = int.Parse(button.Text);
                if (this.page <= 2)
                {
                    buttonPage1.Text = 1.ToString();
                    buttonPage2.Text = 2.ToString();
                    buttonPage3.Text = 3.ToString();
                }
                else
                {
                    buttonPage1.Text = (page - 1).ToString();
                    buttonPage2.Text = page.ToString();
                    buttonPage3.Text = (page + 1).ToString();
                    //nếu tràng hiện tại là trang cuối cùng thì đặt các nút là các những trang cuối
                    if (this.page == this.TotalPages)
                    {
                        buttonPage1.Text = (page - 2).ToString();
                        buttonPage2.Text = (page - 1).ToString();
                        buttonPage3.Text = page.ToString();
                    }
                }
            }
            GetActivities();

        }

        private void buttonPageNext_Click(object sender, EventArgs e)
        {
            if (this.page == this.TotalPages)
            {
                callAlert?.Invoke("Bạn đang ở trang cuối cùng.", FormAlert.enmType.Info);
            }
            else
            {
                // bấm next sẽ là trang số ở button3 + 1
                int numPageButton3 = int.Parse(buttonPage3.Text);
                if (numPageButton3 < this.TotalPages)
                {
                    if (this.page == 1)
                    {
                        this.page = 3;
                        buttonPage1.Text = 2.ToString();
                        buttonPage2.Text = 3.ToString();
                        buttonPage3.Text = 4.ToString();
                    }
                    else
                    {
                        this.page = numPageButton3 + 1;
                        //set lại button 1,2,3 
                        if (this.page == this.TotalPages)
                        {
                            buttonPage1.Text = (this.page - 2).ToString();
                            buttonPage2.Text = (this.page - 1).ToString();
                            buttonPage3.Text = (this.page).ToString();
                        }
                        if (this.page + 1 <= this.TotalPages)
                        {
                            buttonPage1.Text = (this.page - 1).ToString();
                            buttonPage2.Text = (this.page).ToString();
                            buttonPage3.Text = (this.page + 1).ToString();
                        }
                        if (this.page + 2 <= this.TotalPages)
                        {
                            buttonPage1.Text = (this.page).ToString();
                            buttonPage2.Text = (this.page + 1).ToString();
                            buttonPage3.Text = (this.page + 2).ToString();
                        }
                    }


                }
                else
                {
                    this.page = this.TotalPages;
                }
                GetActivities();
            }
        }


        public void AlertActive(string msg, FormAlert.enmType enmType)
        {
            callAlert?.Invoke(msg, enmType);
            //load lai datagridview
            this.page = 1;
            buttonPage1.Text = 1.ToString();
            buttonPage2.Text = 2.ToString();
            buttonPage3.Text = 3.ToString();
            GetActivities();

        }

        private void btnChangeNumElmPage_Click(object sender, EventArgs e)
        {
            FormChangeNumElmOnPage form = new FormChangeNumElmOnPage();
            form.changeData = new FormChangeNumElmOnPage.ChangeData(AlertActive);
            form.ShowDialog();
        }

        private void buttonDeleteDataActivity_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa dữ liệu hoạt động đang hiển thị tại trang này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                List<int> atvIDs = new List<int>();
                foreach (DataGridViewRow row in dataGridViewActivity.Rows)
                {
                    //tao mang id activity can xoa
                    atvIDs.Add(int.Parse(row.Cells[0].Value.ToString()));
                }
                try
                {
                    BUSActivity.DeleteActivities(atvIDs);
                }
                catch(Exception ex)
                {
                    callAlert?.Invoke(ex.Message,FormAlert.enmType.Warning);
                }
                this.page = 1;
                buttonPage1.Text = 1.ToString();
                buttonPage2.Text = 2.ToString();
                buttonPage3.Text = 3.ToString();
                GetActivities();
                callAlert?.Invoke("Xóa thành công!", FormAlert.enmType.Success);
            }
        }

        private void buttonCallFormEmployeeActivities_Click(object sender, EventArgs e)
        {
            new FormEmployeeActivities().Show();
        }

        private void buttonCustomGoPage_Click(object sender, EventArgs e)
        {
            if (this.page > this.TotalPages)
            {
                this.page = this.TotalPages;
            }
            else
            {
                this.page = (int) inputNumPageGo.IntegerValue;
                if (this.page <= 2)
                {
                    buttonPage1.Text = 1.ToString();
                    buttonPage2.Text = 2.ToString();
                    buttonPage3.Text = 3.ToString();
                }
                else
                {
                    buttonPage1.Text = (page - 1).ToString();
                    buttonPage2.Text = page.ToString();
                    buttonPage3.Text = (page + 1).ToString();
                    //nếu tràng hiện tại là trang cuối cùng thì đặt các nút là các những trang cuối
                    if (this.page == this.TotalPages)
                    {
                        buttonPage1.Text = (page - 2).ToString();
                        buttonPage2.Text = (page - 1).ToString();
                        buttonPage3.Text = page.ToString();
                    }
                }
            }
            GetActivities();
        }
    }
}
