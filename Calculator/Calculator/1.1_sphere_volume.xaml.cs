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
            entryText_R.Text = default;
        }
        
        private void Result_Sphere(object sender, EventArgs e)
        {
            double result = 0;

            if (double.TryParse(entryText_R.Text, out result))
                resultText.Text = Sphere.Volume(result).ToString();
            else
                resultText.Text = Volume_Main.ERROR;
        }
    }
}