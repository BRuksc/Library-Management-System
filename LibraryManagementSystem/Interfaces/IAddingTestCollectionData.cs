using LibraryManagementSystem.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces
{
    public interface IAddingTestCollectionData<T> where T : class
    {
        public void AddingTestAdminsCollection(ref IList<T> collection, uint numberOfRecords);
    }
}
