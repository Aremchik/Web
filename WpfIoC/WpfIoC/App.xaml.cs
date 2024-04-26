using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfIoC.Interfaces;
using WpfIoC.ViewModels;

namespace WpfIoC
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
{
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new MainWindow
            {
                DataContext = new MainViewModel
                {
                    PageViewModels = new List<IPageViewModel>
                {
                    new Page1ViewModel(),
                    new Page2ViewModel()
                }
                }
            }.Show();
        }
    }
}
