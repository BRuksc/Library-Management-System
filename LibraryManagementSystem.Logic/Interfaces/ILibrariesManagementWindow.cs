using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.Logic.Interfaces
{
    public interface ILibrariesManagementWindow
    {
        public ICommand Open { get; }
        public ICommand Create { get; }
        public ICommand JoinFromServer { get; }
    }
}
