using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                int numerator = Convert.ToInt32(txtNumerator.Text);
                int denominator = Convert.ToInt32(txtDenominator.Text);
                CalculatorService.CalculatorServiceClient client =
                    new CalculatorService.CalculatorServiceClient();
                lblResult.Text = client.Divide(numerator, denominator).ToString();
            }
            catch (FaultException faultException)
            {
                lblResult.Text = faultException.Message;
            }
        }
    }
}