using ManagementSoftware.BUS;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
using ManagementSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.EmployeeManagement
{
    public partial class FormChangeGroup : Form
    {
        // tạo 1 delegate có 2 biến để call alert ở main
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);
        // Create instance (null)
        public ChangeData changeData;
        public FormChangeGroup()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            //lấy tất cả tên các quyền cho vào combobox
            comboBoxSelectGroup.DataSource = BUSGroup.GetListGroupName();
        }

        private void comboBoxSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //vô hiệu hóa nút xóa khi đây là quyền admin mặc định
            if (comboBoxSelectGroup.Text != Common.GroupAdmin.GroupName)
            {
                buttonUpdateGroup.Enabled = true;
                buttonDeleteGroup.Enabled = true;
            }
            else
            {
                buttonUpdateGroup.Enabled = false;
                buttonDeleteGroup.Enabled = false;
            }

            // lấy ra thông tin group có name group là text trên combobox
            try
            {
                Group? group = BUSGroup.GetGroupFromGroupName(comboBoxSelectGroup.Text);
                if(group!= null)
                {
                    checkBoxIsManagementUser.Checked = group.IsManagementUser;
                    checkBoxIsManagementGroup.Checked = group.IsManagementGroup;
                    //checkBoxIsControlMachine.Checked = group.IsControlMachine;
                    //checkBoxIsSettingMachine.Checked = group.IsSettingMachine;
                    //checkBoxIsSettingShift.Checked = group.IsSettingShift;
                    //checkBoxIsSettingTemplateMachine.Checked = group.IsSettingTemplateMachine;
                    //checkBoxIsViewResult.Checked = group.IsViewResult;
                    //checkBoxIsViewActivity.Checked = group.IsViewActivity;
                    //checkBoxIsDeleteResult.Checked = group.IsDeleteResult;
                    //checkBoxIsDeleteActivity.Checked = group.IsDeleteActivity;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy nhóm quyền này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show($"Tìm kiếm nhóm quyền gặp lỗi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void buttonUpdateGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            group.GroupName = comboBoxSelectGroup.Text;
            group.IsManagementUser = checkBoxIsManagementUser.Checked;
            group.IsManagementGroup = checkBoxIsManagementGroup.Checked;

            if (String.IsNullOrEmpty(comboBoxSelectGroup.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    AddUpdateDeleteResponse<Group> response = BUSGroup.UpdateGroup(group);
                    //nếu group là group của user current thì thay đổi groupsession
                    if (response.Status == true)
                    {
                        changeData?.Invoke("Cập nhật thành công.", FormAlert.enmType.Success);
                    }
                    else
                    {
                        changeData?.Invoke("Cập nhật không thành công.", FormAlert.enmType.Success);
                    }
                }
                catch (Exception ex)
                {
                    changeData?.Invoke(ex.Message, FormAlert.enmType.Error);
                }

            }

            LoadComboBox();
            comboBoxSelectGroup.Text = group.GroupName;
        }

        private void buttonDeleteGroup_Click(object sender, EventArgs e)
        {
            string nameGroup = comboBoxSelectGroup.Text;

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa nhóm quyền {nameGroup}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show($"Xác nhận xóa đồng nghĩa với việc xóa mọi tài khoản trong nhóm quyền này.", "Cảnh báo quan trọng", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dialogResult2 == DialogResult.Yes)
                {
                    //Xóa nhóm quyền, xóa xong sẽ load lại danh sách group của form
                    try
                    {
                        Group? grDelete = BUSGroup.GetGroupFromGroupName(nameGroup);
                        if(grDelete != null)
                        {
                            //nếu quyền bị xóa là quyền hiện tại của hệ thống thì báo lỗi
                            if (Common.USERSESSION != null && (grDelete.GroupID == Common.USERSESSION.GroupID))
                            {
                                changeData?.Invoke($"Xóa không thành công, nhóm quyền {nameGroup} là nhóm quyền tài khoản của bạn.", FormAlert.enmType.Error);
                            }
                            else
                            {
                                AddUpdateDeleteResponse<string> respone = BUSGroup.DeleteGroup(nameGroup);
                                if(respone.Status == true)
                                {
                                    changeData?.Invoke($"Xóa thành công nhóm quyền {nameGroup}.", FormAlert.enmType.Success);
                                }
                                else
                                {
                                    changeData?.Invoke($"Xóa nhóm quyền {nameGroup} không thành công.", FormAlert.enmType.Error);
                                }
                            }
                        }

                    }
                    catch
                    {
                        changeData?.Invoke($"Gặp lỗi, xóa thất bại.", FormAlert.enmType.Error);
                    }
                    LoadComboBox();
                }

            }
        }
    }
}
