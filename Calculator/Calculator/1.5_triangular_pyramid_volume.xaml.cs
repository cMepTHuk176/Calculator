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
    public partial class triangular_pyramid_volume : ContentPage
    {
        public triangular_pyramid_volume()
        {
            InitializeComponent();
        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Result_TriangularPyramid(object sender, EventArgs e)
        {
            resultText.Text = TriangularPyramid.Volume(1, 1).ToString(); // TODO
        }
    }
}