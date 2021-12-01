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
    public partial class mechanic_main : ContentPage
    {
        private string _selected;
        internal static readonly string ErrorText = "ОШИБКА";

        public mechanic_main()
        {
            InitializeComponent();
        }

        async void mechaniclist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                _selected = e.Item.ToString();
            }

            switch(_selected)
            {
                case "средняя скорость":
                    await Navigation.PushAsync(new average_speed());
                    break;

                case "равномерное движение":
                    await Navigation.PushAsync(new equidistant_motion());
                    break;

                case "равноускоренное движение":
                    await Navigation.PushAsync(new accelerate_motion());
                    break;

                case "ускорение":
                    await Navigation.PushAsync(new accelerate());
                    break;

                case "центростремительное ускорение(через w)":
                    await Navigation.PushAsync(new acceleration_center());
                    break;

                case "центростремительное ускорение(через V)":
                    await Navigation.PushAsync(new acceleration_center_lin());
                    break;

                case "Линейная скорость":
                    await Navigation.PushAsync(new linear_velocity());
                    break;
            };
            ((ListView)sender).SelectedItem = null;
        }


    }
}