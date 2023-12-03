using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 계산기
{
    public static class SqrtHandler
    {
        public static void HandleSqrt(TextBox txtResult, TextBox txtExp)
        {
            txtExp.Text = "√(" + txtResult.Text + ")";
            txtResult.Text = Math.Sqrt(Double.Parse(txtResult.Text)).ToString();
        }
    }
}
