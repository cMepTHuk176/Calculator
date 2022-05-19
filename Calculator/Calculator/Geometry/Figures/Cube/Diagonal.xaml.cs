using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Diagonal : ContentPage
    {
        private enum Parametres
        {
            Сторону,
            Периметр_стороны,
            Площадь_стороны,
            Площадь_всей_поверхности,
            Диагональ_стороны,
            Объем
        }

        public Diagonal()
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
            var diagonal = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Сторону => Edge(diagonal),
                Parametres.Периметр_стороны => Perimeter(diagonal),
                Parametres.Площадь_стороны => SideArea(diagonal),
                Parametres.Площадь_всей_поверхности => Area(diagonal),
                Parametres.Диагональ_стороны => SideDiagonal(diagonal),
                Parametres.Объем => Volume(diagonal),
            };
        }

        private string Edge(double diagonal)
        {
            var res = diagonal / Math.Sqrt(3);

            return $"a = D / √3" +
                $"\na = {diagonal} / √3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Perimeter(double diagonal)
        {
            var res = 4 * diagonal / Math.Sqrt(3);

            return $"P = 4 · D / √3" +
                $"\nP = 4 · {diagonal} / √3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideArea(double diagonal)
        {
            var res = Math.Pow(diagonal, 2) / 3.0;

            return $"S = D\u00b2 / 3" +
                $"\nS = {diagonal}\u00b2 / 3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double diagonal)
        {
            var res = 6 * Math.Pow(diagonal, 2) / 3.0;

            return $"S = 6 · D\u00b2 / 3" +
                $"\nS = 6 · {diagonal}\u00b2 / 3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonal(double diagonal)
        {
            var res = diagonal * Math.Sqrt(2) / Math.Sqrt(3);

            return $"D₁ = D · √2 / √3" +
                $"\nD₁ = {diagonal} · √2 / √3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double diagonal)
        {
            var res = Math.Pow(diagonal, 3) / (3.0 * Math.Sqrt(3));

            return $"V = D\u00b3 / (3√3)" +
                $"\nV = {diagonal}\u00b3 / (3√3)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}