using Xamarin.Forms;

namespace Calculator.Root
{
    internal enum LengthPickerState
    {
        мм = 3,
        см = 2,
        дм = 1,
        м = 0
    }

    public partial class App : Application
    {
        public static string ErrorText = "Ошибка";

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
