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
    public partial class Volume_Main : ContentPage
    {
        string selected;
        public Volume_Main()
        {
            InitializeComponent();
        }
     void figurelist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                selected = e.SelectedItem.ToString();
            }
        }
    }
}