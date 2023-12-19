using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem.Interfaces.UI
{
    public interface IWindowPointing
    {
        public Func<Task> Run { get; }
        public Func<Task> Close { get; }
    }
}
