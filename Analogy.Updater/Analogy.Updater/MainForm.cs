using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;

namespace Analogy.Updater
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadInformation updateInfo = new DownloadInformation
            ("", true,
                "https://github.com/Analogy-LogViewer/Analogy.LogViewer/releases/download/V4.2.10/netcoreapp3.1.zip",
                "https://github.com/Analogy-LogViewer/Analogy.LogViewer/releases/tag/V4.2.10",
                new Version(4, 2, 10), new Version(4, 2, 8), false,
                UpdateMode.Normal, "", "", "");
            AutoUpdater.Start(updateInfo);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (AutoUpdater.OpenDownloadPage)
            {
                var processStartInfo = new ProcessStartInfo(AutoUpdater.DownloadURL);

                Process.Start(processStartInfo);

                DialogResult = DialogResult.OK;
            }
            else
            {
                if (AutoUpdater.DownloadUpdate(this))
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
