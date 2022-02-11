using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inaccuracy_main : ContentPage
    {

        public Inaccuracy_main()
        {
            InitializeComponent();
        }

        private async void InaccuracyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string selected = e.Item.ToString() ?? "";

            Page pageToGo = selected switch
            {
                "Расчет погрешности по классу точности прибора" => new accuracy_class()
            };

            await Navigation.PushAsync(pageToGo);

            ((ListView)sender).SelectedItem = null;
        }
    }
}