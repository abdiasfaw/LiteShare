using System;
using System.Collections.Generic;
namespace LiteShare.Services {
    public interface IWifiService {
        bool IsWifiOn();
        bool TurnOnWifi();
        bool TurnOffWifi();
        List<string> AvailableWifiAPs();
        bool ConnectToWifi(int netId);
        bool DisconnectFromWifi();
        void ToggleWifiHotspot(bool On);
    }
}
