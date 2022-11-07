using ManagementSoftware.BUS;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.EmployeeManagement;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
using ManagementSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ManagementSoftware.GUI
{
    public partial class Employee : Form
    {
        // Aleart Delegate từ FormMain
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        //page
        private int pageUser = 1;
        private int TotalPagesUser = 1;

        private int TotalPagesGroup = 1;
        private int pageGroup = 1;
        public Employee()
        {
            InitializeComponent();
            // set chieu cao cua row datagridview la 50px
            dataGridViewUser.RowTemplate.Height = 50;
            dataGridViewGroup.RowTemplate.Height = 50;


            LoadDataUser();
            LoadDataGroup();
        }

        //method gọi Alert ở Main từ form khác thông qua form hiện tại, delegate
        public void AlertActive(string msg, FormAlert.enmType enmType)
        {
            callAlert?.Invoke(msg, enmType);
            //load lai 2 datagridview
            LoadDataUser();
            LoadDataGroup();
        }

        public void LoadDataUser()
        {
            // get all user from model
            DataTable dtUser = new DataTable();
            dtUser.Columns.Add("Mã NV");
            dtUser.Columns.Add("Họ tên");
            dtUser.Columns.Add("Tài khoản");
            dtUser.Columns.Add("Mật khẩu");
            dtUser.Columns.Add("Quyền");
            PaginationUser paginationUser = BUSUser.GetData(this.pageUser);
            this.TotalPagesUser = paginationUser.TotalPages; 

            paginationUser.ListResults?.ForEach(delegate (UserHasGroupName user)
            {
                dtUser.Rows.Add(Common.USERS+user.UserID,user.FullName, user.Username, user.Password, user.GroupName);
            });
            dataGridViewUser.DataSource = dtUser;


            if (this.TotalPagesUser == 0)
            {
                buttonPageUser1.Enabled = false;
                buttonPageUser2.Enabled = false;
                buttonPageUser3.Enabled = false;
                buttonPageUserNext.Enabled = false;
            }
            else if (this.TotalPagesUser == 1)
            {
                buttonPageUser1.Enabled = true;
                buttonPageUser2.Enabled = false;
                buttonPageUser3.Enabled = false;
                buttonPageUserNext.Enabled = false;
            }
            else if (this.TotalPagesUser == 2)
            {
                buttonPageUser1.Enabled = true;
                buttonPageUser2.Enabled = true;
                buttonPageUser3.Enabled = false;
                buttonPageUserNext.Enabled = false;
            }
            else if (this.TotalPagesUser == 3)
            {
                buttonPageUser1.Enabled = true;
                buttonPageUser2.Enabled = true;
                buttonPageUser3.Enabled = true;
                buttonPageUserNext.Enabled = false;
            }
            else
            {
                buttonPageUser1.Enabled = true;
                buttonPageUser2.Enabled = true;
                buttonPageUser3.Enabled = true;
                buttonPageUserNext.Enabled = true;
            }

        }
        public void LoadDataGroup()
        {
            DataTable dtGroup = new DataTable();
            dtGroup.Columns.Add("Mã nhóm quyền");
            dtGroup.Columns.Add("Tên nhóm quyền");
            dtGroup.Columns.Add("Quản trị nhân viên");
            dtGroup.Columns.Add("Quản trị nhóm quyền");
            PaginationGroup paginationGroup = BUSGroup.GetData(this.pageGroup);
            this.TotalPagesGroup = paginationGroup.TotalPages;

            paginationGroup.ListResults?.ForEach(delegate (Group group)
            {
                string IsManagementUser = group.IsManagementUser == true ? "Có" : "Không";
                string IsManagementGroup = group.IsManagementGroup == true ? "Có" : "Không";


                dtGroup.Rows.Add(Common.GROUPS+group.GroupID, group.GroupName, IsManagementUser, IsManagementGroup
                    );
            });
            dataGridViewGroup.DataSource = dtGroup;


            if (this.TotalPagesGroup == 0)
            {
                buttonPageGroup1.Enabled = false;
                buttonPageGroup2.Enabled = false;
                buttonPageGroup3.Enabled = false;
                buttonPageGroupNext.Enabled = false;
            }
            else if (this.TotalPagesGroup == 1)
            {
                buttonPageGroup1.Enabled = true;
                buttonPageGroup2.Enabled = false;
                buttonPageGroup3.Enabled = false;
                buttonPageGroupNext.Enabled = false;
            }
            else if (this.TotalPagesGroup == 2)
            {
                buttonPageGroup1.Enabled = true;
                buttonPageGroup2.Enabled = true;
                buttonPageGroup3.Enabled = false;
                buttonPageGroupNext.Enabled = false;
            }
            else if (this.TotalPagesGroup == 3)
            {
                buttonPageGroup1.Enabled = true;
                buttonPageGroup2.Enabled = true;
                buttonPageGroup3.Enabled = true;
                buttonPageGroupNext.Enabled = false;
            }
            else
            {
                buttonPageGroup1.Enabled = true;
                buttonPageGroup2.Enabled = true;
                buttonPageGroup3.Enabled = true;
                buttonPageGroupNext.Enabled = true;
            }
        }


        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new FormAddUser();
            formAddUser.changeData = new FormAddUser.ChangeData(AlertActive);
            formAddUser.ShowDialog();
        }

        private void buttonChangeUser_Click(object sender, EventArgs e)
        {
            FormChangeUser formChangeUser = new FormChangeUser();
            formChangeUser.changeData = new FormChangeUser.ChangeData(AlertActive);
            formChangeUser.ShowDialog();
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            FormAddGroup formAddGroup = new FormAddGroup();
            formAddGroup.changeData = new FormAddGroup.ChangeData(AlertActive);
            formAddGroup.ShowDialog();
        }

        private void buttonChangeGroup_Click(object sender, EventArgs e)
        {
            FormChangeGroup formChangeGroup = new FormChangeGroup();
            formChangeGroup.changeData = new FormChangeGroup.ChangeData(AlertActive);
            formChangeGroup.ShowDialog();
        }

        private void buttonPageGroup1_Click(object sender, EventArgs e)
        {
            // select button trang
            Button button = sender as Button;

            if (this.pageGroup > this.TotalPagesGroup)
            {
                this.pageGroup = this.TotalPagesGroup;
            }
            else
            {
                this.pageGroup = int.Parse(button.Text);
                if (this.pageGroup <= 2)
                {
                    buttonPageGroup1.Text = 1.ToString();
                    buttonPageGroup2.Text = 2.ToString();
                    buttonPageGroup3.Text = 3.ToString();
                }
                else
                {
                    buttonPageGroup1.Text = (pageGroup - 1).ToString();
                    buttonPageGroup2.Text = pageGroup.ToString();
                    buttonPageGroup3.Text = (pageGroup + 1).ToString();
                    //nếu tràng hiện tại là trang cuối cùng thì đặt các nút là các những trang cuối
                    if (this.pageGroup == this.TotalPagesGroup)
                    {
                        buttonPageGroup1.Text = (pageGroup - 2).ToString();
                        buttonPageGroup2.Text = (pageGroup - 1).ToString();
                        buttonPageGroup3.Text = pageGroup.ToString();
                    }
                }
            }
            LoadDataGroup();
        }

        private void buttonPageGroupNext_Click(object sender, EventArgs e)
        {
            if (this.pageGroup == this.TotalPagesGroup)
            {
                callAlert?.Invoke("Bạn đang ở trang cuối cùng.", FormAlert.enmType.Info);
            }
            else
            {
                // bấm next sẽ là trang số ở button3 + 1
                int numPageButton3 = int.Parse(buttonPageGroup3.Text);
                if (numPageButton3 < this.TotalPagesGroup)
                {
                    if (this.pageGroup == 1)
                    {
                        this.pageGroup = 3;
                        buttonPageGroup1.Text = 2.ToString();
                        buttonPageGroup2.Text = 3.ToString();
                        buttonPageGroup3.Text = 4.ToString();
                    }
                    else
                    {
                        this.pageGroup = numPageButton3 + 1;
                        //set lại button 1,2,3 
                        if (this.pageGroup == this.TotalPagesGroup)
                        {
                            buttonPageGroup1.Text = (this.pageGroup - 2).ToString();
                            buttonPageGroup2.Text = (this.pageGroup - 1).ToString();
                            buttonPageGroup3.Text = (this.pageGroup).ToString();
                        }
                        if (this.pageGroup + 1 <= this.TotalPagesGroup)
                        {
                            buttonPageGroup1.Text = (this.pageGroup - 1).ToString();
                            buttonPageGroup2.Text = (this.pageGroup).ToString();
                            buttonPageGroup3.Text = (this.pageGroup + 1).ToString();
                        }
                        if (this.pageGroup + 2 <= this.TotalPagesGroup)
                        {
                            buttonPageGroup1.Text = (this.pageGroup).ToString();
                            buttonPageGroup2.Text = (this.pageGroup + 1).ToString();
                            buttonPageGroup3.Text = (this.pageGroup + 2).ToString();
                        }
                    }


                }
                else
                {
                    this.pageGroup = this.TotalPagesGroup;
                }
                LoadDataGroup();
            }
        }

        private void buttonPageUser1_Click(object sender, EventArgs e)
        {
            // select button trang
            Button button = sender as Button;

            if (this.pageUser > this.TotalPagesUser)
            {
                this.pageUser = this.TotalPagesUser;
            }
            else
            {
                this.pageUser = int.Parse(button.Text);
                if (this.pageUser <= 2)
                {
                    buttonPageUser1.Text = 1.ToString();
                    buttonPageUser2.Text = 2.ToString();
                    buttonPageUser3.Text = 3.ToString();
                }
                else
                {
                    buttonPageUser1.Text = (pageUser - 1).ToString();
                    buttonPageUser2.Text = pageUser.ToString();
                    buttonPageUser3.Text = (pageUser + 1).ToString();
                    //nếu tràng hiện tại là trang cuối cùng thì đặt các nút là các những trang cuối
                    if (this.pageUser == this.TotalPagesUser)
                    {
                        buttonPageUser1.Text = (pageUser - 2).ToString();
                        buttonPageUser2.Text = (pageUser - 1).ToString();
                        buttonPageUser3.Text = pageUser.ToString();
                    }
                }
            }
            LoadDataUser();
        }

        private void buttonPageUserNext_Click(object sender, EventArgs e)
        {
            if (this.pageUser == this.TotalPagesUser)
            {
                callAlert?.Invoke("Bạn đang ở trang cuối cùng.", FormAlert.enmType.Info);
            }
            else
            {
                // bấm next sẽ là trang số ở button3 + 1
                int numPageButton3 = int.Parse(buttonPageUser3.Text);
                if (numPageButton3 < this.TotalPagesUser)
                {
                    if (this.pageUser == 1)
                    {
                        this.pageUser = 3;
                        buttonPageUser1.Text = 2.ToString();
                        buttonPageUser2.Text = 3.ToString();
                        buttonPageUser3.Text = 4.ToString();
                    }
                    else
                    {
                        this.pageUser = numPageButton3 + 1;
                        //set lại button 1,2,3 
                        if (this.pageUser == this.TotalPagesUser)
                        {
                            buttonPageUser1.Text = (this.pageUser - 2).ToString();
                            buttonPageUser2.Text = (this.pageUser - 1).ToString();
                            buttonPageUser3.Text = (this.pageUser).ToString();
                        }
                        if (this.pageUser + 1 <= this.TotalPagesUser)
                        {
                            buttonPageUser1.Text = (this.pageUser - 1).ToString();
                            buttonPageUser2.Text = (this.pageUser).ToString();
                            buttonPageUser3.Text = (this.pageUser + 1).ToString();
                        }
                        if (this.pageGroup + 2 <= this.TotalPagesUser)
                        {
                            buttonPageUser1.Text = (this.pageUser).ToString();
                            buttonPageUser2.Text = (this.pageUser + 1).ToString();
                            buttonPageUser3.Text = (this.pageUser + 2).ToString();
                        }
                    }


                }
                else
                {
                    this.pageUser = this.TotalPagesUser;
                }
                LoadDataGroup();
            }
        }
    }
}
