using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Parallepiped
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Parallepiped_Main : ContentPage
    {
        public Parallepiped_Main()
        {
            InitializeComponent();
        }

        private void Clicked(object s, EventArgs e)
        {
            var btn = s as Button;

            Page to = btn.ClassId switch
            {
                "edges" => new Edges(),
                "edgediagonal" => new EdgesDiagonal()
            };

            Navigation.PushAsync(to);
        }
    }
}