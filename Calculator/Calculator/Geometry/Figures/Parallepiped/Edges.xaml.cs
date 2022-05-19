using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Parallepiped
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edges : ContentPage
    {
        private enum Parametres
        {
            Периметр,
            Площадь,
            Объем,
            Диагонали_сторон,
            Диагональ_параллелепипеда
        }

        public Edges()
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
            TextCleaner.EntryClean(entry_A, entry_B, entry_C);
        }

        private void Result(object s, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry_A, entry_B, entry_C))
                Log();

            else
                resultText.Text = App.ErrorText;
        }

        private void Log()
        {
            var a = double.Parse(entry_A.Text);
            var b = double.Parse(entry_B.Text);
            var c = double.Parse(entry_C.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Периметр => Perimeter(a, b, c),
                Parametres.Площадь => Area(a, b, c),
                Parametres.Объем => Volume(a, b, c),
                Parametres.Диагонали_сторон => SideDiagonals(a, b, c),
                Parametres.Диагональ_параллелепипеда => Diagonal(a, b, c),
            };
        }

        private string Perimeter(double a, double b, double c)
        {
            var res = 4 * (a + b + c);

            return $"P = 4 · (a + b + c)" +
                $"\nP = 4 · ({a} + {b} + {c})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double a, double b, double c)
        {
            var res = 2 * ((a * b) + (a * c) + (b * c));

            return $"S = 2 · (a·b + a·c + b·c)" +
                $"\nS = 2 · ({a}·{b} + {a}·{c} + {b}·{c})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double a, double b, double c)
        {
            var res = a * b * c;

            return $"V = a · b · c" +
                $"\nV = {a} · {b} · {c}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonals(double a, double b, double c)
        {
            var d1 = Math.Sqrt(a * a + b * b);
            var d2 = Math.Sqrt(a * a + c * c);
            var d3 = Math.Sqrt(b * b + c * c);

            return $"D₁ = √(a\u00b2 + b\u00b2) = √({a}\u00b2 + {b}\u00b2)" +
                $"\nD₂ = √(a\u00b2 + c\u00b2) = √({a}\u00b2 + {c}\u00b2)" +
                $"\nD₃ = √(b\u00b2 + c\u00b2) = √({b}\u00b2 + {c}\u00b2)" +
                "\nОтвет: " +
                $"D₁ = {Math.Round(d1, 3)}" +
                $"\nD₂ = {Math.Round(d2, 3)}" +
                $"\nD₃ = {Math.Round(d3, 3)}";
        }

        private string Diagonal(double a, double b, double c)
        {
            var res = Math.Sqrt(a * a + b * b + c * c);

            return $"D = √(a\u00b2 + b\u00b2 + c\u00b2)" +
                $"\nD = √({a}\u00b2 + {b}\u00b2 + {c}\u00b2)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}