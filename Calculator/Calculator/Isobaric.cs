using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Isobaric : ContentPage
    {
        public Isobaric()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(t, v);
        }

        private void Result_Isobaric(object sender, EventArgs e)
        {
            double valuep = double.Parse(t.Text);
            double valuev = double.Parse(v.Text);

            resultText.Text = Calc_Isobaric(valuet, valuev).ToString();
        }
        private double Calc_Isobaric (double valuet, double valuev)
        {
            double resultMove;
            resultMove = valuev/valuet;
            return resultMove;
        }
    }
}