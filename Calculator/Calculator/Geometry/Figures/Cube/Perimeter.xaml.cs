using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perimeter : ContentPage
    {
        private enum Parametres
        {
            Сторону,
            Площадь_стороны,
            Площадь_всей_поверхности,
            Диагональ_стороны,
            Диагональ_куба,
            Объем
        }

        public Perimeter()
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
            var perimeter = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Сторону => Edge(perimeter),
                Parametres.Площадь_стороны => SideArea(perimeter),
                Parametres.Площадь_всей_поверхности => Area(perimeter),
                Parametres.Диагональ_стороны => SideDiagonal(perimeter),
                Parametres.Диагональ_куба => CubeDiagonal(perimeter),
                Parametres.Объем => Volume(perimeter),
            };
        }

        private string Edge(double perimeter)
        {
            var res = perimeter / 4.0;

            return $"a = P / 4" +
                $"\na = {perimeter} / 4" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideArea(double perimeter)
        {
            var res = Math.Pow(perimeter, 2) / 16.0;

            return $"S = P\u00b2 / 16" +
                $"\nS = {perimeter}\u00b2 / 16" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double perimeter)
        {
            var res = 3.0 * Math.Pow(perimeter, 2) / 8.0;

            return $"S = 3 · P\u00b2 / 8" +
                $"\nS = 3 · {perimeter}\u00b2 / 8" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonal(double perimeter)
        {
            var res = perimeter * Math.Sqrt(2) / 4.0;

            return $"D = P · √2 / 4" +
                $"\nD = {perimeter} · √2 / 4" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string CubeDiagonal(double perimeter)
        {
            var res = perimeter * Math.Sqrt(3) / 4.0;

            return $"D = P · √3 / 4" +
                $"\nD = {perimeter} · √3 / 4" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double perimeter)
        {
            var res = Math.Pow(perimeter, 3) / 64.0;

            return $"V = P\u00b3 / 64" +
                $"\nV = {perimeter}\u00b3 / 64" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}