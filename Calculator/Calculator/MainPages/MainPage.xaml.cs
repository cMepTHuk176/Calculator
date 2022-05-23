using System;
using Xamarin.Forms;
using Calculator.CalcMain;

namespace Calculator.MainPages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        bool Ans = true;
        private void OnBack(object sender, EventArgs e)
        {
            History.FirstFormula = this.resultText.Text;
            this.resultText.Text = History.LastFormula;
            Ans = true;
        }
        private void OnUp(object sender, EventArgs e)
        {
            History.LastFormula = this.resultText.Text;
            this.resultText.Text = History.FirstFormula;
            Ans = true;
        }
        private void OnSymbol(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.resultText.Text = Trim.Result(resultText.Text, button.Text, false);
            Ans = true;
        }
        private void OnExpression(object sender, EventArgs e)
        {
            if(this.resultText.Text == "0")
            {
                this.resultText.Text = "";
            }
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
            Ans = true;
        }
        private void OnClear1(object sender, EventArgs e)
        {
            this.resultText.Text = Trim.Delete(resultText.Text,true);
            Ans = true;
        }
        private void OnCalculate(object sender, EventArgs e)
        {
            History.LastFormula = this.resultText.Text;
            if (Ans)
            {
                this.resultText.Text += " = " + Calculator1.Calculate(resultText.Text);
                Ans = false;
            }
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}