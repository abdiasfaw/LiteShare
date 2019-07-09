using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LiteShare.ViewModels;
using LiteShare.Models;

namespace LiteShare.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage {
        public ListView ListView;

        public MainPageDetail() {
            InitializeComponent();
            BindingContext = new MainPageDetailViewModel();
            ListView = ListFolders;
            //ImageIcon.ImageSource = ImageSource.FromResource(BindingContextProperty.PropertyName);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as MainPageDetailItem;
            if (item == null)
                return;
            var page = new FilesPage(item.Action);
            page.Title = item.Title;
            Navigation.PushAsync(page);

            ListFolders.SelectedItem = null;
        }
    }
}
