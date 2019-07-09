using System;
using System.Collections.Generic;

using Xamarin.Forms;
using LiteShare.ViewModels;

namespace LiteShare.Views {
    public partial class FilesPage : ContentPage {
        readonly FilesViewModel filesViewModel;
        public FilesPage() {
            InitializeComponent();
            filesViewModel = new FilesViewModel();
            BindingContext = filesViewModel;

        }

        protected override void OnAppearing() {
            base.OnAppearing();

            filesViewModel.foldersToStringAsync();
        }
    }
}
