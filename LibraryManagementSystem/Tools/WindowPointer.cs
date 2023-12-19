using LibraryManagementSystem.Interfaces;
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
    public class WindowPointer : IWindowPointing
    {
        private readonly Func<Task> close;
        private readonly Func<Task> run;

        public Func<Task> Close => close.Invoke;

        public Func<Task> Run => close.Invoke;

        public WindowPointer(Task run, Task close)
        {
            this.run = () => 
            {
                run.Start();
                return Task.CompletedTask;
            };

            this.close = () => 
            {
                close.Start();
                return Task.CompletedTask;
            };
        }
    }
}
