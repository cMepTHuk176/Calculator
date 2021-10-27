using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Isochoric : ContentPage
    {
        public Isochoric()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(p, t);
        }

        private void Result_Isochoric(object sender, EventArgs e)
        {
            double valuep = double.Parse(p.Text);
            double valuet = double.Parse(t.Text);

            resultText.Text = Calc_Isothermal(valuep, valuet).ToString();
        }
        private double Calc_Isothermal (double valuep, double valuet)
        {
            double resultMove;
            resultMove = valuep/valuet;
            return resultMove;
        }
    }
}