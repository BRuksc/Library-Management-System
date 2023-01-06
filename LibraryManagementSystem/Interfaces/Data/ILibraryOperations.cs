using LibraryManagementSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Data
{
    internal interface ILibraryOperations<T>
    {
        public ICollection<T> SelectAll(int LibraryId);
        public ICollection<T> SelectAll(LibDataModel libDataModel);
        public Task<bool> RemoveMany(T[] data);
    }
}
