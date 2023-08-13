using LibraryManagementSystem.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Data
{
    public interface ILibraryOperations<T>
    {
        public ICollection<T> SelectAll(int LibraryId);
        public ICollection<T> SelectAll(LibDataModel libDataModel);
        public Task<bool> RemoveMany(T[] data);
    }
}
