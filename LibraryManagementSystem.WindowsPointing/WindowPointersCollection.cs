using LibraryManagementSystem.WindowsPointing.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.WindowsPointing
{
    public class WindowPointersCollection<T> : IValidatingCollection<T>
    {
        private readonly IList<T> collection;
        public IEnumerable<T> Collection => collection;

        private readonly IWindowGuidContainer windowGuidContainer;

        public WindowPointersCollection(IWindowGuidContainer windowGuidContainer)
        { 
            collection  = new List<T>();
            this.windowGuidContainer = windowGuidContainer;
        }

        public async Task AddAsync(T windowPointer) => 
            Add(windowPointer);
        public void Remove(T obj) => collection.Remove(obj);

        public async Task RemoveAsync(T obj) => Remove(obj);

        public void Add(T obj)
        {
            try
            {
                collection.Add(obj);
            }

            catch (Exception ex) 
            { 
                
            }
        }

        public IEnumerator<T> GetEnumerator() => Collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Collection.GetEnumerator();
    }
}
