using ManagementSoftware.BUS;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.Models;
using ManagementSoftware.ViewModels;

namespace ManagementSoftware.GUI.EmployeeManagement
{
    public partial class FormAddUser : Form
    {
        // Define delegate
        public delegate void ChangeData(string msg, FormAlert.enmType enmType);

        // Create instance (null)
        public ChangeData changeData;

        public FormAddUser()
        {
            InitializeComponent();
            //lấy tất cả tên các quyền cho vào combobox
            comboBoxSelectGroup.DataSource = BUSGroup.GetListGroupName();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string fullname = textBoxFullName.Texts;
            string username = textBoxUsername.Texts.Trim();
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
                    AddUpdateDeleteResponse<User> response = BUSUser.AddUser(user);
                    if (response != null && response.Status == true)
                    {
                        changeData?.Invoke($"Thêm thành công tài khoản {response?.Data?.Username}.", FormAlert.enmType.Success);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Thêm tài khoản {response?.Data?.Username} thất bại, tên tài khoản phải là duy nhất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    changeData?.Invoke("Lỗi!!!", FormAlert.enmType.Error);
                }

            }




        }
    }
}
