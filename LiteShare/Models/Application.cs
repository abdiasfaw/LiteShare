﻿using System;
using System.Text;
using System.IO;

namespace LiteShare.Models {
    public class Application {
        public string ApplicationName { get; set; }
        public string PackageName { get; set; }
        public Stream ApplicationIcon { get; set; }
    }
}
