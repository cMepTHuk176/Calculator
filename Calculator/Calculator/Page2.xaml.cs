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
        FIRST, SECOND, RESULT, ERROR
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

        private void OnRemoveSymbol(object sender, EventArgs e)
        {
            char lastLabelSymbol = displayLabel.Text[displayLabel.Text.Length - 1];

            if (displayLabel.Text.Length <= 1)
                OnClear();

            else if (lastLabelSymbol == '/' || lastLabelSymbol == 'x' || lastLabelSymbol == '-'
                || lastLabelSymbol == '+')
            {
                displayLabel.Text = displayLabel.Text.Remove(displayLabel.Text.Length - 1);
                mathOperator = "";
                isMathOperator = false;
                state = NumberState.FIRST;
            }

            else if (state == NumberState.RESULT)
                OnClear();

            else
                displayLabel.Text = displayLabel.Text.Remove(displayLabel.Text.Length - 1);
        }

        private void OnClear(object sender = null, EventArgs e = null)
        {
            displayLabel.Text = "0";
            isCleared = false;
            state = NumberState.FIRST;
            number1 = 0;
            number2 = 0;
            mathOperator = "";
            isMathOperator = false;
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (isMathOperator && (state == NumberState.SECOND || state == NumberState.RESULT))
            {
                double result = 0;

                switch (mathOperator)
                {
                    case "/":
                        if (number2 == 0)
                            state = NumberState.ERROR;
                        else
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

                if (state == NumberState.ERROR)
                    DisplayAlert("АшыПка! ЭРРор Тревога пuздец", "ти чо дибил делить на 0?", "ок, больше не буду :(");

                else
                {
                    OnClear();
                    displayLabel.Text = "= " + result;
                    number1 = result;
                    state = NumberState.RESULT;
                }
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        { 
            if (state == NumberState.RESULT || (!isMathOperator && state != NumberState.SECOND))
            {
                if (state == NumberState.RESULT)
                {
                    displayLabel.Text = "" + number1.ToString();
                    ActionsAfterOperatorSelect(sender);
                }
                else
                    ActionsAfterOperatorSelect(sender);
                
            }
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            bool zeroState = false;
            string currentPress = ((Button)(sender)).Text;

            if (state == NumberState.ERROR)
                OnClear();

            if ((displayLabel.Text == "0" && currentPress == "0") || (state == NumberState.RESULT && currentPress == "0"))
                zeroState = true;

            if (state == NumberState.RESULT)
                OnClear();

            if (!zeroState)
            {
                if (!isCleared)
                {
                    if (state != NumberState.SECOND && state != NumberState.RESULT)
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
                double.TryParse(test, out number2);
            }
            else
            {
                state = NumberState.SECOND;
                double.TryParse(displayLabel.Text.Substring(number1.ToString().Length + 1), out number2);
            }
             
        }
        
        private void ActionsAfterOperatorSelect(object sender)
        {
            displayLabel.Text += ((Button)(sender)).Text;
            mathOperator = ((Button)(sender)).Text;
            isMathOperator = true;
            state = NumberState.SECOND;
        }

    }
}