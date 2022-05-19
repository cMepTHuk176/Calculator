using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cylinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cylinder_Main : ContentPage
    {
        public Cylinder_Main()
        {
            InitializeComponent();
        }

        private void Clicked(object s, EventArgs e)
        {
            var btn = s as Button;

            Page to = btn.ClassId switch
            {
                "radius_height" => new RadiusHeight(),

            };

            Navigation.PushAsync(to);
        }
    }
}