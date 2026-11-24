using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadService.DownloadServiceClient client = new DownloadService.DownloadServiceClient();
            DownloadService.File file = client.DownloadDocument();
            System.IO.File.WriteAllBytes(@"D:\wwwroot\" + file.Name, file.Content);
            MessageBox.Show(file.Name + " downloaded");
        }
    }
}
