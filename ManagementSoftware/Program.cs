using ManagementSoftware.Models;
using ManagementSoftware.GUI;
using ManagementSoftware.PLCSetting;
using System.Diagnostics;
using ManagementSoftware.GUI.NguonManagement;
using ManagementSoftware.ManageHistoryData;

namespace ManagementSoftware
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            //Syncfusion
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Common.LicenseSyncfusion);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "ConnectStringDB.txt");
            string text = File.ReadAllText(path);
            Common.ConnectionString = text;

            if (new DataBaseContext().CreateDatabase() == false)
            {
                MessageBox.Show("Lỗi khởi tạo cơ sở dữ liệu, hãy thử xem lại đường dẫn kết nối của bạn.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Application.Run(new Login());

            if (Common.USERSESSION != null)
            {
                new SaveToDatabase().ConnectAndRunSaveAll();

                Application.Run(new Main());
            }
        }
    }
}