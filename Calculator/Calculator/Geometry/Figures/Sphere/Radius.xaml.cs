using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Sphere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Radius : ContentPage
    {
        private const double PI = Math.PI;

        private enum Parametres
        {
            Диаметр,
            Длину_окружности,
            Площадь_поверхности,
            Объем
        }

        public Radius()
        {
            InitializeComponent();

            var values = Enum.GetNames(typeof(Parametres));
            foreach (var item in values)
                picker.Items.Add(item.Replace('_', ' '));

            picker.SelectedIndex = 0;
        }

        private void Cancel(object s, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entry);
        }

        private void Result(object s, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry))
                Log();

            else
                resultText.Text = App.ErrorText;
        }

        private void Log()
        {
            var radius = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Диаметр => DiameterText(radius),
                Parametres.Длину_окружности => CircumferenceText(radius),
                Parametres.Площадь_поверхности => AreaText(radius),
                Parametres.Объем => VolumeText(radius)
            };
        }

        private string DiameterText(double radius)
        {
            var res = 2 * radius;

            return $"D = 2r" +
                $"\nD = 2 · {radius}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string CircumferenceText(double radius)
        {
            var res = 2 * PI * radius;

            return $"L = 2πr" +
                $"\nL = 2 · {Math.Round(PI, 2)} · {radius}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string AreaText(double radius)
        {
            var t1 = 4 * PI;
            var t2 = Math.Pow(radius, 2);
            var res = t1 * t2;

            return $"S = 4πr\u00b2" +
                $"\nS = 4 · {Math.Round(PI, 2)} · {radius}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string VolumeText(double radius)
        {
            var t1 = 4.0 / 3.0;
            var t2 = t1 * PI;
            var t3 = Math.Pow(radius, 3);
            var res = t2 * t3;

            return $"V = 4/3 · πr\u00b3" +
                $"\nV = 4/3 · {Math.Round(PI, 2)} · {radius}\u00b3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}