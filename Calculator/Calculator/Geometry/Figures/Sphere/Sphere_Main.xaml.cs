using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Sphere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sphere_Main : ContentPage
    {
        public Sphere_Main()
        {
            InitializeComponent();
        }

        private void Clicked(object s, EventArgs e)
        {
            var btn = s as Button;

            Page to = btn.ClassId switch
            {
                "radius" => new Radius(),
                "diameter" => new Diameter(),
                "area" => new Area(),
                "volume" => new Volume(),
            };

            Navigation.PushAsync(to);
        }
    }
}