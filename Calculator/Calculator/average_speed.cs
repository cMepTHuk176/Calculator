using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class average_speed : ContentPage
    {
        public average_speed()
        {
            InitializeComponent();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(S, t);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(S, t))
                Result_Cylinder(null, null);
        }

        private void Result_averageSpeed(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(S, t))
            {
                resultText.Text = Volume_Main.ERROR_TEXT;
                return;
            }

            double valueS = double.Parse(S.Text);
            double valuet = double.Parse(t.Text);

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