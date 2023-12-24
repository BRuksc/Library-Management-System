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

        private readonly IWindowGuidContainer windowGuidContainer;

        public WindowPointersCollection(IWindowGuidContainer windowGuidContainer)
        { 
            windowPointers = new List<WindowPointer>();
            this.windowGuidContainer = windowGuidContainer;
        }

        public async Task AddAsync(Guid guid, Func<Task> run, Func<Task> close, Func<Task> hide) => 
            Add(guid, run, close, hide);

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

        public void Add(Guid guid, Func<Task> run, Func<Task> close, Func<Task> hide)
        {
            try
            {
                if (guid == windowGuidContainer.LibraryManagementWindow)
                {
                    throw new Exception("LibrariesManagementWindow can be initialize only once!");
                }

                var windowPointer = new WindowPointer
                    (run.Invoke(), close.Invoke(), hide.Invoke(), guid);
            }

            catch (Exception ex) 
            { 
                
            }
        }
    }
}
