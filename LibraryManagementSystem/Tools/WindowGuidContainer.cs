using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tools
{
    public class WindowGuidContainer : IWindowGuidContainer
    {
        private readonly Guid libraryManagementWindow;

        public Guid LibraryManagementWindow => 
            libraryManagementWindow;

        public WindowGuidContainer() 
        {
            libraryManagementWindow = new Guid("0028EEEB-28F1-42E1-857B-EA527F88868A");
        }
    }
}
