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
    public partial class axell : ContentPage
    {
        public axell()
        {
            InitializeComponent();
        }
        private async void Mechanic_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(Vx0, Vx, t);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(Vx0, Vx, t))
                Result_axel(null, null);
        }

        private void Result_axel(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(Vx0, Vx, t))
            {
            }
        }


    }
}