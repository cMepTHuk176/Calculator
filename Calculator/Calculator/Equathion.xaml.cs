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
    public partial class Equathion : ContentPage
    {
        public Equathion()
        {
            InitializeComponent();

        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryText_A);
            TextCleaner.EntryClean(entryText_B);
            TextCleaner.EntryClean(entryText_C);
        }
    }
}