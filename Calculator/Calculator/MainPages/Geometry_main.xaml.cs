using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Calculator.Geometry;

namespace Calculator.MainPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Geometry_main : ContentPage
    {
        public Geometry_main()
        {
            InitializeComponent();
        }

        private async void Clicked(object s, EventArgs e)
        {
            var imgBtn = s as ImageButton;

            Page to = imgBtn.ClassId switch
            {
                "volume" => new Figures3D_Main(),
                "plain" => new Figures2D_Main()
            };

            await Navigation.PushAsync(to);
        }
    }

}