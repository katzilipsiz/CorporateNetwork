using CorporationNetworkWPF.Models;
using System.Windows;

namespace CorporateNetworkWPF.Dialogs
{
    public partial class DepartmentDialog : Window
    {
        public CreateDepartmentDto Department { get; } = new CreateDepartmentDto();

        public DepartmentDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}