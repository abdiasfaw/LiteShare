using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using LiteShare.Models;
using LiteShare.Services;

[assembly: Xamarin.Forms.Dependency(typeof(LiteShare.Droid.MediaServiceAndroid))]
namespace LiteShare.Droid {
    public class MediaServiceAndroid : IMediaService {
        private MainActivity Current = (MainActivity)Android.App.Application.Context;

        public IEnumerable<Image> GetAllImages() {
            Intent intent = new Intent();
            intent.SetType("image/*");
            Current.StartActivityForResult(Intent.CreateChooser(intent, "Get All Images"), MainActivity.GetAllImagesId);

            return Current.Images;
        }

        public IEnumerable<Audio> GetAllMusics() {
            Intent intent = new Intent();
            intent.SetType("audio/*");
            Current.StartActivityForResult(Intent.CreateChooser(intent, "Get All Images"), MainActivity.GetAllImagesId);

            return Current.Musics;
        }

        public IEnumerable<Video> GetAllVideos() {
            Intent intent = new Intent();
            intent.SetType("videos/*");
            Current.StartActivityForResult(Intent.CreateChooser(intent, "Get All Images"), MainActivity.GetAllImagesId);

            return Current.Videos;
        }
    }
}