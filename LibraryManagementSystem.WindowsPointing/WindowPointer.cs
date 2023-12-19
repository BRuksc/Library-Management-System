using LibraryManagementSystem.WindowsPointing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem.WindowsPointing
{
    public class WindowPointer : IWindowPointing
    {
        private readonly Func<Task> close;
        private readonly Func<Task> run;

        public Func<Task> Close => () => close();
        public Func<Task> Run => () => close();

        private readonly Guid windowGuid;
        public Guid WindowGuid => windowGuid;

        public WindowPointer(Task run, Task close, Guid windowGuid)
        {
            this.windowGuid = windowGuid;

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
