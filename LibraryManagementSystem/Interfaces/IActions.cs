using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.AddingViewsAdapter.Interfaces
{
    internal interface IActions
    {
        public Task<bool> ShowWindow();
        public Task<bool> CloseWindow();
    }
}
