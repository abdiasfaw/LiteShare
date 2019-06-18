using System;
using System.Collections.Generic;
namespace LiteShare.Services {
    public interface IWifiService {
        bool IsWifiOn();
        bool TurnOnWifi();
        List<string> AvailableWifiAPs();
        bool ConnectToWifi(string ssid, string password);
        void DisconnectFromWifi();
        bool TurnOnWifiHotSpot();
        void TurnOffWifiHotSpot();
    }
}
