using System.Windows;

namespace CorporateNetworkWPF.Dialogs
{
    public partial class InputDialog : Window
    {
        public string Answer { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }

        public InputDialog(string title, string prompt)
        {
            InitializeComponent();
            Title = title;
            Prompt = prompt;
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}