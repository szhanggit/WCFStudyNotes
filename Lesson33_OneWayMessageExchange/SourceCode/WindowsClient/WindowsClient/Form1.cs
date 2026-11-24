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
        SampleService.SampleServiceClient client;

        public Form1()
        {
            InitializeComponent();
            client = new SampleService.SampleServiceClient();
        }

        private void btnOneWayOperation_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add("OneWay Operation Started @ " + DateTime.Now.ToString());
                btnOneWayOperation.Enabled = false;
                client.OneWayOperation();
                btnOneWayOperation.Enabled = true;
                listBox1.Items.Add("OneWay Operation Completed @ " + DateTime.Now.ToString());
                listBox1.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOneWayOperation_ThrowsException_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Add("OneWay Throws Exception Operation Started @ " + DateTime.Now.ToString());
                client.OneWayOperation_ThrowsException();
                listBox1.Items.Add("OneWay Throws Exception Operation Completed @ " + DateTime.Now.ToString());
                listBox1.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
