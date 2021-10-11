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
            lengthPicker.SelectedIndex = 0;
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

            if (Figure.SphereVolume(valueR) is > 1000 or < 0.01)
                resultText.Text = Figure.SphereVolume(valueR).ToString("0.00E+0") + " "
                    + (LengthPickerState)lengthPicker.SelectedIndex + string.Format("\u00B3");
            else
                resultText.Text = Figure.SphereVolume(valueR).ToString("N3") + " "
                    + (LengthPickerState)lengthPicker.SelectedIndex + string.Format("\u00B3");

        }
    }
}