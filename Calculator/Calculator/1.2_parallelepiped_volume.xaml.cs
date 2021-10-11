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
    public partial class parallelepiped_volume : ContentPage
    {

        public parallelepiped_volume()
        {
            InitializeComponent();

            resultLengthPicker.Items.Add("м\u00B3");
            resultLengthPicker.Items.Add("дм\u00B3");
            resultLengthPicker.Items.Add("см\u00B3");
            resultLengthPicker.Items.Add("мм\u00B3");

            lengthPickerX.SelectedIndex = 0;
            lengthPickerY.SelectedIndex = 0;
            lengthPickerZ.SelectedIndex = 0;
            resultLengthPicker.SelectedIndex = 0;

        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entry_X, entry_Y, entry_Z);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry_X, entry_Y, entry_Z))
                Result_Parallepiped(null, null);
        }


        private void Result_Parallepiped(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entry_X, entry_Y, entry_Z))
            {
                resultText.Text = Volume_Main.ERROR_TEXT;
                return;
            }

            double valueX = double.Parse(entry_X.Text);
            double valueY = double.Parse(entry_Y.Text);
            double valueZ = double.Parse(entry_Z.Text);

            double result = Converter.ConvertToLength(resultLengthPicker, lengthPickerX, lengthPickerY,
                lengthPickerZ) * Figure.ParallepipedVolume(valueX, valueY, valueZ);

            if (result is > 1000 or < 0.01)
                resultText.Text = result.ToString("0.00E+0") + " " +
                    (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
            else
                resultText.Text = result.ToString("N3") + " " +
                    (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
            
        }
    }
}