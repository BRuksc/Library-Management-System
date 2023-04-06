using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Database
{
    internal interface IDbTable<T>
    {
        public T ExecuteLibraries();
        public T ExecuteAdmins();
        public T ExecuteWorkers();
        public T ExecuteUsers();
        public T ExecuteBooks();
        public T ExecuteLoans();
    }
}
