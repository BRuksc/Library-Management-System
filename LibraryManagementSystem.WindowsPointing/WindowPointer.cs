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
        private readonly Func<Task> hide;

        public Func<Task> Close => () => close();
        public Func<Task> Run => () => close();

        private Guid windowGuid;
        public Guid WindowGuid => windowGuid;

        public Func<Task> Hide => hide;

        public WindowPointer(Func<Task> run, Func<Task> close, Func<Task> hide, Guid windowGuid)
        {
            this.windowGuid = windowGuid;
            this.run = run;
            this.close = close;
            this.hide = hide;
        }

        public bool SetWindowGuid(Guid windowGuid)
        {
            try
            {
                if (windowGuid == null)
                {
                    throw new ArgumentNullException(nameof(windowGuid));
                }

                this.windowGuid = windowGuid;
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
