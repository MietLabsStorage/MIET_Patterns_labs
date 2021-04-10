using MVVM.ViewModel;
using System.Windows;
using System.Windows.Data;

namespace MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

        private void OnButtonLeftClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowViewModel).OnClickLeft(sender, e);
        }

        private void OnButtonRightClick(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowViewModel).OnClickRight(sender, e);
        }
    }
}