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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.EmployeeManagement
{
    public partial class FormAddGroup : Form
    {
        public FormAddGroup()
        {

            InitializeComponent();
        }
        // Define delegate
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);

        // Create instance (null)
        public ChangeData changeData;


        //validate checkbox
        private void checkBoxIsViewResult_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsViewResult.Checked == false)
            {
                checkBoxIsDeleteResult.Checked = false;
            }
        }

        private void checkBoxIsViewActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsViewActivity.Checked == false)
            {
                checkBoxIsDeleteActivity.Checked = false;
            }
        }

        private void checkBoxIsDeleteResult_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsDeleteResult.Checked == true)
            {
                checkBoxIsViewResult.Checked = true;
            }
        }

        private void checkBoxIsDeleteActivity_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsDeleteActivity.Checked == true)
            {
                checkBoxIsViewActivity.Checked = true;
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            string nameGroup = textBoxNameGroup.Texts;

            if (String.IsNullOrEmpty(nameGroup) || nameGroup == textBoxNameGroup.PlaceholderText)
            {
                MessageBox.Show("Vui lòng điền tên nhóm quyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    Group group = new Group();
                    group.GroupName = nameGroup;
                    group.IsManagementUser = checkBoxIsManagementUser.Checked;
                    group.IsManagementGroup = checkBoxIsManagementGroup.Checked;
                    //group.IsControlMachine = checkBoxIsControlMachine.Checked;
                    //group.IsSettingMachine = checkBoxIsSettingMachine.Checked;
                    //group.IsSettingShift = checkBoxIsSettingShift.Checked;
                    //group.IsSettingTemplateMachine = checkBoxIsSettingTemplateMachine.Checked;
                    //group.IsViewResult = checkBoxIsViewResult.Checked;
                    //group.IsViewActivity = checkBoxIsViewActivity.Checked;
                    //group.IsDeleteResult = checkBoxIsDeleteResult.Checked;
                    //group.IsDeleteActivity = checkBoxIsDeleteActivity.Checked;
                    AddUpdateDeleteResponse<Group> response = BUSGroup.AddGroup(group);
                    if(response!=null && response.Status == true)
                    {
                        changeData?.Invoke($"Thêm thành công quyền {group.GroupName}.", FormAlert.enmType.Success);
                    }
                    else
                    {
                        changeData?.Invoke($"Thêm thất bại, tên nhóm quyền phải là duy nhất.", FormAlert.enmType.Error);
                    }
                    this.Close();
                }
                catch
                {
                    changeData?.Invoke("Thêm thất bại, tên nhóm quyền phải là duy nhất.", FormAlert.enmType.Error);
                }

            }
        }
    }
}
