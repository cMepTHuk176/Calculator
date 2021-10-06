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
    public partial class square_pyramid_volume : ContentPage
    {
        public square_pyramid_volume()
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
            TextCleaner.EntryClean(entry_A, entry_B, entry_H);
        }

        private void Result_Pyramid(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entry_A, entry_B, entry_H))
            {
                resultText.Text = Volume_Main.ERROR_TEXT;
                return;
            }

            double valueA = double.Parse(entry_A.Text);
            double valueB = double.Parse(entry_B.Text);
            double valueH = double.Parse(entry_H.Text);

            resultText.Text = Figure.SquarePyramidVolume(valueA, valueB, valueH).ToString();
        }
    }
}