using ManagementSoftware.GUI.Section;
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
    public partial class CaiDat : Form

    {        // Aleart Delegate từ FormMain
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        public CaiDat()
        {
            InitializeComponent();
        }


        void LoadDBBauNong()
        {
            using (var context = new Models.DataBaseContext())
            {
                labelBauNong.Text = context.TestBauNongs.Count().ToString() + " bản ghi.";
            }

        }
        void LoadDBLoiLoc()
        {
            using (var context = new Models.DataBaseContext())
            {
                labelLoiLoc.Text = context.LoiLocs.Count().ToString() + " bản ghi.";
            }

        }
        void LoadDBNguon()
        {
            using (var context = new Models.DataBaseContext())
            {
                labelNguon.Text = context.TestNguons.Count().ToString() + " bản ghi.";
            }

        }
        void LoadDBCongTac()
        {
            using (var context = new Models.DataBaseContext())
            {
                labelCongTac.Text = context.TestBauNongs.Count().ToString() + " bản ghi.";
            }

        }
        void LoadDBMach()
        {
            using (var context = new Models.DataBaseContext())
            {
                labelMach.Text = context.TestJigMachs.Count().ToString() + " bản ghi.";
            }

        }
        void LoadDBBepTu()
        {
            using (var context = new Models.DataBaseContext())
            {
                labelBepTu.Text = context.TestBepTus.Count().ToString() + " bản ghi.";
            }

        }
        private void CaiDat_Load(object sender, EventArgs e)
        {
            LoadDBBauNong();
            LoadDBBepTu();
            LoadDBCongTac();
            LoadDBLoiLoc();
            LoadDBMach();
            LoadDBNguon();
        }
        private void buttonBepTu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new Models.DataBaseContext())
                {
                    try
                    {
                        context.TestBepTus.RemoveRange(context.TestBepTus);
                        int x = context.SaveChanges();

                        callAlert.Invoke("Đã xóa " + x + " bản ghi", FormAlert.enmType.Success);
                        LoadDBBepTu();
                    }
                    catch
                    {
                        callAlert.Invoke("Có lỗi xảy ra khi xóa, bạn có thể xóa Database ở ổ cứng rồi khởi động lại ứng dụng.", FormAlert.enmType.Warning);
                    }

                }
            }

        }

        private void buttonLoiLoc_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new Models.DataBaseContext())
                {
                    try
                    {
                        context.LoiLocs.RemoveRange(context.LoiLocs);
                        int x = context.SaveChanges();

                        callAlert.Invoke("Đã xóa " + x + " bản ghi", FormAlert.enmType.Success);
                        LoadDBLoiLoc();
                    }
                    catch
                    {
                        callAlert.Invoke("Có lỗi xảy ra khi xóa, bạn có thể xóa Database ở ổ cứng rồi khởi động lại ứng dụng.", FormAlert.enmType.Warning);
                    }

                }
            }
        }

        private void buttonCongTac_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new Models.DataBaseContext())
                {
                    try
                    {
                        context.TestCongTacs.RemoveRange(context.TestCongTacs);
                        int x = context.SaveChanges();

                        callAlert.Invoke("Đã xóa " + x + " bản ghi", FormAlert.enmType.Success);
                        LoadDBCongTac();
                    }
                    catch
                    {
                        callAlert.Invoke("Có lỗi xảy ra khi xóa, bạn có thể xóa Database ở ổ cứng rồi khởi động lại ứng dụng.", FormAlert.enmType.Warning);
                    }

                }
            }
        }

        private void buttonMach_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new Models.DataBaseContext())
                {
                    try
                    {
                        context.TestJigMachs.RemoveRange(context.TestJigMachs);
                        int x = context.SaveChanges();

                        callAlert.Invoke("Đã xóa " + x + " bản ghi", FormAlert.enmType.Success);
                        LoadDBMach();
                    }
                    catch
                    {
                        callAlert.Invoke("Có lỗi xảy ra khi xóa, bạn có thể xóa Database ở ổ cứng rồi khởi động lại ứng dụng.", FormAlert.enmType.Warning);
                    }

                }
            }
        }

        private void buttonBauNong_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new Models.DataBaseContext())
                {
                    try
                    {
                        context.TestBauNongs.RemoveRange(context.TestBauNongs);
                        int x = context.SaveChanges();

                        callAlert.Invoke("Đã xóa " + x + " bản ghi", FormAlert.enmType.Success);
                        LoadDBBauNong();
                    }
                    catch
                    {
                        callAlert.Invoke("Có lỗi xảy ra khi xóa, bạn có thể xóa Database ở ổ cứng rồi khởi động lại ứng dụng.", FormAlert.enmType.Warning);
                    }

                }
            }
        }

        private void buttonNguon_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new Models.DataBaseContext())
                {
                    try
                    {
                        context.TestNguons.RemoveRange(context.TestNguons);
                        context.TestLeds.RemoveRange(context.TestLeds);

                        int x = context.SaveChanges();

                        callAlert.Invoke("Đã xóa " + x + " bản ghi", FormAlert.enmType.Success);
                        LoadDBNguon();
                    }
                    catch
                    {
                        callAlert.Invoke("Có lỗi xảy ra khi xóa, bạn có thể xóa Database ở ổ cứng rồi khởi động lại ứng dụng.", FormAlert.enmType.Warning);
                    }

                }
            }
        }
    }
}
