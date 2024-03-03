using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Logic.Interfaces
{
    public interface ILibraryManagementWindowOperations
    {
        public DelegateCommand Open { get; set; }
        public DelegateCommand Create { get; set; }
        public DelegateCommand JoinFromServer { get; set; }
    }
}
