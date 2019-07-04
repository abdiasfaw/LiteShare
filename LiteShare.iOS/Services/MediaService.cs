using System;
using System.Collections.Generic;
using LiteShare.Models;
using LiteShare.Services;

using Xamarin.Forms;
[assembly: Dependency(typeof(LiteShare.iOS.Services.MediaService))]
namespace LiteShare.iOS.Services {
    public class MediaService : IMediaService{
        public MediaService() {
        }

        public IEnumerable<Models.Image> GetAllImages() {
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
