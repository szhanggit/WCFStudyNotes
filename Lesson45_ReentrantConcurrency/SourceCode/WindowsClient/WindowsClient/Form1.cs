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

namespace WindowsClient
{
    // The Form1 class implements IReportServiceCallback interface
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class Form1 : Form, ReportService.IReportServiceCallback
    {
        public Form1()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnProcessReport_Click(object sender, EventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            ReportService.ReportServiceClient client = new ReportService.ReportServiceClient(instanceContext);

            client.ProcessReport();
        }

        // This method recevies the progress update from the WCF service
        // Report processing percentage is displayed in the textbox control
        public void Progress(int percentageComplete)
        {
            textBox1.Text = percentageComplete.ToString() + " % completed";
        }
    }
}
