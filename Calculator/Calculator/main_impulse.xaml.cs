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
    public partial class Impulse_Main : ContentPage
    {
        private string _selected;
        internal static readonly string ErrorText = "ОШИБКА";

        public Impulse_Main()
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
                "Импульс одиночного тела" => new finding_impulse(),
                "Сохранение импульса" => new preservation_impulse(),
            };

            await Navigation.PushAsync(pageToGo);

            ((ListView)sender).SelectedItem = null;
        }

    }
}