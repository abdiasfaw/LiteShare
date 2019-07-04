using System;
using Xamarin.Forms;
using LiteShare.Services;
using System.Collections.Generic;

[assembly: Dependency(typeof(LiteShare.iOS.Services.WifiService))]
namespace LiteShare.iOS.Services {
    public class WifiService : IWifiService {
        public List<string> AvailableWifiAPs() {
            throw new NotImplementedException();
        }

        public bool ConnectToWifi(int netId) {
            throw new NotImplementedException();
        }

        public bool DisconnectFromWifi() {
            throw new NotImplementedException();
        }

        public bool IsWifiOn() {
            throw new NotImplementedException();
        }

        public void ToggleWifiHotspot(bool On) {
            throw new NotImplementedException();
        }

        public bool TurnOffWifi() {
            throw new NotImplementedException();
        }

        public bool TurnOnWifi() {
            throw new NotImplementedException();
        }
    }
}
