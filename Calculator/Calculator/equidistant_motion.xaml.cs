using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class equidistant_motion : ContentPage
    {
        public equidistant_motion()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(x0, Vx, t);
        }

        private void Result_Move(object sender, EventArgs e)
        {
            double valuex0 = double.Parse(x0.Text);
            double valueVx = double.Parse(Vx.Text);
            double valuet = double.Parse(t.Text);

            resultText.Text = Calc_Move(valuex0, valueVx, valuet).ToString();
        }
        private double Calc_Move(double valuex0,double valueVx,double valuet)
        {
            double resultMove;
            resultMove = valuex0 + valueVx * valuet;
            return resultMove;
        }
    }
}