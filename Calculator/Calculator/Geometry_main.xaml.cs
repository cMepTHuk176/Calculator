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
    public partial class Geometry_main : ContentPage
    {
        public Geometry_main()
        {
            InitializeComponent();
        }

        private void geometryList_ItemTapped(object s, ItemTappedEventArgs e)
        {
            string selected = e.Item.ToString() ?? "";
                
            Page to = selected switch
            {
                "Трапеция" => new geometry.trapezoid(),
                "Окружность" => new geometry.circle(),
                "Прямоугольник (квадрат)" => new geometry.rectangle(),
            };

            Navigation.PushAsync(to);
            ((ListView)s).SelectedItem = null;
        }
    }
}