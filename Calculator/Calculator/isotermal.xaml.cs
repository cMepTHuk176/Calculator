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
    public partial class isotermal : ContentPage
    {
        public isotermal()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(p, v, t);
        }
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(p, v, t))
                Result_isotermal(null, null);
        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void Result_isotermal(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(p, v, t))
            {
                resultText.Text = "ОШИБКА";
                return;
            }
            double result = 4;
            int buf1 = 0, buf2 = 0, n = 0;

            string picker_item = picker.Items[picker.SelectedIndex];
            switch (picker_item)
            {
                case "p(v)": buf1 = int.Parse(p.Text); buf2 = int.Parse(v.Text); n = int.Parse(t.Text) break;
                case "p(t)": buf1 = int.Parse(p.Text); buf2 = int.Parse(t.Text); break;
                case "v(t)": buf1 = int.Parse(p.Text); break;
            }
            Process.Isothermal(buf1, buf2, n, picker_item);
            resultText.Text = result.ToString();
        }
    }
}