using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class acceleration_projection : ContentPage
    {
        public acceleration_projection()
        {
            InitializeComponent();
        }
        private async void Mechanic_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(V0x, Vx, t);
        }
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(V0x, Vx, t))
                Result_averageSpeed(null, null);
        }
        private void Result_AccelerationProjection(object sender, EventArgs e)
        {
            double valueV0x = double.Parse(V0x.Text);
            double valueVx = double.Parse(Vx.Text);
            double valuet = double.Parse(t.Text);

            double result = Mechanic.Acceleration_projection(valueV0x, valueVx, valuet);
        }
       
}