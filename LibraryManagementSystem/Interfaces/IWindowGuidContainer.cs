using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces
{
    public interface IWindowGuidContainer
    {
        public Guid LibraryManagementWindow { get; }
    }
}
