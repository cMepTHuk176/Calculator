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
        FIRST, SECOND
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

        private void OnSelectOperator(object sender, EventArgs e)
        {
            if (!isMathOperator && state != NumberState.SECOND)
            {
                displayLabel.Text += ((Button)(sender)).Text; // ??
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
                    displayLabel.Text = "";
                    displayLabel.Text += currentPress;
                    isCleared = true;
                }
                else 
                    displayLabel.Text += currentPress;
            }

            if (state == NumberState.FIRST && !isMathOperator)
            {
                number1 = double.Parse(displayLabel.Text);
            }
            else
            {
                state = NumberState.SECOND;
                double.TryParse(number1.ToString().Skip(number1.ToString().Length + 1).ToString(), out number2);
            }
            
            
            
            
        }
        
    }
}