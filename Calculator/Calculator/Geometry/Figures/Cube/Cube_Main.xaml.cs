using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cube_Main : ContentPage
    {
        public Cube_Main()
        {
            InitializeComponent();
        }

        private void Clicked(object s, EventArgs e)
        {
            var btn = s as Button;

            Page to = btn.ClassId switch
            {
                "edge" => new Edge(),
                "perimeter" => new Perimeter(),
                "diagonal" => new Diagonal(),
                "diagonal_side" => new DiagonalSide(),
                "area" => new Area(),
                "sidearea" => new SideArea(),
                "volume" => new Volume()
            };

            Navigation.PushAsync(to);
        }
    }
}