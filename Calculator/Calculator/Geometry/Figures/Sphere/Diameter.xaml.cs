using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Sphere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Diameter : ContentPage
    {
        private const double PI = Math.PI;

        private enum Parametres
        {
            Радиус,
            Длину_окружности,
            Площадь_поверхности,
            Объем
        }

        public Diameter()
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
            var diameter = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Радиус => RadiusText(diameter),
                Parametres.Длину_окружности => CircumferenceText(diameter),
                Parametres.Площадь_поверхности => AreaText(diameter),
                Parametres.Объем => VolumeText(diameter)
            };
        }

        private string RadiusText(double diameter)
        {
            var res = diameter / 2.0;

            return $"r = D / 2" +
                $"\nr = {diameter} / 2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string CircumferenceText(double diameter)
        {
            var res = PI * diameter;

            return $"L = πD" +
                $"\nL = {Math.Round(PI, 2)} · {diameter}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string AreaText(double diameter)
        {
            var t1 = Math.Pow(diameter, 2);
            var res = PI * t1;

            return $"S = πD\u00b2" +
                $"\nS = {Math.Round(PI, 2)} · {diameter}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string VolumeText(double diameter)
        {
            var t1 = 1.0 / 6.0;
            var t2 = t1 * PI;
            var t3 = Math.Pow(diameter, 3);
            var res = t2 * t3;

            return $"V = 1/6 · πD\u00b3" +
                $"\nV = 1/6 · {Math.Round(PI, 2)} · {diameter}\u00b3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

    }
}