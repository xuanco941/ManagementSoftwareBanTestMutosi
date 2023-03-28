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
        [STAThread]
        static void Main()
        {
            // Add an event handler for the ThreadException event.
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

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

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Handle the exception here...
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Handle the exception here...
        }
    }
}