using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WindowsParty.ViewModel;

namespace WindowsParty
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var locator = (ViewModelLocator)Resources["Locator"];
            var ps = locator.PagingService;
            ps.ShowLogin();
        }
    }
}
