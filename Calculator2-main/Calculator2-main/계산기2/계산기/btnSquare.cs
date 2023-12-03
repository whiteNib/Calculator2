using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 계산기
{
    public static class SquareHandler
    {
        public static void HandleSquare(TextBox txtResult, TextBox txtExp)
        {
            double originalValue = double.Parse(txtResult.Text);

            // 제곱을 계산하고 문자열을 형식화
            double squaredValue = originalValue * originalValue;
            string formattedResult = (squaredValue % 1 == 0) ? squaredValue.ToString("N0") : squaredValue.ToString("N");

            // 디스플레이를 업데이트
            txtExp.Text = "sqr(" + Convert.ToString(originalValue) + ")";
            txtResult.Text = formattedResult;
        }
    }
}
