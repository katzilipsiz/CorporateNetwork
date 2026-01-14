using CorporationNetworkWPF.Models;
using System.Collections.Generic;
using System.Windows;

namespace CorporateNetworkWPF.Dialogs
{
    public partial class EmployeeDialog : Window
    {
        public CreateEmployeeDto Employee { get; } = new CreateEmployeeDto();

        public EmployeeDialog(List<Position> positions, List<Department> departments)
        {
            InitializeComponent();
            DataContext = this;

            // Здесь можно использовать positions и departments для ComboBox
            // но для простоты оставим текстовые поля
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}