using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Physics_Metrology
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Impulse_Navigation : ContentPage
    {
        public Impulse_Navigation()
        {
            InitializeComponent();
        }

        async void figurelist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string selected = e.Item.ToString() ?? "";

            Page pageToGo = selected switch
            {
                "Импульс одиночного тела" => new finding_impulse(),
                "Сохранение импульса" => new parallelepiped_volume(),
            };
            await Navigation.PushAsync(pageToGo);
            ((ListView)sender).SelectedItem = null;

        }
    }
}