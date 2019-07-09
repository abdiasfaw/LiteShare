using System;
using System.Collections.Generic;
using System.Text;
using LiteShare.Models;

namespace LiteShare.Services {
    public interface IPackageInfo {
        IEnumerable<Package> GetInstalledApps();
    }
}
