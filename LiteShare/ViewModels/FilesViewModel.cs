using System;
using System.Collections.ObjectModel;
using PCLStorage;
using LiteShare.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LiteShare.ViewModels {
    public class FilesViewModel {
        
        public ObservableCollection<Files> FilesList { get;  set; }
        public ObservableCollection<Folder> Folders { get; set; } = new ObservableCollection<Folder>();

        private async Task<List<IFolder>> GetDirectoriesAsync(string startingDir = "/storage/emulated/0") {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.GetFolderAsync(startingDir, System.Threading.CancellationToken.None);
            IList<IFolder> folders = await folder.GetFoldersAsync(System.Threading.CancellationToken.None);
            
            return folders.ToList();
        }

        public async void foldersToStringAsync() {
            List<IFolder> folders = await GetDirectoriesAsync();
            if (folders == null) {
                Folders.Add(new Folder { Name = "none" });
                return;
            }

            foreach (var item in folders)
            {
                Folder folder = new Folder {
                    Name = item.Name,
                    Path = item.Path
                };
                Folders.Add(folder);
            }


        }
    }
}
