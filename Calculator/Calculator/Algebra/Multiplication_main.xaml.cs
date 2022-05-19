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
                "Квадрат суммы" => new square_sum(),
                "Квадрат разности" => new square_difference(),
                "Разность квадратов" => new square_difference_m(),
                "Куб суммы" => new cube_sum(),
                "Куб разности" => new cube_difference(),
                "Сумма кубов" => new cube_sum_m(),
                "Разность кубов" => new cube_difference_m()
            };

            await Navigation.PushAsync(pageToGo);

            ((ListView)sender).SelectedItem = null;
        }

    }
}