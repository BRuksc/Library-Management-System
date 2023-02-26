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
        public U Users { get; set; }
        public L Loans { get; set; }
        public B Books { get; set; }
        public B AvailableBooks { get; set; }
        public B BorrowedBooks { get; set; }
    }
}
