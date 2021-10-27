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
    public partial class Page1 : ContentPage
    {
        public int pages = 0;
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            string pageXAML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<ContentPage xmlns=\"http://xamarin.com/schemas/2014/forms\"\n" +
                "xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\n" +
                "x:Class=\"Calculator.Page1\">\n" +
                "Title=\"Main Page\">\n" +
                "<Label  Text=\"ERR\" FontSize=\"36\" />" +
                "</ContentPage>";
            switch (pages)
            {
                case 0:
                    pageXAML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                    "<ContentPage xmlns=\"http://xamarin.com/schemas/2014/forms\"\n" +
                    "xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\n" +
                    "x:Class=\"Calculator.Page2\">\n" +
                    "<StackLayout>\n" +
                    "<Label  Text=\"один\" FontSize=\"24\" />\n" +
                    "<Button Text = \"Change\" Clicked = \"Button_Clicked\" FontSize = \"24\" />\n" +
                    "</StackLayout>\n" +
                    "</ContentPage>";
                    break;
                case 1:
                    pageXAML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<ContentPage xmlns=\"http://xamarin.com/schemas/2014/forms\"\n" +
                "xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\n" +
                "x:Class=\"Calculator.Page3\">\n" +
                "<StackLayout>\n" +
                "<Label  Text=\"два\" FontSize=\"24\" />\n" +
                "<Button Text = \"Change\" Clicked = \"Button_Clicked\" FontSize = \"24\" />\n" +
                "</StackLayout>\n" +
                "</ContentPage>";
                    break;
            }
            
            this.LoadFromXaml(pageXAML);

            if (pages != 0)
                pages = 0;
            else
                pages = 1;






        }

    }

}