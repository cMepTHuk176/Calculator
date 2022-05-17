using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Algebra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoubleCalc : ContentPage
    {
        public DoubleCalc()
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
            resultA.Text = "X₁ = ";
            resultB.Text = "X = ";
            resultD.Text = "D = ";
            Ans = true;
        }
        private void OnClear1(object sender, EventArgs e)
        {
            this.resultText.Text = Trim.Delete(resultText.Text, true);
            Ans = true;
        }
        private void OnCalculate(object sender, EventArgs e)
        {
            History.LastFormula = this.resultText.Text;
            if (Ans)
            {
                if (this.resultText.Text.IndexOf('x') != -1)
                {
                    double a, b, c;
                    (a, b, c) = CalcMain.DoubleCalculator.DoubleCalculate(resultText.Text);
                    this.resultA.Text += a.ToString();
                    this.resultB.Text += b.ToString();
                    this.resultD.Text += c.ToString();
                    this.resultText.Text += " = " + 0;
                }
                else
                {
                    this.resultText.Text += " = " + CalcMain.DoubleCalculator.Calculate(resultText.Text);
                }

              Ans = false;
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}