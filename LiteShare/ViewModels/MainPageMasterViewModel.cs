using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LiteShare.Views;

namespace LiteShare.ViewModels {
    public class MainPageMasterViewModel : INotifyPropertyChanged{
        public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

        public MainPageMasterViewModel() {
            MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
            {
                    new MainPageMenuItem { HasSwitch=false, Title = "Settings" },
                    new MainPageMenuItem { HasSwitch=false, Title = "History" },
                    new MainPageMenuItem { HasSwitch=false, Title = "Clear Cache" },
                    new MainPageMenuItem { HasSwitch=true, Title = "Light Theme" }
                });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
