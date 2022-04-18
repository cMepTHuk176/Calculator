using System;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnBack(object sender, EventArgs e)
        {
            History.FirstFormula = this.resultText.Text;
            this.resultText.Text = History.LastFormula; 
        }
        private void OnUp(object sender, EventArgs e)
        {
            History.LastFormula = this.resultText.Text;
            this.resultText.Text = History.FirstFormula;
        }
        private void OnSymbol(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.resultText.Text = Trim.Result(resultText.Text, button.Text, false);
        }
        private void OnExpression(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.resultText.Text += button.Text;
        }
        private void OnNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.resultText.Text = Trim.Result(resultText.Text, button.Text, true);
        }
        private void OnClear(object sender, EventArgs e)
        {
            this.resultText.Text = Trim.Delete(resultText.Text, false);
        }
        private void OnClear1(object sender, EventArgs e)
        {
            this.resultText.Text = Trim.Delete(resultText.Text,true);
        }
        private void OnCalculate(object sender, EventArgs e)
        {
            History.LastFormula = this.resultText.Text;
            this.resultText.Text += " = "+ Calculator.Calculate(resultText.Text);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}