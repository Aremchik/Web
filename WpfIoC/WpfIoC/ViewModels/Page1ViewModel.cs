using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfIoC.Common;
using WpfIoC.Interfaces;

namespace WpfIoC.ViewModels
{
    public class Page1ViewModel : NotifyPropertyChanged, IPageViewModel
    {
        public string Title => "Page1";
        public string Text => "Page one";
    }
}
