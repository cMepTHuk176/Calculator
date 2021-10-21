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
        private string selected;
        internal static readonly string ERROR_TEXT = "ОШИБКА";

        public mechanic_main()
        {
            InitializeComponent();
        }

        async void mechaniclist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                selected = e.Item.ToString();
            }

            switch (selected)
            {
                case "средняя скорость":
                    await Navigation.PushAsync(new average_speed());
                    break;

            }

             ((ListView)sender).SelectedItem = null;
        }


    }
}