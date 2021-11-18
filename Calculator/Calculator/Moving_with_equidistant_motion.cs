using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Moving_with_equidistant_motion : ContentPage
    {
        public Moving_with_equidistant_motion()
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
            TextCleaner.EntryClean(V0x, t, a);
        }
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(V0x, t, a))
                Result_Moving_with_equidistant_motion(null, null);
        }
        private void Result_Moving_with_equidistant_motion(object sender, EventArgs e)
        {
            double valueV0x = double.Parse(V0x.Text);
            double valuet = double.Parse(t.Text);
            double valuea = double.Parse(a.Text);

            double result = Mechanic.Moving_with_equidistant_motion(valueV0x, valuet, valuea);
        }
       
}