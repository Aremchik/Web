using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand NavigateToPage1Command { get; }
        public ICommand NavigateToPage2Command { get; }
        public object CurrentPage { get; set; }

        public MainViewModel()
        {
            NavigateToPage1Command = new RelayCommand(NavigateToPage1);
            NavigateToPage2Command = new RelayCommand(NavigateToPage2);
        }

        private void NavigateToPage1()
        {
            CurrentPage = new Page1();
        }

        private void NavigateToPage2()
        {
            CurrentPage = new Uri("Page2.xaml", UriKind.Relative);
        }
    }
}
