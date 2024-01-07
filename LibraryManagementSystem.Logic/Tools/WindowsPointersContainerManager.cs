using LibraryManagementSystem.Logic.Interfaces;
using LibraryManagementSystem.WindowsPointing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Logic.Tools
{
    public class WindowsPointersContainerManager<T> : IContainerManagement
    {
        private readonly IList<IWindowPointing> windowPointings;
        private readonly Autofac.IContainer container;

        public WindowsPointersContainerManager(Autofac.IContainer container,
            IList<IWindowPointing> windowPointings)
        {
            this.container = container;
            this.windowPointings = windowPointings;
        }

        public void Add(
            Func<Task> show = null,
            Func<Task> close = null,
            Func<Task> hide = null
            )
        {
            using (var scope = container.BeginLifetimeScope())
            {
                
            }
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
