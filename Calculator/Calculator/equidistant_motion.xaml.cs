using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class equidistant_motion : ContentPage
    {
        public equidistant_motion()
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
            TextCleaner.EntryClean(x0, Vx, t);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(x0, Vx, t))
                Result_Equidistant(null, null);
        }

        private void Result_Equidistant(object sender, EventArgs e)
        {
             if (!TextChecker.EntryCheck(x0, Vx, t))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            double valuex0 = double.Parse(x0.Text);
            double valueVx = double.Parse(Vx.Text);
            double valuet = double.Parse(t.Text);

            double result = Mechanic.EquidistantMotion(valuex0, valueVx, valuet);
        }
        
    }
}