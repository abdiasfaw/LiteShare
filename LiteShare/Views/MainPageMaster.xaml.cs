using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LiteShare.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.Reflection;

namespace LiteShare.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage {
        public ListView ListView;
        ControlTemplate darkTheme;
        ControlTemplate lightTheme;

        public MainPageMaster() {
            InitializeComponent();

            BindingContext = new MainPageMasterViewModel();
            ListView = MenuItemsListView;

            darkTheme = (ControlTemplate)Application.Current.Resources["DarkTheme"];
            lightTheme = (ControlTemplate)Application.Current.Resources["LightTheme"];
        }
        //TODO(Abdi Asfaw): Handle the Theme Change in below method
        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e) {
            var itemTapped = (Switch)sender;
            this.ControlTemplate = itemTapped.IsToggled ? lightTheme : darkTheme ;
        }
    }
}
