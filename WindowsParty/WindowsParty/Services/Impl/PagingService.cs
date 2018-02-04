using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsParty.ViewModel;
using WpfTests.Views;

namespace WindowsParty.Services.Impl
{
    public class PagingService : IPagingService
    {

        public LoginView loginView { get; set; }
        public ServersView serversView { get; set; }
        public MainWindow mainWindow { get; set; }

        public PagingService()
        {
            loginView = new LoginView();
            serversView = new ServersView();
        }

        public void ShowLogin()
        {
            if (mainWindow == null)
                mainWindow = new MainWindow();
            mainWindow.Content = loginView;
            mainWindow.DataContext = (Application.Current.Resources["Locator"] as ViewModelLocator).LoginViewModel;

            mainWindow.Show();
        }

        public void ShowServers()
        {
            if (mainWindow == null)
                mainWindow = new MainWindow();
            mainWindow.Content = serversView;
            mainWindow.DataContext = (Application.Current.Resources["Locator"] as ViewModelLocator).ServersViewModel;

            mainWindow.Show();
        }
    }
}
