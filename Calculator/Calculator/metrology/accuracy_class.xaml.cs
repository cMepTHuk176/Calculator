﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly Dictionary<Entry, string> pairs = new();

        private enum DependencyPickerState
        {
            Mult,
            Addit,
            Comb
        }

        public accuracy_class()
        {
            InitializeComponent();
            InitializeDictionary();
            dependencyPicker.SelectedIndex = 0;
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.FontSize = 40;
            resultText.Text = "0";
            TextCleaner.EntryClean(entryInacValue, entryMeasValue, entryLimValue);
        }

        private void result_Inaccuracy(object sender, EventArgs e)
        {
            if (ErrorInfo() != "0")
            {
                resultText.FontSize = 20;
                resultText.Text = ErrorInfo();
                return;
            }

            resultText.FontSize = 40;
            double resultInac = RoundInaccuracy(ResultFormula());
            double measValue = double.Parse(entryMeasValue.Text);
            int digitsNumber = GetDecimalDigitsCount(resultInac);

            resultText.Text = resultInac == -1
                ? ErrorInacValue
                : measValue.ToString("N" + digitsNumber) + " ± " + resultInac.ToString();
        }

        private double RoundTinyNumber(double number)
        {
            if (number >= 1) return number;

            string numStr = number.ToString();
            int numInd = numStr.IndexOfAny(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            char digit = numStr[numInd];

            return digit is >= '1' and <= '3'
                ? Math.Round(number, numInd, MidpointRounding.AwayFromZero)
                : Math.Round(number, numInd - 1, MidpointRounding.AwayFromZero);
        }

        private double RoundInaccuracy(double number)
        {
            if (number >= 4)
                number = Math.Round(number, MidpointRounding.AwayFromZero);

            else if (number is >= 1 and < 4)
                number = Math.Round(number, 1, MidpointRounding.AwayFromZero);

            else if (number is > 0 and < 1)
                number = RoundTinyNumber(number);

            return number;
        }

        private int GetDecimalDigitsCount(double number)
        {
            string str = number.ToString(new NumberFormatInfo() { NumberDecimalSeparator = "." });
            return str.Contains(".") ? str.Remove(0, Math.Truncate(number).ToString().Length + 1).Length : 0;
        }

        private (string, string) GetInaccuracies()
        {
            string left = "0";
            string right = "0";
            entryInacValue.Text = entryInacValue.Text.Trim();
            int separatorIndex = entryInacValue.Text.IndexOfAny(new char[] { ' ', '/' });
            //int slashIndex = entryInacValue.Text.IndexOf('/');

            if (separatorIndex > 0)
                SplitString(ref left, ref right, separatorIndex);

            return (left, right);
        }

        private double ResultFormula()
        {
            switch ((DependencyPickerState)dependencyPicker.SelectedIndex)
            {
                case DependencyPickerState.Mult:
                    return Inaccuracy.MultiplicativeInaccuracy(double.Parse(entryInacValue.Text),
                                                               double.Parse(entryMeasValue.Text));

                case DependencyPickerState.Addit:
                    return Inaccuracy.AdditiveInaccuracy(double.Parse(entryInacValue.Text),
                                                         double.Parse(entryLimValue.Text));

                case DependencyPickerState.Comb:
                    if (double.TryParse(GetInaccuracies().Item1, out double c) &&
                        double.TryParse(GetInaccuracies().Item2, out double d))
                    {
                        return Inaccuracy.FullInaccuracy(c, d, double.Parse(entryMeasValue.Text),
                                                               double.Parse(entryLimValue.Text));
                    }
                    return -1;
            };

            return -1;
        }

        private string ErrorInfo()
        {
            return (DependencyPickerState)dependencyPicker.SelectedIndex switch
            {
                DependencyPickerState.Mult => DetectFailEntry(entryInacValue, entryMeasValue),
                DependencyPickerState.Addit => DetectFailEntry(entryInacValue, entryLimValue),
                DependencyPickerState.Comb => DetectFailEntry(entryMeasValue, entryLimValue),
                _ => "0",
            };
        }

        private void InitializeDictionary()
        {
            pairs.Add(entryInacValue, ErrorInacValue);
            pairs.Add(entryMeasValue, ErrorMeasValue);
            pairs.Add(entryLimValue, ErrorLimValue);
        }

        private void SplitString(ref string left, ref string right, int index)
        {
            left = entryInacValue.Text.Substring(0, index);
            right = entryInacValue.Text.Substring(index + 1, entryInacValue.Text.Length - index - 1);
        }

        private string DetectFailEntry(params Entry[] entries)
        {
            foreach (var item in entries)
                if (!TextChecker.EntryCheck(item))
                    return pairs[item];

            return "0";
        }
    }
}