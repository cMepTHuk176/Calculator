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
    public partial class isoprocess_main : ContentPage
    {
        private string _selected;
        internal static readonly string ErrorText = "ОШИБКА";

        public isoprocess_main()
        {
            InitializeComponent();
        }

        async void isoprocesslist_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                _selected = e.Item.ToString();
            }

            Page pageToGo = _selected switch
            {
                "средняя скорость" => new average_speed(),
                "равноускоренное движение" => new equidistant_motion()
            };

            await Navigation.PushAsync(pageToGo);

             ((ListView)sender).SelectedItem = null;
        }


    }
}