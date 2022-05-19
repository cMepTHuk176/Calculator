using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Area : ContentPage
    {
        private enum Parametres
        {
            Сторону,
            Периметр_стороны,
            Площадь_стороны,
            Диагональ_куба,
            Диагональ_стороны,
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
            var square = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Сторону => Edge(square),
                Parametres.Периметр_стороны => Perimeter(square),
                Parametres.Площадь_стороны => SideArea(square),
                Parametres.Диагональ_куба => Diagonal(square),
                Parametres.Диагональ_стороны => SideDiagonal(square),
                Parametres.Объем => Volume(square),
            };
        }

        private string Edge(double square)
        {
            var res = Math.Sqrt(square / 6.0);

            return $"a = √(S / 6)" +
                $"\na = √({square} / 6)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Perimeter(double square)
        {
            var res = 4 * Math.Sqrt(square / 6.0);

            return $"P = 4 · √(S / 6)" +
                $"\nP = 4 · √({square} / 6)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideArea(double square)
        {
            var res = square / 6.0;

            return $"S₁ = S / 6" +
                $"\nS₁ = {square} / 6" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Diagonal(double square)
        {
            var res = Math.Sqrt(square / 2.0);

            return $"D = √(S / 2)" +
                $"\nD = √({square} / 2)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonal(double square)
        {
            var res = Math.Sqrt(square / 3.0);

            return $"D = √(S / 3)" +
                $"\nD = √({square} / 3)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double square)
        {
            var res = square * Math.Sqrt(square) / (6 * Math.Sqrt(6));

            return $"V = (S · √S) / (6 · √6)" +
                $"\nV = ({square} · √{square}) / (6 · √6)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}