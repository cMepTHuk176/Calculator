using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Sphere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Volume : ContentPage
    {
        private const double PI = Math.PI;

        private enum Parametres
        {
            Радиус,
            Диаметр,
            Длину_окружности,
            Площадь_поверхности
        }

        public Volume()
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
            var value = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Радиус => RadiusText(value),
                Parametres.Диаметр => DiameterText(value),
                Parametres.Длину_окружности => CircumferenceText(value),
                Parametres.Площадь_поверхности => AreaText(value)
            };
        }

        private string RadiusText(double volume)
        {
            var t1 = 3.0 / 4.0 * (volume / PI);
            var res = Math.Pow(t1, 1.0 / 3.0);

            return $"r = ∛(3/4 · V / π)" +
                $"\nr = ∛(3/4 · {volume} / {Math.Round(PI, 2)})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string DiameterText(double volume)
        {
            var t1 = 3.0 / 4.0 * (volume / PI);
            var t2 = Math.Pow(t1, 1.0 / 3.0);
            var res = 2 * t2;

            return $"D = 2 · ∛(3/4 · V / π)" +
                $"\nD = 2 · ∛(3/4 · {volume} / {Math.Round(PI, 2)})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string CircumferenceText(double volume)
        {
            var t1 = 6 * Math.Pow(PI, 2) * volume;
            var res = Math.Pow(t1, 1.0 / 3.0);

            return $"L = ∛(6π\u00b2 · V)" +
                $"\nL = ∛(6 · {Math.Round(PI, 2)}\u00b2 · {volume})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string AreaText(double volume)
        {
            var t1 = 9 * PI / 16;
            var t2 = Math.Pow(volume, 2);
            var t3 = t1 * t2;
            var res = 4 * Math.Pow(t3, 1.0 / 3.0);

            return $"S = 4 · ∛(9π/16 · V\u00b2)" +
                $"\nS = 4 · ∛(9 · {Math.Round(PI, 2)}/16 · {volume}\u00b2)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}