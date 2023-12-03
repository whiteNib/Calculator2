using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 계산기
{
    public static class Btn8Handler
    {
        public static void HandleClick(object sender, EventArgs e, TextBox txtResult, bool opFlag, bool memFlag)
        {
            if (txtResult.Text == "0" || opFlag == true || memFlag == true)
            {
                txtResult.Text = "8";
                opFlag = false;
                memFlag = false;
            }
            else
            {
                txtResult.Text += 8;
            }

            double v = Double.Parse(txtResult.Text);

            int pos = 0;
            if (txtResult.Text.Contains("."))
            {
                pos = txtResult.Text.Length - txtResult.Text.IndexOf(".");
                if (pos == 1)
                {
                    return;
                }
                string formatStr = "{0:N" + (pos - 1) + "}";
                txtResult.Text = string.Format(formatStr, v);
            }
            else
            {
                txtResult.Text = string.Format("{0:N0}", v);
            }
        }
    }
}
