﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class triangular_pyramid_volume : ContentPage
    {
        public triangular_pyramid_volume()
        {
            InitializeComponent();

            resultLengthPicker.Items.Add("м\u00B3");
            resultLengthPicker.Items.Add("дм\u00B3");
            resultLengthPicker.Items.Add("см\u00B3");
            resultLengthPicker.Items.Add("мм\u00B3");

            lengthPickerS.Items.Add("м\u00B2");
            lengthPickerS.Items.Add("дм\u00B2");
            lengthPickerS.Items.Add("см\u00B2");
            lengthPickerS.Items.Add("мм\u00B2");

            resultLengthPicker.SelectedIndex = 0;
            lengthPickerS.SelectedIndex = 0;
            lengthPickerH.SelectedIndex = 0;
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entry_S, entry_H);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry_S, entry_H))
                Result_TriangularPyramid(null, null);
        }

        private void Result_TriangularPyramid(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entry_S, entry_H))
            {
                resultText.Text = Volume_Main.ErrorText;
                return;
            }

            double valueS = Math.Pow(Converter.ConvertToLength(resultLengthPicker, lengthPickerS), 2)
                * double.Parse(entry_S.Text);
            double valueH = Converter.ConvertToLength(resultLengthPicker, lengthPickerH) * double.Parse(entry_H.Text);

            double result = Figure.TriangularPyramidVolume(valueS, valueH);

            if (result is >= 1000 or < 0.01)
                resultText.Text = result.ToString("0.00E+0") + " "
                    + (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
            else
                resultText.Text = result.ToString("N3") + " "
                    + (LengthPickerState)resultLengthPicker.SelectedIndex + string.Format("\u00B3");
        }
    }
}