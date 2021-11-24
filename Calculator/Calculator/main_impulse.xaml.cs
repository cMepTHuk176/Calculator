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
    public partial class Imp_main : ContentPage
    {
        private string _selected;
        internal static readonly string ErrorText = "ОШИБКА";

        public Imp_main()
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