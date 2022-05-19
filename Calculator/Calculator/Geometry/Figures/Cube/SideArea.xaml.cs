using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideArea : ContentPage
    {
        private enum Parametres
        {
            Сторону,
            Периметр_стороны,
            Площадь_куба,
            Диагональ_куба,
            Диагональ_стороны,
            Объем
        }

        public SideArea()
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
                Parametres.Сторону => Edge(area),
                Parametres.Периметр_стороны => Perimeter(area),
                Parametres.Площадь_куба => Area(area),
                Parametres.Диагональ_куба => Diagonal(area),
                Parametres.Диагональ_стороны => SideDiagonal(area),
                Parametres.Объем => Volume(area),
            };
        }

        private string Edge(double area)
        {
            var res = Math.Sqrt(area);

            return $"a = √S" +
                $"\na = √{area}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Perimeter(double area)
        {
            var res = 4 * Math.Sqrt(area);

            return $"P = 4 · √S" +
                $"\nP = 4 · √{area}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double area)
        {
            var res = 6 * area;

            return $"S₁ = 6 · S" +
                $"\nS₁ = 6 · {area}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Diagonal(double area)
        {
            var res = Math.Sqrt(3 * area);

            return $"D = √(3 · S)" +
                $"\nD = √(3 · {area})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonal(double area)
        {
            var res = Math.Sqrt(2 * area);

            return $"D = √(2 · S)" +
                $"\nD = √(2 · {area})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double area)
        {
            var res = area * Math.Sqrt(area);

            return $"V = S · √S" +
                $"\nV = {area} · √{area}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}