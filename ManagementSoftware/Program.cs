using ManagementSoftware.Models;
using ManagementSoftware.GUI;
using ManagementSoftware.DAL;

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

            Application.Run(new Login());

            if (Common.USERSESSION != null)
            {
                Application.Run(new Main());
            }
        }
    }
}