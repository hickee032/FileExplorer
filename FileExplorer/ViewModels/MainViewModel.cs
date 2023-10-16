using FileExplorer.Explorer;
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

        #region Navigation

        public void TryNavigateToPath(string path) {

            if(path == string.Empty) {
                ClearFiles();

                foreach(FileModel drive in Fetcher.GetDrives()) {


                }
            }

        }
        public void NavigateFromModel(FileModel file) {
            TryNavigateToPath(file.Path);
        }

        #endregion

        public void AddFile(FilesControl file) {
            FileItems.Add(file);
        }
        public void RemoveFile(FilesControl file) {
            FileItems.Remove(file);
        }
        public void ClearFiles() {
            FileItems.Clear();
        }
        public FilesControl CreateFileControl(FileModel fModel) {

            FilesControl fc = new FilesControl(fModel);
            SetupFileControlCallbacks(fc);
            return fc;
        }

        public void SetupFileControlCallbacks(FilesControl fc) {
            fc.NavigateToPathCallback = NavigateFromModel;
        }
    }
}
