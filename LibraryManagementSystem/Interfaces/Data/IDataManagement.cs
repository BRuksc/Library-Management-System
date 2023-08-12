using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Data
{
    public interface IDataManagement<T>
    {
        public T SelectById(int Id);
        public Task<bool> Add(T data);
        public Task<bool> Remove(int Id);
        public Task<bool> Remove(T data);
        public Task<bool> Edit(T oldData, T newData);
        public T Select(T data);
    }
}
