using Rent.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Authorization";
        public string Title 
        { 
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
