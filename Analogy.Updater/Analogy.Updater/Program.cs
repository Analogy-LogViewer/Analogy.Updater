using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Analogy.Updater
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Debugger.Launch();
#if NETCOREAPP
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            AutoUpdater.DownloadPath = directory;
            string title = null;
            string downloadURL = null;
            if (args.Length == 2)
            {
                title = args[0];
                downloadURL = args[1];
            }
            else
            {
                title = "test";
                downloadURL = "https://github.com/LiorBanai/HDF5-CSharp/releases/download/V1.11.0/V1.11.0.zip";
            }
            Application.Run(new MainForm(title, downloadURL));
        }
    }
}
