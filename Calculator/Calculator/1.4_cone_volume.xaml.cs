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
    public partial class cone_volume : ContentPage
    {
        string Selected;

        public cone_volume()
        {
            InitializeComponent();
        }
         void phonesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                Selected = e.SelectedItem.ToString();
        }
    }
}