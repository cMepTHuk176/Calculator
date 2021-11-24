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
    public partial class finding_impulse : ContentPage
    {
        public finding_impulse()
        {
            InitializeComponent();
        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnClear(object sender, EventArgs e)
        {
           //resultText.Text = "0";
           //TextCleaner.EntryClean(entryText_R);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
               //if (TextChecker.EntryCheck(entryText_R))
               //Result_Sphere(null, null);
        }

        private void Result_Sphere(object sender, EventArgs e)
        {
        }
    }
}