﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class square_difference_m : ContentPage
    {
        public square_difference_m()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(a, b);
        }
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(a, b))
                Result_square_difference_m(null, null);
        }
        private void Result_square_difference_m(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(a, b))
            {
                resultText.Text = "ОШИБКА";
                return;
            }

            double valueA = double.Parse(a.Text);
            double valueB = double.Parse(b.Text);
           // double result = 2;
            resultText.Text = Square_difference_m(valueA, valueB).ToString();
        }
        private double Square_difference_m(double valueA, double valueB)
        {
            double diff_square = 0;
            diff_square = (valueA + valueB) * (valueA - valueB);
            return diff_square;
        }
    }
}