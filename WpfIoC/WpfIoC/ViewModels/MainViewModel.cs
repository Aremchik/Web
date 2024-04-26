using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfIoC.Common;
using WpfIoC.Interfaces;

namespace WpfIoC.ViewModels
{
    public class MainViewModel : NotifyPropertyChanged
    {
        private IPageViewModel _selectedPageViewModel;
        private IList<IPageViewModel> _pageViewModels;

        public string Title => $"MultiPage demo - {SelectedPageViewModel?.Title}";

        public IList<IPageViewModel> PageViewModels
        {
            get => _pageViewModels;
            set
            {
                _pageViewModels = value;
                OnPropertyChanged();
            }
        }

        public IPageViewModel SelectedPageViewModel
        {
            get => _selectedPageViewModel;
            set
            {
                _selectedPageViewModel = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
            }
        }
    }
}
