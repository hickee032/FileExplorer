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

            FileModel fModel = new FileModel() {
                Name = "test file.txt",
                Path = "idk",
                DateCreated= DateTime.Now,
                DateModified= DateTime.Now,
                Type = FileType.File,
                SizeBytes= 2194242,
            };

            Model.AddFile(new FilesControl(fModel));
            Model.AddFile(new FilesControl(fModel));
            Model.AddFile(new FilesControl(fModel));
        }
    }
}
