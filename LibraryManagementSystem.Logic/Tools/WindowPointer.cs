using LibraryManagementSystem.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;

namespace LibraryManagementSystem.Logic.Tools
{
    public class WindowPointer<T> : IWindowPointing
    {
        private readonly Guid windowTypeGuid;
        private readonly T window;

        public WindowPointer(T window, Guid windowTypeGuid)
        {
            this.window = window;
            this.windowTypeGuid = windowTypeGuid;
        }

        public void Close()
        {
            (window as Window).Close();
        }

        public void Run()
        {
            (window as Window).Close();
        }
    }
}
