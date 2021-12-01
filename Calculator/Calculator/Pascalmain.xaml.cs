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
    public partial class PascalMain : ContentPage
    {
        public PascalMain()
        {
            InitializeComponent();
        }

        private async void pascal_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Page to = e.ItemIndex switch
            {
                0 => new Pr(),
                1 => new PrGidro(),
                2 => new PrAtm()
            };

            await Navigation.PushAsync(to);
        }
    }
}