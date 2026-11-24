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
        SimpleService.SimpleServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SimpleService.SimpleServiceClient();
        }

        private void btnInvokeService_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number = " + client.IncrementNumber().ToString()); 
        }
    }
}
