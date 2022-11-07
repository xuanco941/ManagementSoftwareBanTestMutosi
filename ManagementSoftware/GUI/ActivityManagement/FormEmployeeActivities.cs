using ManagementSoftware.BUS;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
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

namespace ManagementSoftware.GUI.ActivityManagement
{
    public partial class FormEmployeeActivities : Form
    {
        // trang hiện tại
        private int page = 1;
        // tổng số trang
        private int TotalPages = 1;
        private string username = "";
        public FormEmployeeActivities()
        {
            InitializeComponent();

            dataGridViewUserActivity.ColumnHeadersDefaultCellStyle.Font = Common.FontHeaderColumnDGV;
            dataGridViewUserActivity.RowTemplate.Height = 35;

            //try
            //{
            LoadPanelUser();
            //}
            //catch
            //{
            //    //lỗi tải danh sách user
            //    MessageBox.Show("Không thể tải danh sách người có thao tác hoạt động.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void LoadPanelUser()
        {
            //lấy danh sách id_user tham gia hoạt động, sau đó tìm thông tin user đó và thêm vào list user
            var list = BUSActivity.GetListActivityHasDistinctUsername();
            if (list != null)
            {
                foreach (var a in list)
                {
                    if (String.IsNullOrEmpty(a) == false)
                    {
                        string fullnameButton = a;

                        var user = BUSUser.GetUserFromUsername(a);
                        if (user != null)
                        {
                            fullnameButton = user.FullName;
                        }
                        else
                        {
                            fullnameButton = a + " (không tồn tại)";
                        }

                        Button btn = new Button();
                        btn.Height = 50;
                        btn.Text = fullnameButton;
                        //tag để lưu username
                        btn.Tag = a;
                        btn.ForeColor = Color.FromName("#B0B3B8");
                        btn.BackColor = Color.FromName("#3a3b3c");
                        btn.Dock = DockStyle.Top;
                        btn.Cursor = Cursors.Hand;
                        btn.Click += new EventHandler(handleClickButtonUser);
                        panelUser.Controls.Add(btn);

                    }
                }

            }



            // load 1 thông tin của user
            if (panelUser.Controls.Count > 0)
            {
                string username = panelUser.Controls[0].Tag.ToString();
                if (username != null)
                {
                    this.username = username;
                    GetActivities();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để tải lên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void LoadDatagridView(List<Activity> activities)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Loại");
            dt.Columns.Add("Mô tả");
            dt.Columns.Add("Thời gian");
            activities.ForEach(delegate (Activity activity)
            {
                string createAt = activity.CreateAt.ToString("hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                dt.Rows.Add(activity.ActivityName, activity.Description, createAt);
            });
            dataGridViewUserActivity.DataSource = dt;
        }

        private void GetActivities()
        {

            try
            {
                PaginationActivityAUser paginationActivityAUser = BUSActivity.GetDataAUser(this.page, null, null, this.username);
                List<Activity>? activities = paginationActivityAUser.ListResults;

                // pagesize bằng tổng số activity chia cho số phần tử mỗi trang
                this.TotalPages = paginationActivityAUser.TotalPages;
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

                LoadDatagridView(activities);

            }
            catch
            {
                // Lỗi
                MessageBox.Show("Không thể tải lên dữ liệu", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //function delegate event click button render from list user
        private void handleClickButtonUser(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string username = btn.Tag.ToString();
            if (username != null)
            {
                this.page = 1;
                this.username = username;
                GetActivities();
            }
        }

        private void buttonPage1_Click(object sender, EventArgs e)
        {
            // select button trang
            if (String.IsNullOrEmpty(this.username) == false)
            {
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

        }

        private void buttonPageNext_Click(object sender, EventArgs e)
        {
            if (this.page == this.TotalPages)
            {
                //MessageBox.Show("Bạn đang ở trang cuối cùng", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
