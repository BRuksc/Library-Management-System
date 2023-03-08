using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Data
{
    //T is collection type

    internal interface IDataWinLibWorkers<B,L,U>
    {
        public U Users { get; }
        public L Loans { get; }
        public B Books { get; }
        public B AvailableBooks { get; }
        public B BorrowedBooks { get; }
    }
}
