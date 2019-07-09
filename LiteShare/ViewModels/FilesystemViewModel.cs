using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using PCLStorage;
using Plugin.Permissions;
using LiteShare.Models;
using Plugin.Permissions.Abstractions;

namespace LiteShare.ViewModels {
    public class FilesystemViewModel {

        string storageLCL = "/storage/emulated/0";
        string memCard = "/storage/3349-180F"; //first dir in the /storage/

        public FilesystemViewModel() {
            _ = GetCurrentFolderContent();
        }

        

        public ObservableCollection<CurrentFolder> CurrentFolderContent { get; set; } = new ObservableCollection<CurrentFolder>();


        public ObservableCollection<File> FilesList { get; set; } = new ObservableCollection<File>();
        public ObservableCollection<Folder> Folders { get; set; } = new ObservableCollection<Folder>();

        public bool HasMemoryCard { set; get; }

        private async Task<List<IFolder>> GetCurrentFolders(string startingDir="/storage/emulated/0") {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.GetFolderAsync(startingDir, System.Threading.CancellationToken.None);
            IList<IFolder> folders = await folder.GetFoldersAsync(System.Threading.CancellationToken.None);
            
            return folders.ToList();
        }

        private async Task<List<IFile>> GetCurrentFiles(string startingDir= "/storage/emulated/0") {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.GetFolderAsync(startingDir, System.Threading.CancellationToken.None);

            IList<IFile> files = await folder.GetFilesAsync(System.Threading.CancellationToken.None);

            return files.ToList();
        }

        public async Task GetCurrentFolderContent(string path="/storage/emulated/0") {
            Folders.Clear();
            List<IFolder> folders = await GetCurrentFolders(path);
            foreach (var item in folders) {
                Folder folder = new Folder {
                    Name = item.Name,
                    Path = item.Path
                };
                Folders.Add(folder);
            }
            FilesList.Clear();
            List<IFile> files = await GetCurrentFiles(path);
            foreach (var item in files) {
                File file = new File {
                    Title = item.Name,
                    FullPath = item.Path,
                    
                };
                FilesList.Add(file);
            }


        }

        public string GetMemoryPath() {
            if (HasMemoryCard == true) {
                return Folders[0].Name;
            }
            return null;
        }

        public async void HasMemory() {
            var folders = (await GetCurrentFolders("/storage"));

            if (folders[0].Name == "emulated") {
                HasMemoryCard = false;
                return;
            }
            HasMemoryCard = true;
        }
    }
}
