﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.geometry
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class rectangle : ContentPage
    {
        public rectangle()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object s, ItemTappedEventArgs e)
        {

        }
    }
}