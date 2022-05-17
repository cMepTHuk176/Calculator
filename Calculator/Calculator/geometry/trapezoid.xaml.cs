using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.geometry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class trapezoid : ContentPage
    {
        public trapezoid()
        {
            InitializeComponent();
        }

        private void OnClear(object sender, EventArgs e)
        {
            
        }

        private void Result()
        {

        }

        private void ListView_ItemTapped(object s, ItemTappedEventArgs e)
        {
            string selected = e.Item.ToString() ?? "";

            Page to = selected switch
            {
                "Площадь" => new NullPage(),
                "Средняя линия" => new NullPage(),
                "" => new NullPage()
            };
        }
    }
}