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
    public partial class parallelepiped_volume : ContentPage
    {
        public parallelepiped_volume()
        {
            InitializeComponent();
        }

        private async void Volume_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Result_Parallepiped(object sender, EventArgs e)
        {
            resultText.Text = Parallepiped.Volume(1, 1, 1).ToString(); // TODO
        }
    }
}