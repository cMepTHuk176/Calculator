using System;
using Calculator.Root;
using Calculator.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Geometry.Figures.Cube
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edge : ContentPage
    {
        private enum Parametres
        {
            Периметр_стороны,
            Площадь_стороны,
            Площадь_всей_поверхности,
            Диагональ_стороны,
            Диагональ_куба,
            Объем
        }

        public Edge()
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
            var edge = double.Parse(entry.Text);

            resultText.Text = (Parametres)picker.SelectedIndex switch
            {
                Parametres.Периметр_стороны => Perimeter(edge),
                Parametres.Площадь_стороны => SideArea(edge),
                Parametres.Площадь_всей_поверхности => Area(edge),
                Parametres.Диагональ_стороны => SideDiagonal(edge),
                Parametres.Диагональ_куба => CubeDiagonal(edge),
                Parametres.Объем => Volume(edge),
            };
        }

        private string Perimeter(double edge)
        {
            var res = 4 * edge;

            return $"P = 4 · a" +
                $"\nP = 4 · {edge}" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideArea(double edge)
        {
            var res = edge * edge;

            return $"S = a\u00b2" +
                $"\nS = {edge}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Area(double edge)
        {
            var res = 6 * edge * edge;

            return $"S = 6 · a\u00b2" +
                $"\nS = 6 · {edge}\u00b2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string SideDiagonal(double edge)
        {
            var res = edge * Math.Sqrt(2);

            return $"D = a · √2" +
                $"\nD = {edge} · √2" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string CubeDiagonal(double edge)
        {
            var res = edge * Math.Sqrt(3);

            return $"D = a · √3" +
                $"\nD = {edge} · √3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

        private string Volume(double edge)
        {
            var res = Math.Pow(edge, 3);

            return $"V = a\u00b3" +
                $"\nV = {edge}\u00b3" +
                $"\nОтвет: {Math.Round(res, 3)}";
        }

    }
}