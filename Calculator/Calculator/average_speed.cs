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
            if (!TextChecker.EntryCheck(S, t))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }
        }

        private void Result_averageSpeed(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(S, t))
            {
                resultText.Text = mechanic_main.ERROR_TEXT;
                return;
            }

            double valueS = double.Parse(S.Text);
            double valuet = double.Parse(t.Text);

            double result = Mechanic.AverageSpeed(valueS, valuet);
        }

    }
}