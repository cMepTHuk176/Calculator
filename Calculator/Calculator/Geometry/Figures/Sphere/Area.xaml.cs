using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Sphere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Area : ContentPage
    {
        private const double PI = Math.PI;

        private enum Parametres
        {
            Радиус,
            Диаметр,
            Длину_окружности,
            Объем
        }

        public Area()
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
            var area = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Радиус => RadiusText(area),
                Parametres.Диаметр => DiameterText(area),
                Parametres.Длину_окружности => CircumferenceText(area),
                Parametres.Объем => VolumeText(area)
            };
        }

        private string RadiusText(double area)
        {
            var t1 = 4 * PI;
            var t2 = area / t1;
            var res = Math.Sqrt(t2);

            return $"r = √(S / 4π)" +
                $"\nr = √({area} / (4 · {Math.Round(PI, 2)}))" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string DiameterText(double area)
        {
            var t1 = area / PI;
            var res = Math.Sqrt(t1);

            return $"D = √(S / π)" +
                $"\nD = √({area} / {Math.Round(PI, 2)})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string CircumferenceText(double area)
        {
            var t1 = PI * area;
            var res = Math.Sqrt(t1);

            return $"L = √(πS)" +
                $"\nL = √({Math.Round(PI, 2)} · {area})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string VolumeText(double area)
        {
            var t1 = 4.0 * PI / 3.0;
            var t2 = Math.Sqrt(area / (4 * PI));
            var t3 = Math.Pow(t2, 3);
            var res = t1 * t3;

            return $"V = 4/3 · π · √((S / 4π)\u00b3)" +
                $"\nV = 4/3 · {Math.Round(PI, 2)} · √(({area} / 4 · {Math.Round(PI, 2)})\u00b3)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}