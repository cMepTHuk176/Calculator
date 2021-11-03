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

            resultText.Text = Square_difference_m(ValueA, ValueB).ToString();
            resultText.Text = Сube_difference_m(ValueA, ValueB).ToString();
            resultText.Text = Cube_sum_m(ValueA, ValueB).ToString();
        }
        private double Square_difference_m(double ValueA, double ValueB)
        {
            double resultMove;
            resultMove = (ValueA + ValueB) * (ValueA - ValueB);
            return resultMove;
        }
        private double Сube_difference_m(double ValueA, double ValueB)
        {
            double resultMove1;
            resultMove1 = (ValueA - ValueB) * (ValueA * ValueA + ValueA * ValueB + ValueB * ValueB);
            return resultMove1;
        }
        private double Cube_sum_m(double ValueA, double ValueB)
        {
            double resultMove2;
            resultMove2 = (ValueA + ValueB) * (ValueA * ValueA - ValueA * ValueB + ValueB * ValueB);
            return resultMove2;
        }

    }
}