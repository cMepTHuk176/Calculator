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
    public partial class cone_volume : ContentPage
    {
        public cone_volume()
        {
            InitializeComponent();

            resultLengthPicker.Items.Add("м\u00B3");
            resultLengthPicker.Items.Add("дм\u00B3");
            resultLengthPicker.Items.Add("см\u00B3");
            resultLengthPicker.Items.Add("мм\u00B3");

            resultLengthPicker.SelectedIndex = 0;
            lengthPickerR.SelectedIndex = 0;
            lengthPickerH.SelectedIndex = 0;
        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entry_R, entry_H);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry_R, entry_H))
                Result_Cone(null, null);
        }

        private void Result_Cone(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entry_R, entry_H))
            {
                resultText.Text = Volume_Main.ERROR_TEXT;
                return;
            }

            double valueR = double.Parse(entry_R.Text);
            double valueH = double.Parse(entry_H.Text);

            double result = Converter.ConvertToLength(resultLengthPicker, lengthPickerR, lengthPickerH)
                * Figure.ConeVolume(valueR, valueH);

            if (result is > 1000 or < 0.01)
                resultText.Text = result.ToString("0.00E+0") + " " +
                    (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
            else
                resultText.Text = result.ToString("N3") + " " +
                    (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
        }
    }
}