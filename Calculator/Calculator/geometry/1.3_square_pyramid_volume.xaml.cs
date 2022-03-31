using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class square_pyramid_volume : ContentPage
    {
        public square_pyramid_volume()
        {
            InitializeComponent();

            resultLengthPicker.Items.Add("м\u00B3");
            resultLengthPicker.Items.Add("дм\u00B3");
            resultLengthPicker.Items.Add("см\u00B3");
            resultLengthPicker.Items.Add("мм\u00B3");

            resultLengthPicker.SelectedIndex = 0;
            lengthPickerA.SelectedIndex = 0;
            lengthPickerB.SelectedIndex = 0;
            lengthPickerH.SelectedIndex = 0;
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entry_A, entry_B, entry_H);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry_A, entry_B, entry_H))
                Result_Pyramid(null, null);
        }

        private void Result_Pyramid(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entry_A, entry_B, entry_H))
            {
                resultText.Text = Volume_Main.ErrorText;
                return;
            }

            double valueA = Converter.ConvertToLength(resultLengthPicker, lengthPickerA) * double.Parse(entry_A.Text);
            double valueB = Converter.ConvertToLength(resultLengthPicker, lengthPickerB) * double.Parse(entry_B.Text);
            double valueH = Converter.ConvertToLength(resultLengthPicker, lengthPickerH) * double.Parse(entry_H.Text);

            double result = Figure.SquarePyramidVolume(valueA, valueB, valueH);

            if (result is >= 1000 or < 0.01)
                resultText.Text = result.ToString("0.00E+0") + " " +
                    (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
            else
                resultText.Text = result.ToString("N3") + " " +
                    (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
        }
    }
}