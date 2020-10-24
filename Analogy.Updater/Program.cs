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
            //Debugger.Launch();
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
            string targetFolder = null;
            if (args.Length == 3)
            {
                title = args[0];
                downloadURL = args[1];
                targetFolder = args[2];
            }
            else
            {
                Application.Exit();
                return;
            }
            KilAnalogyIfNeeded();
            Application.Run(new MainForm(title, downloadURL,targetFolder));
        }

        private static void KilAnalogyIfNeeded()
        {
            var analogies=Process.GetProcessesByName("Analogy");
            foreach (var analogy in analogies)
            {
                try
                {
                    analogy.Kill();
                }
                catch (Exception)
                {
                   //
                }
            }
        }
    }
}
