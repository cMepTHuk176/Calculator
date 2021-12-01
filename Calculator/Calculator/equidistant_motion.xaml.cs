using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            textForm.Text = "x = x\u2080±Vx\u00B7t";
            entryx0.Placeholder = "x\u2080";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryx0, entryVx, entryt);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryx0, entryVx, entryt))
                Result_Equidistant(null, null);
        }

        private void Result_Equidistant(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryx0, entryVx, entryt))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            var x0 = double.Parse(entryx0.Text);
            var Vx = double.Parse(entryVx.Text);
            var t = double.Parse(entryt.Text);
            var resultDistant = Mechanic.EquidistantMotion(x0, Vx, t);

            var precision = (resultDistant - (int)resultDistant == 0)
                ? "0"
                : "2";

            resultText.Text = resultDistant is >= 0.01 and <= 1000
                ? resultDistant.ToString($"N{precision}") + " м"
                : resultDistant.ToString("0.00E+0") + " м";
        }

    }
}