using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class equidistant_motion_point : ContentPage
    {
        public equidistant_motion_point()
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
            TextCleaner.EntryClean(V0x, x0, t, a);
        }
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(V0x, x0, t, a))
                Result_equidistant_motion_point(null, null);
        }
        private void Result_equidistant_motion_point(object sender, EventArgs e)
        {
            double valueV0x = double.Parse(V0x.Text);
            double valuex0 = double.Parse(x0.Text);
            double valuet = double.Parse(t.Text);
            double valuea = double.Parse(a.Text);

            double result = Mechanic.equidistant_motion_point(valuex0, valueV0x, valuet, valuea);
        }
       
}