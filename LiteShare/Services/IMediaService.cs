using System;
using System.Collections.Generic;
using System.Text;

namespace LiteShare.Services {
    public interface IMediaService {
        IEnumerable<Models.Image> GetAllImages();
        IEnumerable<Models.Audio> GetAllMusics();
        IEnumerable<Models.Video> GetAllVideos();
    }
}
