using System;
using System.Collections.Generic;

using Xamarin.Forms;
using LiteShare.ViewModels;
using LiteShare.Models;

namespace LiteShare.Views {
    public partial class FilesPage : ContentPage {
        public string CurrentPath { get; set; }
        readonly FilesystemViewModel filesViewModel;

        static int NumOfSelected = 0;

        public static List<File> FilesQueue { get; set; } = new List<File>();

        public FilesPage(string path) {
            InitializeComponent();
            filesViewModel = new FilesystemViewModel();
            BindingContext = filesViewModel;
            CurrentPath = path;
            _ = filesViewModel.GetCurrentFolderContent(CurrentPath);
        }


        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as Folder;
            var page = new FilesPage(item.Path) {
                Title = item.Name
            };
            Navigation.PushAsync(page);
        }

        //
        void SendButtonClicked(object sender, EventArgs e) {
            foreach (var item in filesViewModel.FilesList) {
                if (item.Queued == true) {
                    FilesQueue.Add(item);
                }
            }

            //send the queue
        }

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e) {
            if (e.Value == true) {
                ++NumOfSelected;
                FileList.Header = NumOfSelected;
            } else {
                --NumOfSelected;
                if (NumOfSelected == 0) {
                    FileList.Header = null;
                }
            }
        }

    }
}
