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
    public partial class accuracy_class : ContentPage
    {
        private readonly string ErrorInacValue = "Неверная погрешность";
        private readonly string ErrorMeasValue = "Неверное измеренное значение";
        private readonly string ErrorLimValue = "Неверный предел измерения";

        public accuracy_class()
        {
            InitializeComponent();
            dependencyPicker.SelectedIndex = 0;
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryInacValue, entryMeasValue, entryLimValue);
        }

        private void result_Inaccuracy(object sender, EventArgs e)
        {


        }

    }
}