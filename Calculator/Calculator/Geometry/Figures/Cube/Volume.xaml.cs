using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Volume : ContentPage
    {
        private enum Parametres
        {
            Сторону,
            Периметр_стороны,
            Площадь_куба,
            Площадь_стороны,
            Диагональ_куба,
            Диагональ_стороны,
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
            var vol = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Сторону => Edge(vol),
                Parametres.Периметр_стороны => Perimeter(vol),
                Parametres.Площадь_куба => Area(vol),
                Parametres.Площадь_стороны => SideArea(vol),
                Parametres.Диагональ_куба => Diagonal(vol),
                Parametres.Диагональ_стороны => SideDiagonal(vol),
            };
        }

        private string Edge(double vol)
        {
            var res = Math.Pow(vol, 1.0 / 3.0);

            return $"a = ∛V" +
                $"\na = ∛{vol}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Perimeter(double vol)
        {
            var res = 4 * Math.Pow(vol, 1.0 / 3.0);

            return $"P = 4 · ∛V" +
                $"\nP = 4 · ∛{vol}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double vol)
        {
            var res = 6 * Math.Pow(vol, 2.0 / 3.0);

            return $"S = 6 · ∛V\u00b2" +
                $"\nS = 6 · ∛{vol}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideArea(double vol)
        {
            var res = Math.Pow(vol, 2.0 / 3.0);

            return $"S = ∛V\u00b2" +
                $"\nS = ∛{vol}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Diagonal(double vol)
        {
            var res = Math.Sqrt(3) * Math.Pow(vol, 1.0 / 3.0);

            return $"D = √3 · ∛V" +
                $"\nD = √3 · ∛{vol}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonal(double vol)
        {
            var res = Math.Sqrt(2) * Math.Pow(vol, 1.0 / 3.0);

            return $"D = √2 · ∛V" +
                $"\nD = √2 · ∛{vol}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }
    }
}