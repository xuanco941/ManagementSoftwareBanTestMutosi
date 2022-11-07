using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSoftware.BUS;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
using ManagementSoftware.ViewModels;

namespace ManagementSoftware.GUI.EmployeeManagement
{
    public partial class FormChangeUser : Form
    {
        // Define delegate
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);

        // Create instance (null)
        public ChangeData changeData;
        public FormChangeUser()
        {
            InitializeComponent();
            comboBoxSelectGroup.DataSource = BUSGroup.GetListGroupName();
            LoadComboBoxUser();
        }
        void LoadComboBoxUser()
        {
            comboBoxSelectUsername.DataSource = BUSUser.GetListUsername();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string username = comboBoxSelectUsername.Text;
            string fullname = textBoxFullName.Texts;
            string password = textBoxPassword.Texts.Trim();
            string groupName = comboBoxSelectGroup.Text;

            if (String.IsNullOrEmpty(fullname) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    User user = new User();
                    Group? gr = BUSGroup.GetGroupFromGroupName(groupName);
                    if (gr != null)
                    {
                        user = new User(fullname, username, password, gr.GroupID);
                    }
                    AddUpdateDeleteResponse<User> response = BUSUser.UpdateUser(user);
                    if (response != null && response.Status == true)
                    {
                        changeData?.Invoke($"Cập nhật thành công tài khoản {response?.Data?.Username}.", FormAlert.enmType.Success);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Cập nhật tài khoản {response?.Data?.Username} thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    changeData?.Invoke(ex.Message, FormAlert.enmType.Error);
                }

            }

            LoadComboBoxUser();
            comboBoxSelectUsername.Text = username;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string username = comboBoxSelectUsername.Text;

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa tài khoản {username}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //Xóa tài khoản, xóa xong sẽ load lại danh sách username của form
                if (username == Common.UserAdmin.Username)
                {
                    MessageBox.Show("Đây là tài khoản mặc định của hệ thống, bạn không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    try
                    {
                        AddUpdateDeleteResponse<string> response = BUSUser.DeleteUser(username);
                        if(response.Status == true)
                        {
                            changeData?.Invoke($"Xóa thành công tài khoản {username}.", FormAlert.enmType.Success);
                        }
                        else
                        {
                            MessageBox.Show($"Xóa tài khoản {username} thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Xóa tài khoản {username} thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                LoadComboBoxUser();
            }
        }

        private void comboBoxSelectUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vô hiệu hóa nút xóa khi đây là tài khoản hiện tại
            if ((Common.USERSESSION != null && comboBoxSelectUsername.Text != Common.USERSESSION.Username))
            {
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonDelete.Enabled = false;
            }
            //neu la tai khoan admin thi khong the xoa, khong the thay doi ten user
            if (comboBoxSelectUsername.Text == Common.UserAdmin.Username && Common.USERSESSION != null && Common.USERSESSION.Username != Common.UserAdmin.Username)
            {
                textBoxFullName.Enabled = false;
                textBoxPassword.PasswordChar = true;
                textBoxPassword.Enabled = false;
                comboBoxSelectGroup.Enabled = false;
                buttonUpdate.Enabled = false;
            }
            else
            {
                textBoxFullName.Enabled = true;
                textBoxPassword.PasswordChar = false;
                textBoxPassword.Enabled = true;
                comboBoxSelectGroup.Enabled = true;
                buttonUpdate.Enabled = true;

                // lấy ra thông tin user có username là username trên combobox
                try
                {
                    User? user = BUSUser.GetUserFromUsername(comboBoxSelectUsername.Text);

                    //show trên textbox

                    textBoxFullName.Texts = user?.FullName;
                    textBoxPassword.Texts = user?.Password;
                    comboBoxSelectGroup.Text = BUSGroup.GetGroupFromID(user.GroupID).GroupName;
                }
                catch
                {
                    changeData?.Invoke($"Không thể lấy thông tin người dùng này.", FormAlert.enmType.Error);
                }
            }

            if (comboBoxSelectUsername.Text == Common.UserAdmin.Username || (Common.USERSESSION != null && comboBoxSelectUsername.Text == Common.USERSESSION.Username))
            {
                buttonDelete.Enabled = false;
                comboBoxSelectGroup.Enabled = false;
            }
            else
            {
                buttonDelete.Enabled = true;
                comboBoxSelectGroup.Enabled = true;
            }
        }
    }
}
