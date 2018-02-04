/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WindowsParty"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WindowsParty.Services;
using WindowsParty.Services.Impl;

namespace WindowsParty.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ITesonetApiService, TesonetApiService>();
            SimpleIoc.Default.Register<IPagingService, PagingService>();
            SimpleIoc.Default.Register<ILogService, LogService>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<ServersViewModel>();
        }


        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();
        public ServersViewModel ServersViewModel => ServiceLocator.Current.GetInstance<ServersViewModel>();
        public IPagingService PagingService => ServiceLocator.Current.GetInstance<IPagingService>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}