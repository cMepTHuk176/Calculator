﻿using Xamarin.Forms;
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

        private async void figurelist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string selected = e.Item.ToString() ?? "";

            Page pageToGo = selected switch
            {
                "Сфера" => new sphere_volume(),
                "Конус" => new cone_volume(),
                "Параллепипед" => new parallelepiped_volume(),
                "Квадратная пирамида" => new square_pyramid_volume(),
                "Треугольная пирамида" => new triangular_pyramid_volume(),
                "Цилиндр" => new cylinder_volume()
            };

            await Navigation.PushAsync(pageToGo);

            ((ListView)sender).SelectedItem = null;
        }

    }
}