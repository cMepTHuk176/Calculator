using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
      /*  class Function
        {
            public:
                double a;
                double b;
                void Result_Move()
            {
                
            }
            double Square_difference_m()
            {
                double dif;
                dif = (a + b) * (a - b);
                return dif;
            }
            double Сube_difference_m()
            {
                double dif;
                dif = (a - b) * (a * a + a * b + b * b);
                return dif;
            }
             double Cube_sum_m()
            {
                double sum;
                sum = (a + b) * (a * a - a * b + b * b);
                return sum;
            }


        }
        public Page5()
        {
            InitializeComponent();
        }
      

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(ValueA, ValueB);
        }

        private void Result_Move(object sender, EventArgs e)
        {
            double ValueA = double.Parse(ValueA.Text);
            double ValueB = double.Parse(ValueB.Text);

            resultText.Text = Square_difference_m(ValueA, ValueB).ToString();
            resultText.Text = Сube_difference_m(ValueA, ValueB).ToString();
            resultText.Text = Cube_sum_m(ValueA, ValueB).ToString();
        }
       
        */

    }
} 