using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    enum NumberState
    {
        FIRST, SECOND, RESULT
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private static NumberState state = NumberState.FIRST;
        private static bool isMathOperator = false;
        private static bool isCleared = false;
        private double number1, number2;
        private string mathOperator;
        
        public Page2()
        {
            InitializeComponent();
        }

        private void OnClear(object sender = null, EventArgs e = null)
        {
            displayLabel.Text = "0";
            isMathOperator = false;
            state = NumberState.FIRST;
            isCleared = false;
            number1 = 0;
            number2 = 0;
            mathOperator = "";
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (isMathOperator && (state == NumberState.SECOND || state == NumberState.RESULT))
            {
                double result = 0;

                switch (mathOperator)
                {
                    case "/":
                        result = (number1 / number2);
                        break;

                    case "x":
                        result = (number1 * number2);
                        break;

                    case "+":
                        result = (number1 + number2);
                        break;

                    case "-":
                        result = (number1 - number2);
                        break;
                }

                OnClear();
                displayLabel.Text = "= " + result;
                number1 = result;
                state = NumberState.RESULT;
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        { 
            if (state == NumberState.RESULT || (!isMathOperator && state != NumberState.SECOND))
            {
                displayLabel.Text += ((Button)(sender)).Text;
                mathOperator = ((Button)(sender)).Text;
                isMathOperator = true;
            }
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            bool zeroState = false;
            string currentPress = ((Button)(sender)).Text;

            if (displayLabel.Text == "0" && currentPress == "0")
                zeroState = true;

            if (!zeroState)
            {
                if (!isCleared)
                {
                    if (state != NumberState.RESULT)
                    {
                        displayLabel.Text = "";
                        displayLabel.Text += currentPress;
                        isCleared = true;
                    }
                    else
                        displayLabel.Text += currentPress;
                }
                else 
                    displayLabel.Text += currentPress;
            }

            if (state == NumberState.FIRST && !isMathOperator)
               double.TryParse(displayLabel.Text, out number1);

            else if (state == NumberState.RESULT)
            {
                string test = displayLabel.Text.Substring(number1.ToString().Length + 3);
                double.TryParse(test, out number2) ;
            }
            else
            {
                state = NumberState.SECOND;
                double.TryParse(displayLabel.Text.Substring(number1.ToString().Length + 1), out number2);
            }
             
        }
        
    }
}