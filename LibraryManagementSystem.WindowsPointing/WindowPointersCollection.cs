using LibraryManagementSystem.WindowsPointing.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.WindowsPointing
{
    public class WindowPointersCollection : IValidatingCollection<WindowPointer>
    {
        private readonly IList<WindowPointer> windowPointers;
        public IEnumerable<WindowPointer> WindowPointers => windowPointers;

        public WindowPointersCollection() 
        { 
            windowPointers = new List<WindowPointer>();
        }

        public Task AddAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<WindowPointer> GetEnumerator()
        {
            return WindowPointers.GetEnumerator();
        }

        public void Remove(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid guid) => Remove(guid);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
