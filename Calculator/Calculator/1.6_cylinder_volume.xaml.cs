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
    public partial class cylinder_volume : ContentPage
    {
        public cylinder_volume()
        {
            InitializeComponent();
        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Result_Cylinder(object sender, EventArgs e)
        {
            resultText.Text = CylinderVolume.Volume(1, 1).ToString(); // TODO
        }
    }
}