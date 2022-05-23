using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Algebra_main : ContentPage
    {
        public Algebra_main()
        {
            InitializeComponent();
        }
        private async void OnSelected(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;
            
            Page pageToGo = int.Parse(button.ClassId) switch
            {
                1 => new Algebra.DoubleCalc(),
                2 => new Algebra.DoubleCalc(),
                3 => new Algebra.Multiplication_main(),
                _ => new ()
            };
            await Navigation.PushAsync(pageToGo);

        }
    }
}