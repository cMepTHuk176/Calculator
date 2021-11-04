using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class acceleration_projection : ContentPage
    {
        public acceleration_projection()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(x0, Vx, t);
        }

        private void Result_AccelerationProjection(object sender, EventArgs e)
        {
            double valueV0x = double.Parse(V0x.Text);
            double valueVx = double.Parse(Vx.Text);
            double valuet = double.Parse(t.Text);

            resultText.Text = Calc_Move(valueV0x, valueVx, valuet).ToString();
        }
        private double Calc_AccelerationProjection(double valueV0x,double valueVx,double valuet)
        {
            double resultMove;
            resultMove = (valueVx-valueV0x)/valuet;
            return resultMove;
        }
    }
}