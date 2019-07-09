using System;
using System.Collections.ObjectModel;
using LiteShare.Models;


namespace LiteShare.ViewModels {
    public class MainPageDetailViewModel {
        public ObservableCollection<MainPageDetailItem> DetailItems { get; set; } = new ObservableCollection<MainPageDetailItem>();

        static FilesystemViewModel filesystem { get; set; } = new FilesystemViewModel();
        string sdcard = filesystem.GetMemoryPath();
        public MainPageDetailViewModel() {
            DetailItems = new ObservableCollection<MainPageDetailItem>(new[] {
                    new MainPageDetailItem{ Title="Phone Storage", Action="/storage/emulated/0", ImageIcon="phone.png" },
                    new MainPageDetailItem { Title = "SD Card", Action = sdcard , ImageIcon="MicroSD.png" }
        });

            
            

        }
    }
}
