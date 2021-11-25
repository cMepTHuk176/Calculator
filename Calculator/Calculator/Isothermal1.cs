using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Isothermal1 : ContentPage
    {
        public Isothermal1()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(p, v);
        }

        private void Result_Isothermal(object sender, EventArgs e)
        {
            double valuep = double.Parse(p.Text);
            double valuev = double.Parse(v.Text);

            resultText.Text = Calc_Isothermal(valuep, valuev).ToString();
        }
        private double Calc_Isothermal (double valuep, double valuev)
        {
            double resultMove;
            resultMove = valuep*valuev;
            return resultMove;
        }
    }
}