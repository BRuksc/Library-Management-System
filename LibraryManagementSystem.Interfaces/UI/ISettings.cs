using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.Interfaces.UI
{
    internal interface ISettings
    {
        public ICommand Add { get; }
        public ICommand Remove { get; }
        public ICommand Edit { get; }
    }
}
