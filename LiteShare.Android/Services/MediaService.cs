using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using LiteShare.Models;
using LiteShare.Services;

[assembly: Xamarin.Forms.Dependency(typeof(LiteShare.Droid.Services.MediaService))]
namespace LiteShare.Droid.Services{
    public class MediaService : IMediaService {
        public IEnumerable<Image> GetAllImages() {
            throw new NotImplementedException();
        }

        public IEnumerable<Audio> GetAllMusics() {
            throw new NotImplementedException();
        }

        public IEnumerable<Video> GetAllVideos() {
            throw new NotImplementedException();
        }
    }
}