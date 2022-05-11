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
    public partial class Algebra_main : ContentPage
    {
        public Algebra_main()
        {
            InitializeComponent();
        }
        private async void OnSelected(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            
            Page pageToGo = button.ClassId switch
            {
                "1" => new Algebra.DoubleCalc(),
                _ => new NullPage(),
            };
            await Navigation.PushAsync(pageToGo); 

        }
    }
}