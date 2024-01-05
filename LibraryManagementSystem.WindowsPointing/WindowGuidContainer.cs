using LibraryManagementSystem.WindowsPointing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.WindowsPointing
{
    public class WindowGuidContainer : IWindowGuidContainer
    {
        private readonly Guid libraryManagementWindow;
        private readonly Guid registerWindow;
        private readonly Guid loginWindow;

        public Guid LibraryManagementWindow => 
            libraryManagementWindow;

        public Guid RegisterWindow =>
            registerWindow;

        public Guid LoginWindow =>
            loginWindow;

        public WindowGuidContainer() 
        {
            libraryManagementWindow = 
                new Guid("0028EEEB-28F1-42E1-857B-EA527F88868A");
            registerWindow = 
                new Guid("8EB543C8-A516-40E6-9B1A-7EE01605B4BD");
            loginWindow =
                new Guid("94E4F44E-1E9B-44AA-8033-FEFA1655069C");
        }
    }
}
