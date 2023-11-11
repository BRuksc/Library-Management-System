using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.Logic.UI.Interfaces
{
    internal interface IOptions
    {
        public ICommand Select { get; }
        public ICommand Remove { get; }
        public ICommand Edit { get; }
        public ICommand Add { get; }
    }
}
