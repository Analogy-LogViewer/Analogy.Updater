using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Windows.Forms;

namespace Analogy.Updater
{
    public partial class MainForm : Form
    {
        private string Title { get; }
        private string DownloadURL { get; }
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string title, string downloadURL) : this()
        {
            Title = title;
            DownloadURL = downloadURL;

        }
  
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (DownloadURL != null)
            {
                lblTitleValue.Text = Title;
                AutoUpdater.DownloadURL=DownloadURL;
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
