using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Calculator.Geometry.Figures.Sphere;
using Calculator.Geometry.Figures.Cube;
using Calculator.Geometry.Figures.Parallepiped;
using Calculator.Geometry.Figures.Cylinder;

namespace Calculator.Geometry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Figures3D_Main : ContentPage
    {
        public Figures3D_Main()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object s, EventArgs e)
        {
            var selected = ((Button)s).ClassId;

            Page to = selected switch
            {
                "sphere" => new Sphere_Main(),
                "cube" => new Cube_Main(),
                "parallepiped" => new Parallepiped_Main(),
                "cylinder" => new Cylinder_Main(),

            };

            await Navigation.PushAsync(to);
        }

    }
}