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
    public partial class Physics_main : ContentPage
    {
        public Physics_main()
        {
            InitializeComponent();
        }
        private async void OnSelected(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Page pageToGo = button.Text switch
            {
                "Расчет погрешности прибора" => new Inaccuracy_main(),
                "Давления в газах" => new Inaccuracy_main()
            };
            await Navigation.PushAsync(pageToGo);

        }
    }
}