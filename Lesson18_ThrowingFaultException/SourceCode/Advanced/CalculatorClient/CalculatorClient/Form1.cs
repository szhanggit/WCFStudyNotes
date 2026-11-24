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

namespace CalculatorClient
{
    public partial class Form1 : Form
    {
        CalculatorService.CalculatorServiceClient client = null;

        public Form1()
        {
            InitializeComponent();
            client = new CalculatorService.CalculatorServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int numerator = Convert.ToInt32(textBox1.Text);
                int denominator = Convert.ToInt32(textBox2.Text);

                lblOutput.Text = client.Divide(numerator, denominator).ToString();
            }
            catch (FaultException<CalculatorService.EvSystemException> faultException)
            {
                var invalidOperationException = new InvalidOperationException(faultException.Detail.Message);
                //lblOutput.Text = faultException.Code.Name + " - " + faultException.Message;
                lblOutput.Text = invalidOperationException.Source + " - " + invalidOperationException.Message;
                client.Abort();
            }
            catch (Exception ex)
            {
                client.Abort();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client = new CalculatorService.CalculatorServiceClient();
            MessageBox.Show("A new instance of the proxy class is created");
        }
    }
}
