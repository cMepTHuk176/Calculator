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
        м = 0,
        дм = 1,
        см = 2,
        мм = 3
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Volume_Main : ContentPage
    {
        private string _selected;
        internal static readonly string ErrorText = "ОШИБКА";

        public Volume_Main()
        {
            InitializeComponent();
        }

        async void figurelist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                _selected = e.Item.ToString();
            }

            Page pageToGo = _selected switch
            {
                "объем сферы" => new sphere_volume(),
                "объем конуса" => new cone_volume(),
                "объем параллепипеда" => new parallelepiped_volume(),
                "объем квадратной пирамиды" => new square_pyramid_volume(),
                "объем треугольной пирамиды" => new triangular_pyramid_volume(),
                "объем цилиндра" => new cylinder_volume()
            };

            await Navigation.PushAsync(pageToGo);

            ((ListView)sender).SelectedItem = null;
        }

    }
}