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

            resultLengthPicker.Items.Add("м\u00B3");
            resultLengthPicker.Items.Add("дм\u00B3");
            resultLengthPicker.Items.Add("см\u00B3");
            resultLengthPicker.Items.Add("мм\u00B3");

            resultLengthPicker.SelectedIndex = 0;
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

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryText_R))
                Result_Sphere(null, null);
        }

        private void Result_Sphere(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryText_R))
            {
                resultText.Text = Volume_Main.ErrorText;
                return;
            }

            double valueR = Converter.ConvertToLength(resultLengthPicker, lengthPicker) *
                double.Parse(entryText_R.Text);

            double result = Figure.SphereVolume(valueR);

            if (result is >= 1000 or < 0.01)
                resultText.Text = result.ToString("0.00E+0") + " "
                    + (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
            else
                resultText.Text = result.ToString("N3") + " "
                    + (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");

        }
    }
}