using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Logic.Interfaces
{
    public interface IContainerManagement
    {
        public void Add(Func<Task> show = null,
            Func<Task> close = null,
            Func<Task> hide = null);
        public void Remove();
    }
}
