using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using LiteShare.Models;
using System.IO;
using Android.Graphics.Drawables;
using Android.Graphics;
using Plugin.Permissions;

namespace LiteShare.Droid {
    [Activity(Label = "LiteShare", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {

        public static readonly int GetInstalledAppsId = 1000;
        public static readonly int GetAllMusicsId = 1001;
        public static readonly int GetAllImagesId = 1002;
        public static readonly int GetAllVideosId = 1003;

        public List<Package> InstalledApplications { get; set; }
        public List<Audio> Musics { get; set; }
        public List<Image> Images { get; set; }
        public List<Video> Videos { get; set; }

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
            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent) {
            base.OnActivityResult(requestCode, resultCode, intent);
            if (requestCode == GetInstalledAppsId) {
                if ((resultCode == Result.Ok) && (intent != null)) {

                }
            } else if (requestCode == GetAllMusicsId) {

            } else if (requestCode == GetAllImagesId) {

            } else if (requestCode == GetAllVideosId) {

            }
        }

        private void GetInstalledApps() {
            IList<ApplicationInfo> applicationInfos = PackageManager.GetInstalledApplications(PackageInfoFlags.MatchDefaultOnly);

            List<Package> packages = new List<Package>();

            foreach (var applicationInfo in applicationInfos) {
                packages.Add(new Package() {
                    ApplicationName = applicationInfo.LoadLabel(Android.App.Application.Context.PackageManager),
                    PackageName = applicationInfo.PackageName,
                    ApplicationIcon = DrawableToStream(applicationInfo.LoadIcon(PackageManager))
                });
            }

            InstalledApplications = packages;
        }

        private void GetAllImages() {
            List<Image> images = new List<Image>();

            try {
                string[] projection =
                {
                    MediaStore.Images.Media.InterfaceConsts.Data,
                    MediaStore.Images.Media.InterfaceConsts.Size,
                    MediaStore.Images.Media.InterfaceConsts.Title
                };

                var cursor = ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri,
                                                   projection,
                                                   null,
                                                   null,
                                                   null);

                int size = cursor.Count;

                if (size > 0) {
                    while (cursor.MoveToNext()) {
                        Image image = new Image() {
                            Path = cursor.GetString(0),
                            Size = cursor.GetString(1),
                            Title = cursor.GetString(2)
                        };
                        images.Add(image);
                    }
                }

                Images = images;
            } catch (Exception) {
                throw;
            }
        }

        private void GetAllMusic() {
            List<Audio> musics = new List<Audio>();

            string selection = MediaStore.Audio.Media.InterfaceConsts.IsMusic + "!= 0";

            string[] projection =
            {
                MediaStore.Audio.Media.InterfaceConsts.Album,
                MediaStore.Audio.Media.InterfaceConsts.Artist,
                MediaStore.Audio.Media.InterfaceConsts.Data,
                MediaStore.Audio.Media.InterfaceConsts.Duration,
                MediaStore.Audio.Media.InterfaceConsts.Size,
                MediaStore.Audio.Media.InterfaceConsts.Title
            };

            var cursor = ContentResolver.Query(MediaStore.Audio.Media.ExternalContentUri,
                                               projection,
                                               selection,
                                               null,
                                               null);

            int size = cursor.Count;

            if (size > 0) {
                while (cursor.MoveToNext()) {
                    Audio music = new Audio() {
                        Album = cursor.GetString(0),
                        Artist = cursor.GetString(1),
                        Path = cursor.GetString(2),
                        Duration = cursor.GetString(3),
                        Size = cursor.GetString(4),
                        Title = cursor.GetString(5)
                    };
                    musics.Add(music);
                }

            }

            Musics = musics;

        }

        private void GetAllVideos() {
            List<Video> videos = new List<Video>();

            string[] projection =
            {
                MediaStore.Video.Media.InterfaceConsts.Data,
                MediaStore.Video.Media.InterfaceConsts.Duration,
                MediaStore.Video.Media.InterfaceConsts.Size,
                MediaStore.Video.Media.InterfaceConsts.Title
            };

            var cursor = ContentResolver.Query(MediaStore.Video.Media.ExternalContentUri,
                                               projection,
                                               null,
                                               null,
                                               null);

            int size = cursor.Count;

            if (size > 0) {
                while (cursor.MoveToNext()) {
                    Video video = new Video() {
                        Path = cursor.GetString(0),
                        Duration = cursor.GetString(1),
                        Size = cursor.GetString(2),
                        Title = cursor.GetString(3)
                    };
                    videos.Add(video);
                }
            }

            Videos = videos;
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