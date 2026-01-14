using CorporationNetworkWPF.ViewModels;
using System.Windows;

namespace CorporateNetworkWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}