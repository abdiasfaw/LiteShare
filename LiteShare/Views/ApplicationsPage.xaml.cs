using System;
using System.Collections.Generic;
using LiteShare.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiteShare.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationsPage : ContentPage {
        //IPackageInfo packageInfo;
        public ApplicationsPage() {
            InitializeComponent();
            CollectionView collectionView = Content as CollectionView;
            var packageInfo = DependencyService.Get<IPackageInfo>().GetInstalledApps();
            if (packageInfo != null)
                collectionView.ItemsSource = packageInfo;
        }
    }
}
