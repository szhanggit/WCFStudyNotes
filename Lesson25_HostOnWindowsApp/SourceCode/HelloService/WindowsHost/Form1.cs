using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsHost
{
    public partial class Form1 : Form
    {
        private ServiceHost host;
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            host = new ServiceHost(typeof(HelloService.HelloService));
            host.Open();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblMessage.Text = "Service Started";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            close();
            lblMessage.Text = "Service Stopped";
        }

        private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            close();
        }

        private void close()
        {
            host.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
