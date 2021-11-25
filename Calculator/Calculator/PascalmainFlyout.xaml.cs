using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PascalmainFlyout : ContentPage
    {
        public ListView ListView;

        public PascalmainFlyout()
        {
            InitializeComponent();

            BindingContext = new PascalmainFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class PascalmainFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PascalmainFlyoutMenuItem> MenuItems { get; set; }

            public PascalmainFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PascalmainFlyoutMenuItem>(new[]
                {
                    new PascalmainFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new PascalmainFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new PascalmainFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new PascalmainFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new PascalmainFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}