using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem;

namespace LibraryManagementSystem.Interfaces.Data
{
    public interface IBookData
    {
        public IEnumerable<Book> SelectAllOfAvailable(int libraryId);
        public IEnumerable<Book> SelectAllOfAvailable(LibDataModel library);
        public IEnumerable<Book> SelectAllOfBorrowed(int libraryId);
        public IEnumerable<Book> SelectAllOfBorrowed(LibDataModel library);
    }
}
