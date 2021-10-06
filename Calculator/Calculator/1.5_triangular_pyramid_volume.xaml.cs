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
    public partial class triangular_pyramid_volume : ContentPage
    {
        public triangular_pyramid_volume()
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
            TextCleaner.EntryClean(entry_S, entry_H);
        }

        private void Result_TriangularPyramid(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entry_S, entry_H))
            {
                resultText.Text = Volume_Main.ERROR_TEXT;
                return;
            }

            double valueS = double.Parse(entry_S.Text);
            double valueH = double.Parse(entry_H.Text);

            resultText.Text = Figure.TriangularPyramidVolume(valueS, valueH).ToString();
        }
    }
}