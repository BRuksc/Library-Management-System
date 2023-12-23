using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.WindowsPointing.Interfaces
{
    public interface IValidatingCollection<T> : IEnumerable<T>
    {
        public IEnumerable<T> WindowPointers { get; }
        public IEnumerator<T> GetEnumerator();
        public void Add(Guid guid, Func<Task> run, Func<Task> close, Func<Task> hide);
        public Task AddAsync(Guid guid, Func<Task> run, Func<Task> close, Func<Task> hide);
        public void Remove(Guid guid);
        public Task RemoveAsync(Guid guid);
    }
}
