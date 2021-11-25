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
    public partial class isoprocesses_main : ContentPage
    {
        private string _selected;
        internal static readonly string ErrorText = "ОШИБКА";
        public isoprocesses_main()
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
                "Изотермический процесс" => new isotermal(),
                "Изобарный процесс" => new isobaric(),
                "Изохорный процесс" => new Isochoric(),
            };

            await Navigation.PushAsync(pageToGo);

            ((ListView)sender).SelectedItem = null;
        }

    }
}