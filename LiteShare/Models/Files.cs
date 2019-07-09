using System;
namespace LiteShare.Models {
    public class File {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullPath { get; set; }
        public bool Queued { get; set; }
    }
}
