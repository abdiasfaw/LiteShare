using System;
using Xamarin.Forms;
using LiteShare.Services;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(LiteShare.Droid.Services.WifiService))]
namespace LiteShare.Droid.Services {
    public class WifiService : IWifiService {
        public WifiService() { }

        public List<string> AvailableWifiAPs() {
            throw new NotImplementedException();
        }

        public bool ConnectToWifi(string ssid, string password) {
            throw new NotImplementedException();
        }

        public void DisconnectFromWifi() {
            throw new NotImplementedException();
        }

        public bool IsWifiOn() {
            throw new NotImplementedException();
        }

        public void TurnOffWifiHotSpot() {
            throw new NotImplementedException();
        }

        public bool TurnOnWifi() {
            throw new NotImplementedException();
        }

        public bool TurnOnWifiHotSpot() {
            throw new NotImplementedException();
        }
    }
}
