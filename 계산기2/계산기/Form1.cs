using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 계산기
{
    public partial class Form1 : Form
    {
        private double lValue;
        private char op = '\0';
        private bool opFlag = false;
        private double memory;
        private bool memFlag = false;

        public Form1()
        {
            InitializeComponent();

            btnMC.Enabled = false; 
            btnMR.Enabled = false;
            btnMhistory.Enabled = false;
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(243, 243, 243);
            txtResult.Text = "0";
            timer1.Start();
        }
        private void btn0_Click(object sender, EventArgs e)
        {

        }
        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        private void btn4_Click(object sender, EventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

        private void btn6_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {

        }

        private void btn8_Click(object sender, EventArgs e)
        {

        }

        private void btn9_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " + ";
            op = '+';
            opFlag = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " × ";
            op = '*';
            opFlag = true;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " - ";
            op = '-';
            opFlag = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            lValue = Double.Parse(txtResult.Text);
            txtExp.Text = txtResult.Text + " ÷ ";
            op = '/';
            opFlag = true;
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            Double rValue = Double.Parse(txtResult.Text);
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

        private string FormatResult(double result)
        {
            return result.ToString("#,##0.###");
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            txtExp.Text = "";
            lValue = 0;
            op = '\0';
            opFlag = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtResult.Text.Length >=16)
            {
                txtResult.Font = new Font(txtResult.Font.FontFamily, 25,FontStyle.Bold);
            }
            if (txtResult.Text.Length < 16)
            {
                txtResult.Font = new Font(txtResult.Font.FontFamily, 30, FontStyle.Bold);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            txtResult.Text=txtResult.Text.Remove(txtResult.Text.Length-1);
            if (txtResult.Text.Length == 0)
            {
                txtResult.Text = "0";
            }
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(txtResult.Text);
            txtResult.Text = (-v).ToString();
        }
        
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            txtExp.Text = "√(" + txtResult.Text + ")";
            txtResult.Text = Math.Sqrt(Double.Parse(txtResult.Text)).ToString();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            double originalValue = Double.Parse(txtResult.Text);

            // 제곱을 계산하고 문자열을 형식화
            double squaredValue = originalValue * originalValue;
            string formattedResult = (squaredValue % 1 == 0) ? squaredValue.ToString("N0") : squaredValue.ToString("N");

            // 디스플레이를 업데이트
            txtExp.Text = $"sqr({originalValue})";
            txtResult.Text = formattedResult;
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            txtExp.Text = "1/(" + txtResult.Text + ")";
            txtResult.Text = (1/Double.Parse(txtResult.Text)).ToString();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Contains("."))//텍스트에 문자열을 포함하고 있으면
            {
                return;
            }
            else
            {
                txtResult.Text += ".";  
            }
        }
               

        private void btnMS_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(txtResult.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            memFlag = true;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            txtResult.Text = memory.ToString();
            memFlag = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            memory = 0;
            btnMR.Enabled =false;
            btnMC.Enabled =false;
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(txtResult.Text);
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            memory -= Double.Parse(txtResult.Text);
        }

        //모든 숫자버튼을 하나로 처리하는 메소드
        private void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string s = btn.Name.Remove(0, 3); // s = 1,2,3,...,0

            if (txtResult.Text == "0" || opFlag == true || memFlag == true)
            {
                txtResult.Text = s;
                opFlag = false;
                memFlag = false;
            }
            else
            {
                txtResult.Text += s;
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

        private void btnMhistory_Click(object sender, EventArgs e)
        {

        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void btnOptionClose_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
        }
    }
}
