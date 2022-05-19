using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Parallepiped
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EdgesDiagonal : ContentPage
    {
        private enum Parametres
        {
            Третью_сторону,
            Периметр,
            Площадь,
            Объем,
            Диагонали_сторон,
        }

        public EdgesDiagonal()
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
            TextCleaner.EntryClean(entry_A, entry_B, entry_D);
        }

        private void Result(object s, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry_A, entry_B, entry_D))
                Log();

            else
                resultText.Text = App.ErrorText;
        }


        private void Log()
        {
            var a = double.Parse(entry_A.Text);
            var b = double.Parse(entry_B.Text);
            var D = double.Parse(entry_D.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Третью_сторону => Side(a, b, D),
                Parametres.Периметр => Perimeter(a, b, D),
                Parametres.Площадь => Area(a, b, D),
                Parametres.Объем => Volume(a, b, D),
                Parametres.Диагонали_сторон => SideDiagonals(a, b, D),
            };
        }

        private string Side(double a, double b, double D)
        {
            var c = (D * D) - (a * a) - (b * b);
            var res = Math.Sqrt(c);

            if (c < 0)
                return ErrorText(c);

            return $"c = √(D\u00b2 - a\u00b2 - b\u00b2)" +
                $"\nc = √({D}\u00b2 - {a}\u00b2 - {b}\u00b2)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Perimeter(double a, double b, double D)
        {
            var temp = (D * D) - (a * a) - (b * b);
            var c = Math.Sqrt(temp);
            var res = 4 * (a + b + c);

            if (temp < 0)
                return ErrorText(temp);

            return $"c = √(D\u00b2 - a\u00b2 - b\u00b2) = {Math.Round(c, 3)}" +
                $"\nP = 4 · (a + b + c)" +
                $"\nP = 4 · ({a} + {b} + {Math.Round(c, 3)})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double a, double b, double D)
        {
            var temp = (D * D) - (a * a) - (b * b);
            var c = Math.Sqrt(temp);
            var res = 2 * ((a * b) + (a * c) + (b * c));

            if (temp < 0)
                return ErrorText(temp);

            return $"c = √(D\u00b2 - a\u00b2 - b\u00b2) = {Math.Round(c, 3)}" +
                $"\nS = 2 · (a·b + a·c + b·c)" +
                $"\nS = 2 · ({a} · {b} + {a} · {Math.Round(c, 3)} + {b} · {Math.Round(c, 3)})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double a, double b, double D)
        {
            var temp = (D * D) - (a * a) - (b * b);
            var c = Math.Sqrt(temp);
            var res = a * b * c;

            if (temp < 0)
                return ErrorText(temp);

            return $"c = √(D\u00b2 - a\u00b2 - b\u00b2) = {Math.Round(c, 3)}" +
                $"\nV = a · b · c" +
                $"\nV = {a} · {b} · {Math.Round(c, 3)}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonals(double a, double b, double D)
        {
            var temp = (D * D) - (a * a) - (b * b);
            var c = Math.Sqrt(temp);
            var d1 = Math.Sqrt(a * a + b * b);
            var d2 = Math.Sqrt(a * a + c * c);
            var d3 = Math.Sqrt(b * b + c * c);

            if (temp < 0)
                return ErrorText(temp);

            return $"c = √(D\u00b2 - a\u00b2 - b\u00b2) = {Math.Round(c, 3)}" +
                $"\nD₁ = √(a\u00b2 + b\u00b2) = √({a}\u00b2 + {b}\u00b2)" +
                $"\nD₂ = √(a\u00b2 + c\u00b2) = √({a}\u00b2 + {Math.Round(c, 3)}\u00b2)" +
                $"\nD₃ = √(b\u00b2 + c\u00b2) = √({b}\u00b2 + {Math.Round(c, 3)}\u00b2)" +
                $"\nОтвет: " +
                $"D₁ = {Math.Round(d1, 3)}" +
                $"\nD₂  = {Math.Round(d2, 3)}" +
                $"\nD₃ = {Math.Round(d3, 3)}";
        }

        private string ErrorText(double errVal)
        {
            return $"Такого параллелепипеда не существует, поскольку значение " +
                $"третьей стороны \"c\" равно √{errVal}";
        }
    }
}