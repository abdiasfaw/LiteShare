using System;
using System.Collections.Generic;

namespace LiteShare.Models {
    public class CurrentFolder {
        public string FullPath { get; set; }
        public List<string> Folders { get; set; } = new List<string>();
        public List<string> Files { get; set; } = new List<string>();
    }
}
