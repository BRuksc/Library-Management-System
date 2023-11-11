using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewsAdapter.Interfaces
{
    public interface IActions<T>
    {
        public T View { get; }
        public void Show();
        public void Close();
    }
}
