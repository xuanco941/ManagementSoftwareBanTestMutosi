using ManagementSoftware.BUS;
using ManagementSoftware.Models;
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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            this.ActiveControl = textBoxTaiKhoan;
        }

        private void LoginActive()
        {

            //init db
            new DataBaseContext().CreateDatabase();



            string Username = textBoxTaiKhoan.Texts.Trim();
            string Password = textBoxMatKhau.Texts.Trim();
            if (String.IsNullOrEmpty(Username) == true && String.IsNullOrEmpty(Password) == true)
            {
                MessageBox.Show("Không để trống ô tài khoản và mật khẩu.", "Lỗi Cú Pháp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Lưu quyền và thông tin của user vào 2 biến USERSESSION và GROUPSESSION
                    if (BUSUser.AuthLogin(Username, Password) == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            LoginActive();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginActive();
            }
        }
    }
}
