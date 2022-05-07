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

            Page to = selected switch
            {
                "Расчет погрешности по классу точности прибора" => new accuracy_class(),
                _ => throw new System.NotImplementedException()
            };

            await Navigation.PushAsync(to);

            ((ListView)sender).SelectedItem = null;
        }
    }
}