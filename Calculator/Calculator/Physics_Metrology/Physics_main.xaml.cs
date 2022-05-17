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
                "Давление в газах" => new NullPage(),
                "Импульс тел" => new Physics_Metrology.Impulse_Navigation(),
                _ => new NullPage(),
            };
            await Navigation.PushAsync(pageToGo);

        }
    }
}