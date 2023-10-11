using FileExplorer.Files;
using NamespaceHere;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.ViewModels {

    public class MainViewModel : BaseViewModel {

        public ObservableCollection<FilesControl> FileItems { get; set; }

        public MainViewModel() {
            FileItems = new ObservableCollection<FilesControl>();
        }

        public void AddFile(FilesControl file) {
            FileItems.Add(file);
        }
        public void RemoveFile(FilesControl file) {
            FileItems.Remove(file);
        }
        public void ClearFiles() {
            FileItems.Clear();
        }
    }
}
