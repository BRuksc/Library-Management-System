using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem.WindowsPointing.Interfaces
{
    public interface IWindowPointing
    {
        public Func<Task> Run { get; }
        public Func<Task> Close { get; }
        public Func<Task> Hide { get; }
        public Guid WindowGuid { get; }
        public bool SetWindowGuid(Guid windowGuid);
    }
}
