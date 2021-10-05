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
        void phonesList_ItemSelected(object sender, SelectedItemChangedEventArgs e) // ЭТО ШТО???
        {
            if (e.SelectedItem != null)
                Selected = e.SelectedItem.ToString();
        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Result_Cone(object sender, EventArgs e)
        {
            resultText.Text = ConeVolume.Volume(1, 1).ToString(); // TODO
        }
    }
}