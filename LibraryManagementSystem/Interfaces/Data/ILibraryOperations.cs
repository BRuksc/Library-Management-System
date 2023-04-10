using LibraryManagementSystem.DataModels;
using System.Collections.Generic;

namespace LibraryManagementSystem.Interfaces.Data
{
    public interface ILibraryOperations<T>
    {
        public ICollection<T> SelectAll(int LibraryId);
        public ICollection<T> SelectAll(LibDataModel libDataModel);
        public System.Threading.Tasks.Task<bool> RemoveMany(T[] data);
    }
}
