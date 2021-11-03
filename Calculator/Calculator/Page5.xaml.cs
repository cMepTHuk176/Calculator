using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
        public Page5()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(ValueA, ValueB);
        }

        private void Result_Move(object sender, EventArgs e)
        {
            double ValueA = double.Parse(ValueA.Text);
            double ValueB = double.Parse(ValueB.Text);

            resultText.Text = Square_difference_m(ValuexA, ValueB).ToString();
        }
        private double Square_difference_m(double ValueA, double ValueB)
        {
            double resultMove;
            resultMove = (ValueA + ValueB) * (ValueA - ValueB);
            return resultMove;
        }
    }
}