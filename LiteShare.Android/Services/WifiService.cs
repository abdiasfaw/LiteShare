using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang.Reflect;
using LiteShare.Services;

using Xamarin.Forms;

[assembly: Dependency(typeof(LiteShare.Droid.Services.WifiService))]
namespace LiteShare.Droid.Services {
    class WifiService : IWifiService {
        WifiManager _manager;
        WifiConfiguration config;

        public WifiService()
        {
            _manager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
        }

        public List<string> AvailableWifiAPs() {
            bool scanStatus = _manager.StartScan();
            if (scanStatus) {
                IList<ScanResult> scanResults = _manager.ScanResults;
                List<string> networkNames = new List<string>();
                foreach (ScanResult scanResult in scanResults) {
                    networkNames.Add(scanResult.Ssid);
                }
                return networkNames;
            } else return null;
        }

        public bool ConnectToWifi(int netId) {
            return _manager.EnableNetwork(netId, true);
        }

        public bool DisconnectFromWifi() {
            return _manager.Disconnect();
        }

        public bool IsWifiOn() {
            return _manager.IsWifiEnabled;
        }

        public bool TurnOnWifi() {
            return _manager.SetWifiEnabled(true);
        }

        public bool TurnOffWifi() {
            return _manager.SetWifiEnabled(false);
        }

        public void ToggleWifiHotspot(bool On) {
            Method[] methods = _manager.Class.GetDeclaredMethods();
            Boolean enabled = false;

            foreach (Method method in methods) {
                if (method.Name.Equals("isWifiEnabled")) {
                    enabled = (Boolean)method.Invoke(_manager);
                }
                if (method.Name.Equals("getWifiApConfiguration")) {
                    try {
                        config = (WifiConfiguration)method.Invoke(_manager, null);
                        config.Ssid = "liteshare";
                        config.PreSharedKey = GenerateRandomPassword(8);
                    } catch (Exception e) {
                        Log.Error("WifiServiceImplementation", "Error chagning network settings\n" + e.Message);
                    }
                }
            }

            // if hotspot is not enabled and the method received True, turn on hotspot
            if (On && !enabled) {
                foreach (Method method in methods) {
                    if (method.Equals("setWifiApEnabled")) {
                        try {
                            method.Invoke(_manager, config, true);
                        } catch (Exception e) {
                            Log.Info("WifiServiceImplementation", "Error turning hotspot on\n" + e.Message);
                        }
                    }
                }
            }

            // if hotspot is enabled and the method received False, turn off hotspot
            else if (!On && enabled) {
                foreach (Method method in methods) {
                    if (method.Name.Equals("setWifiApEnabled")) {
                        try {
                            method.Invoke(_manager, config, false);
                        } catch (Exception e) {
                            Log.Info("WifiServiceImplementaion", "Error turning hotspot off\n" + e.Message);
                        }
                    }
                }
            }
        }

        private string GenerateRandomPassword(int length) {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
