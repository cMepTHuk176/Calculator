using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class equidistant_motion : ContentPage
    {
        public average_speed()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(x0, Vx, t);
        }

        private void Result_averageSpeed(object sender, EventArgs e)
        {
            double valueS = double.Parse(x0.Text);
            double valuet = double.Parse(Vx.Text);

            resultText.Text = AverageSpeed(valueS, valuet).ToString();
        }
        private double AverageSpeed(double valueS, double valuet)
        {
            double resultMove;
            resultMove = valueS/valuet;
            return resultMove;
        }
    }
}