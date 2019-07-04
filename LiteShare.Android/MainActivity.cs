using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using LiteShare.Services;

namespace LiteShare.Droid {
    [Activity(Label = "LiteShare", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        public static readonly int GetInstalledAppsId = 1000;

        public TaskCompletionSource<IList<ApplicationInfo>> GetInstalledApplicationsCompletionSource { get; set; }

        protected override void OnCreate(Bundle savedInstanceState) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == GetInstalledAppsId) {
                if ((resultCode == Result.Ok) && (data != null)) {
                    IList<ApplicationInfo> applicationInfos = PackageManager.GetInstalledApplications(PackageInfoFlags.MatchDefaultOnly);
                    GetInstalledApplicationsCompletionSource.SetResult(applicationInfos);
                } else {
                    GetInstalledApplicationsCompletionSource.SetResult(null);
                }
            }
        }
    }
}