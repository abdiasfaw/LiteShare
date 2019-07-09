using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LiteShare.ViewModels;

namespace LiteShare.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage {
        
        public MainPageDetail() {
            InitializeComponent();
            BindingContext = new FilesViewModel();
            
        }

        protected override void OnAppearing() {
            base.OnAppearing();
        }
    }
}
