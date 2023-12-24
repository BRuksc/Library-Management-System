using LibraryManagementSystem.Data.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Interfaces
{
    public interface ILibraryOperations<T>
    {
        public ICollection<T> SelectAll(int LibraryId);
        public ICollection<T> SelectAll(LibDataModel libDataModel);
        public Task<bool> RemoveMany(T[] data);
    }
}
