using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Data
{
    internal interface IBookData
    {
        public List<Book> SelectAllOfAvailable(int libraryId);
        public List<Book> SelectAllOfAvailable(LibDataModel library);
        public List<Book> SelectAllOfBorrowed(int libraryId);
        public List<Book> SelectAllOfBorrowed(LibDataModel library);
    }
}
