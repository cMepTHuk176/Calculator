using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    internal enum LengthPickerState
    {
        м = 0, дм = 1, см = 2, мм = 3
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Volume_Main : ContentPage
    {
        private string selected;
        internal static readonly string ERROR_TEXT = "ОШИБКА";

        public Volume_Main()
        {
            InitializeComponent();
        }

        async void figurelist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                selected = e.Item.ToString();
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

             ((ListView)sender).SelectedItem = null;
        }


    }
}