using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Analogy.Updater
{
    public partial class MainForm : Form
    {
        private string Title { get; }
        private string DownloadURL { get; }
        private string TargetFolder { get; }
        private bool ForceOverrideFiles { get; }
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string title, string downloadURL,string targetFolder,bool forceOverrideFiles) : this()
        {
            Title = title;
            DownloadURL = downloadURL;
            TargetFolder = targetFolder;
            ForceOverrideFiles = forceOverrideFiles;
            if (!Directory.Exists(TargetFolder))
            {
                Directory.CreateDirectory(TargetFolder);
            }
        }
  
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DownloadURL != null)
            {
                lblTitleValue.Text = Title;
                AutoUpdater.DownloadURL=DownloadURL;
                AutoUpdater.DownloadPath = TargetFolder;
                AutoUpdater.ForceOverrideFiles = ForceOverrideFiles;
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

        private void btnStartAnalogy_Click(object sender, EventArgs e)
        {
            string filename = "Analogy.EXE";
            if (File.Exists(filename))
            {
                Process.Start(filename);
                Application.Exit();
            }
        }
    }
}
