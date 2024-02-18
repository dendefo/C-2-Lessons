using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        float firstNumber = 0;
        float secondNumber = 0;
        float previousSecNumber = 0;

        bool isSecondNumberClicked = false;
        long firstFloatPart = 0; //This is far too difficult to recreate in a reasonable amount of time :(
        long secondFloatPart = 0;
        bool isFloatPressed = false;
        Func<float, float, float> MathAction = null;
        Func<float, float, float> PreviousMathAction = null;
        public Form1()
        {
            InitializeComponent();
        }

        void AppendToNumber(int number)
        {

            bool sign = firstNumber >= 0;
            if (MathAction == null)
            {
                if (firstNumber * 10 + number * (sign ? 1 : -1) < 0 && firstNumber > 0) return; //Long overflow
                if (firstNumber * 10 + number * (sign ? 1 : -1) > 0 && firstNumber < 0) return; //Long underflow
                if (isFloatPressed) firstFloatPart = firstFloatPart * 10 + number;
                else firstNumber = firstNumber * 10 + number * (sign ? 1 : -1);
            }
            else
            {
                isSecondNumberClicked = true;
                sign = secondNumber >= 0;
                if (isFloatPressed) secondFloatPart = secondFloatPart * 10 + number;
                else secondNumber = secondNumber * 10 + number * (sign ? 1 : -1);
            }
            Print();
        }
        void Print()
        {
            if (MathAction == null)
            {
                if (isFloatPressed)
                {
                    textBox1.Text = firstNumber + "," + firstFloatPart;
                }
                else
                {
                    textBox1.Text = firstNumber.ToString();
                }
            }
            else
            {
                if (isFloatPressed)
                {
                    textBox1.Text = secondNumber + "," + secondFloatPart;
                }
                else
                {
                    textBox1.Text = secondNumber.ToString();
                }
            }
        }

        #region Number Buttons

        private void One_Click(object sender, EventArgs e)
        {
            AppendToNumber(1);
        }

        private void Two_Click(object sender, EventArgs e)
        {
            AppendToNumber(2);
        }

        private void Three_Click(object sender, EventArgs e)
        {
            AppendToNumber(3);
        }

        private void Four_Click(object sender, EventArgs e)
        {
            AppendToNumber(4);
        }

        private void Five_Click(object sender, EventArgs e)
        {
            AppendToNumber(5);
        }

        private void Six_Click(object sender, EventArgs e)
        {
            AppendToNumber(6);
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            AppendToNumber(7);
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            AppendToNumber(8);
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            AppendToNumber(9);
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            AppendToNumber(0);
        }
        #endregion
        #region Math Operations
        private void Float_Click(object sender, EventArgs e)
        {
            isFloatPressed = true;
            Print();
        }

        private void ChangeSign_Click(object sender, EventArgs e)
        {
            if (MathAction == null) firstNumber *= -1;
            else secondNumber *= -1;
            Print();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => a + b;
            Print();
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => a - b;
            Print();
        }

        private void Multiply_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => a * b;
            Print();
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => a / b;
            Print();
        }

        private void Root_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => (float)Math.Sqrt((double)a);
            Calculate();
        }

        private void Square_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => a * a;
            Calculate();
        }

        private void Reverse_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => 1 / a;
            Calculate();
        }

        private void Percent_Click(object sender, EventArgs e)
        {
            MathAction = (a, b) => a * b / 100;
            Print();
        }
        #endregion

        void Calculate()
        {
            isSecondNumberClicked = false;
            PreviousMathAction = MathAction;
            firstNumber = MathAction(firstNumber, secondNumber);
            MathAction = null;
            previousSecNumber = secondNumber;
            secondNumber = 0;
            isFloatPressed = false;
            Print();
        }
        private void Equal_Click(object sender, EventArgs e)
        {
            if (!isSecondNumberClicked) secondNumber = previousSecNumber;
            if (PreviousMathAction == null && MathAction== null) MathAction = (a, b) => a;
            if (MathAction == null) MathAction = PreviousMathAction;
            Calculate();
        }

        private void CleanSecond_Click(object sender, EventArgs e)
        {
            if (MathAction == null) firstNumber = 0;
            else secondNumber = 0;
            Print();
        }

        private void CleanAll_Click(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            MathAction = null;
            isFloatPressed = false;
            Print();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            //Under construction
        }
    }
}
