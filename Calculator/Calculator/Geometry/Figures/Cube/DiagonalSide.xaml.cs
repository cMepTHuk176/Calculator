using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiagonalSide : ContentPage
    {
        private enum Parametres
        {
            Сторону,
            Периметр_стороны,
            Площадь_стороны,
            Площадь_всей_поверхности,
            Диагональ_куба,
            Объем
        }

        public DiagonalSide()
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
            var diag = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Сторону => Edge(diag),
                Parametres.Периметр_стороны => Perimeter(diag),
                Parametres.Площадь_стороны => SideArea(diag),
                Parametres.Площадь_всей_поверхности => Area(diag),
                Parametres.Диагональ_куба => Diagonal(diag),
                Parametres.Объем => Volume(diag),
            };
        }

        private string Edge(double diag)
        {
            var res = diag / Math.Sqrt(2);

            return $"a = D / √2" +
                $"\na = {diag} / √2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Perimeter(double diag)
        {
            var res = 4 * diag / Math.Sqrt(2);

            return $"P = 4 · D / √2" +
                $"\nP = 4 · {diag} / √2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideArea(double diag)
        {
            var res = Math.Pow(diag, 2) / 2.0;

            return $"S = D\u00b2 / 2" +
                $"\nS = {diag}\u00b2 / 2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double diag)
        {
            var res = 3 * Math.Pow(diag, 2);

            return $"S = 3 · D\u00b2" +
                $"\nS = 3 · {diag}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Diagonal(double diag)
        {
            var res = diag * Math.Sqrt(3) / Math.Sqrt(2);

            return $"D₁ = D · √3 / √2" +
                $"\nD₁ = {diag} · √3 / √2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double diag)
        {
            var res = Math.Pow(diag, 3) / (2 * Math.Sqrt(2));

            return $"V = D\u00b3 / (2√2)" +
                $"\nV = {diag}\u00b3 / (2√2)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}