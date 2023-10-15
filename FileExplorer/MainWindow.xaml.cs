using FileExplorer.Explorer;
using FileExplorer.Files;
using FileExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileExplorer {
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window {

        public MainViewModel Model {

            get=>this.DataContext as MainViewModel;
            set => this.DataContext = value;
        }

        public MainWindow() {

            InitializeComponent();

            foreach (FileModel folder in Fetcher.GetDirectories(@"D:\testfolder")) {

                FilesControl fc = new FilesControl(folder);
                Model.AddFile(fc);
            }

            foreach(FileModel file in Fetcher.GetFiles(@"D:\testfolder")) {

                FilesControl fc = new FilesControl(file);
                Model.AddFile(fc);
            }
        }
    }
}
