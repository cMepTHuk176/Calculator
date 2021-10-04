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

                case "объем куба": // TODO

                    break;

                case "объем параллепипеда": // TODO

                    break;

                case "объем квадратной пирамиды": // TODO

                    break;

                case "объем треугольной пирамиды": // TODO

                    break;

                case "объем цилиндра": // TODO

                    break;
            }
        }


    }
}