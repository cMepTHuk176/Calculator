using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cylinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RadiusHeight : ContentPage
    {
        private const double PI = Math.PI;

        private enum Parametres
        {
            Диаметр,
            Периметр_окружности,
            Площадь_окружности,
            Площадь_цилиндра,
            Диагональ,
            Объем
        }

        public RadiusHeight()
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
            TextCleaner.EntryClean(entry_R, entry_H);
        }

        private void Result(object s, EventArgs e)
        {
            if (((Parametres)picker.SelectedIndex == Parametres.Диаметр 
                || (Parametres)picker.SelectedIndex == Parametres.Периметр_окружности
                || (Parametres)picker.SelectedIndex == Parametres.Площадь_окружности)
                && TextChecker.EntryCheck(entry_R))
                Log();

            else if (TextChecker.EntryCheck(entry_R, entry_H))
                Log();

            else
                resultText.Text = App.ErrorText;
        }

        private void Log()
        {
            var r = double.Parse(entry_R.Text);
            double.TryParse(entry_H.Text, out double h);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Диаметр => Diameter(r),
                Parametres.Периметр_окружности => Perimeter(r),
                Parametres.Площадь_окружности => CircleArea(r),
                Parametres.Площадь_цилиндра => Area(r, h),
                Parametres.Диагональ => Diagonal(r, h),
                Parametres.Объем => Volume(r, h),
            };
        }

        private string Diameter(double r)
        {
            var res = 2 * r;

            return $"D = 2 · r" +
                $"\nD = 2 · {r}" +
                $"\nОтвет: {res}";
        }

        private string Perimeter(double r)
        {
            var res = 2 * PI * r;

            return $"P = 2πr" +
                $"\nP = 2 · {Math.Round(PI, 2)} · {r}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string CircleArea(double r)
        {
            var res = PI * r * r;

            return $"S = πr\u00b2" +
                $"\nS = {Math.Round(PI, 2)} · {r}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double r, double h)
        {
            var res = 2 * PI * r * (h + r);

            return $"S = 2πr · (h + r)" +
                $"\nS = 2 · {Math.Round(PI, 2)} · {r} · ({h} + {r})" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Diagonal(double r, double h)
        {
            var res = Math.Sqrt(4 * r * r + h * h);

            return $"D = √(4r\u00b2 + h\u00b2)" +
                $"\nD = √(4 · {r}\u00b2 + {h}\u00b2)" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double r, double h)
        {
            var res = PI * r * r * h;

            return $"V = πr\u00b2h" +
                $"\nV = {Math.Round(PI, 2)} · {r}\u00b2 · {h}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}