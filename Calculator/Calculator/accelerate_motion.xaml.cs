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
    public partial class accelerate_motion : ContentPage
    {
        public accelerate_motion()
        {
            InitializeComponent();
            textForm.Text = "x = x\u2080±V\u2080\u00B7t±(a\u00B7t\u00B2)/2";
            entryX0.Placeholder = "x\u2080";
            entryV0.Placeholder = "V\u2080";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryX0, entryV0, entryA, entryT);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryX0, entryV0, entryA, entryT))
                Result_accelerate_motion(null, null);
        }

        private void Result_accelerate_motion(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryX0, entryV0, entryA, entryT))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            var x0 = double.Parse(entryX0.Text);
            var V0 = double.Parse(entryV0.Text);
            var a = double.Parse(entryA.Text);
            var t = double.Parse(entryT.Text);
            var resultDistance = Mechanic.equidistant_motion_point(x0, V0, a, t);

            var precision = (resultDistance - (int)resultDistance == 0)
                ? "0"
                : "2";

            resultText.Text = resultDistance is >= 0.01 and <= 1000
                ? resultDistance.ToString($"N{precision}") + " м"
                : resultDistance.ToString("0.00E+0") + " м";
        }


    }
}