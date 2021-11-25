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
    public partial class linear_velosity : ContentPage
    {
        public linear_velosity()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(T, R);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(T, R))
                Result_cent(null, null);
        }

        private void Result_cent(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(T, R))
            {
            }
        }

    }
}