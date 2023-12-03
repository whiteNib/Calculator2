using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 계산기
{
    public static class CalculationHandler
    {
        public static void PerformCalculation(TextBox txtResult, TextBox txtExp, double lValue, double rValue, char op)
        {
            switch (op)
            {
                case '+':
                    txtResult.Text = FormatResult(lValue + rValue);
                    break;
                case '-':
                    txtResult.Text = FormatResult(lValue - rValue);
                    break;
                case '*':
                    txtResult.Text = FormatResult(lValue * rValue);
                    break;
                case '/':
                    txtResult.Text = FormatResult(lValue / rValue);
                    break;
            }
            txtExp.Text = "";
        }

        private static string FormatResult(double result)
        {
            return result.ToString("#,##0.###");
        }
    }
}
