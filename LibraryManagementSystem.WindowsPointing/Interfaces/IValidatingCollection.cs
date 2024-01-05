using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.WindowsPointing.Interfaces
{
    public interface IValidatingCollection<T> : IEnumerable<T>
    {
        public IEnumerable<T> Collection { get; }
        public IEnumerator<T> GetEnumerator();
        public void Add(T obj);
        public Task AddAsync(T obj);
        public void Remove(T obj);
        public Task RemoveAsync(T obj);
    }
}
