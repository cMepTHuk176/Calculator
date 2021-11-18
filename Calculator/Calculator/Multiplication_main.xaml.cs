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
    public partial class Multiplication_main : ContentPage
    {
        private string _selected;
        internal static readonly string ErrorText = "ОШИБКА";
        public Multiplication_main()
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
                "квадрат суммы" => new square_sum(),
                "квадрат разности" => new square_difference(),
                "разность квадратов" => new square_difference_m(),
                "куб суммы" => new cube_sum(),
                "куб разности" => new cube_difference(),
                "сумма кубов" => new cube_sum_m(),
                "разность кубов" => new cube_difference_m()
            };

            await Navigation.PushAsync(pageToGo);

            ((ListView)sender).SelectedItem = null;
        }

    }
}