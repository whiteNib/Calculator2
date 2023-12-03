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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 계산기
{
    public partial class Form1 : Form
    {
        public double lValue;
        public char op = '\0';
        public bool opFlag = false;
        public double memory;
        public bool memFlag = false;

        public Form1()
        {

            this.KeyPreview = true;  // 폼이 키보드 입력을 받을 수 있도록 설정
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
            Btn0Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            Btn1Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Btn2Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Btn3Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Btn4Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Btn5Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Btn6Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Btn7Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        public void btn8_Click(object sender, EventArgs e)
        {
            Btn8Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Btn9Handler.HandleClick(sender, e, txtResult, opFlag, memFlag);
            opFlag = false;
            memFlag = false;
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
            double rValue = double.Parse(txtResult.Text);
            CalculationHandler.PerformCalculation(txtResult, txtExp, lValue, rValue, op);
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
            SqrtHandler.HandleSqrt(txtResult, txtExp);
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            SquareHandler.HandleSquare(txtResult, txtExp);
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnResult_Click(sender, e);
                    break;
                case Keys.NumPad0:
                    btn0_Click(sender, e);
                    break;
                case Keys.NumPad1:
                    btn1_Click(sender, e);
                    break;
                case Keys.NumPad2:
                    btn2_Click(sender, e);
                    break;
                case Keys.NumPad3:
                    btn3_Click(sender, e);
                    break;
                case Keys.NumPad4:
                    btn4_Click(sender, e);
                    break;
                case Keys.NumPad5:
                    btn5_Click(sender, e);
                    break;
                case Keys.NumPad6:
                    btn6_Click(sender, e);
                    break;
                case Keys.NumPad7:
                    btn7_Click(sender, e);
                    break;
                case Keys.NumPad8:
                    btn8_Click(sender, e);
                    break;
                case Keys.NumPad9:
                    btn9_Click(sender, e);
                    break;
                case Keys.D0:
                    btn0_Click(sender, e);
                    break;
                case Keys.D1:
                    btn1_Click(sender, e);
                    break;
                case Keys.D2:
                    btn2_Click(sender, e);
                    break;
                case Keys.D3:
                    btn3_Click(sender, e);
                    break;
                case Keys.D4:
                    btn4_Click(sender, e);
                    break;
                case Keys.D5:
                    btn5_Click(sender, e);
                    break;
                case Keys.D6:
                    btn6_Click(sender, e);
                    break;
                case Keys.D7:
                    btn7_Click(sender, e);
                    break;
                case Keys.D8:
                    btn8_Click(sender, e);
                    break;
                case Keys.D9:
                    btn9_Click(sender, e);
                    break;
                
            }
        }
    }
}
