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
    public partial class Volume_Main : ContentPage
    {
        private string selected;
        internal static readonly string ERROR = "ОШИБКА";

        public Volume_Main()
        {
            InitializeComponent();
        }

        async void figurelist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                selected = e.SelectedItem.ToString();
            }

            switch (selected)
            {
                case "объем сферы":
                    await Navigation.PushAsync(new sphere_volume());
                    break;

                case "объем конуса":
                    await Navigation.PushAsync(new cone_volume());
                    break;

                case "объем параллепипеда":
                    await Navigation.PushAsync(new parallelepiped_volume());
                    break;

                case "объем квадратной пирамиды":
                    await Navigation.PushAsync(new square_pyramid_volume());
                    break;

                case "объем треугольной пирамиды":
                    await Navigation.PushAsync(new triangular_pyramid_volume());
                    break;

                case "объем цилиндра":
                    await Navigation.PushAsync(new cylinder_volume());
                    break;
            }
        }


    }
}