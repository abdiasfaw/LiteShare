using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using LiteShare.Services;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LiteShare.Droid.Services.PackageInfo))]
namespace LiteShare.Droid.Services {
    public class PackageInfo: IPackageInfo {

        public IEnumerable<Models.Package> GetInstalledApps() {
            var applicationInfos = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchDefaultOnly);
            List<Models.Package> applications = new List<Models.Package>();
            foreach (var applicationInfo in applicationInfos) {
                applications.Add(new Models.Package {
                    ApplicationName = applicationInfo.LoadLabel(Android.App.Application.Context.PackageManager),
                    PackageName = applicationInfo.PackageName,
                    ApplicationIcon = DrawableToStream(applicationInfo.LoadIcon(Android.App.Application.Context.PackageManager))
                });
            }
            return applications;
        }

        private Stream DrawableToStream(Drawable drawable) {
            using (var bitmap = ((BitmapDrawable)drawable).Bitmap) {
                var stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
                return stream;
            }
        }
    }
}