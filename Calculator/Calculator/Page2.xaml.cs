using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private static bool isCleared = false;
        private double number1, number2;
        private string mathOperator;


        public Page2()
        {
            InitializeComponent();
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {

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


            
            
            
            
        }
        
    }
}