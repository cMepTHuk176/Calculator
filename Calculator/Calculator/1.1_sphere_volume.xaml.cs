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
    public partial class sphere_volume : ContentPage
    {
        public sphere_volume()
        {
            InitializeComponent();
        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryText_R);
        }
        
        private void Result_Sphere(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryText_R))
            {
                resultText.Text = Volume_Main.ERROR_TEXT;
                return;
            }

            double valueR = double.Parse(entryText_R.Text);
            resultText.Text = Figure.SphereVolume(valueR).ToString();

            //if (double.TryParse(entryText_R.Text, out double result))
            //    resultText.Text = Figure.SphereVolume(result).ToString();
            //else
            //    resultText.Text = Volume_Main.ERROR_TEXT;
        }
    }
}