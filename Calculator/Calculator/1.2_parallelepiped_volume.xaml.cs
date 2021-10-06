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

            resultText.Text = Figure.ParallepipedVolume(valueX, valueY, valueZ).ToString();

        }
    }
}