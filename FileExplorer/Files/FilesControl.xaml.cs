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

namespace FileExplorer.Files {
    /// <summary>
    /// FilesControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FilesControl : UserControl {

        public FileModel File {
            get => this.DataContext as FileModel;
            set => this.DataContext = value;
        }

        public Action<FileModel> NavigateToPathCallback { get; set; }

        public FilesControl() {
            InitializeComponent();
            File= new FileModel();
        }

        public FilesControl(FileModel fModel) {
            InitializeComponent();
            File= fModel;
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if(e.ChangedButton == MouseButton.Left && 
               e.LeftButton == MouseButtonState.Pressed &&
               e.ClickCount == 2) {
                NavigateToPathCallback?.Invoke(File);
            }
        }


        private void UserControl_KeyDown(object sender, System.Windows.Input.KeyboardEventArgs e) {
        
        }
    }
}
