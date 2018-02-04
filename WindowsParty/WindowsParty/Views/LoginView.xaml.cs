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

namespace WpfTests.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var template = PassBox.Template;
            var myControl = (TextBlock)template.FindName("passHint", PassBox);
            myControl.Visibility = PassBox.Password.Length == 0 ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
