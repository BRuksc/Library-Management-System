using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyModel;

namespace LibraryManagementSystem.DataManagers
{
    public class BooksDataManager : IDataManagement<Book>, IManyRecordsOperations<Book>, IBookData
    {
        public async Task<bool> Add(Book data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    dataContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Books ON");

                    data.Id = dataContext.Books.ToList().Count + 1;
                    dataContext.Add(data);

                    dataContext.SaveChanges();
                    await dataContext.Database.CloseConnectionAsync();
                }

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddMany(Book[] data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();

                    foreach (var i in data)
                        books.Add(i);

                    await dataContext.SaveChangesAsync();
                    await dataContext.Database.CloseConnectionAsync();
                }

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Task<bool> Edit(Book oldData, Book newData)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int Id)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Loans.ToList();
                    var dataModel = books.Where(x => x.Id == Id).First();

                    books.Remove(dataModel);

                    await dataContext.SaveChangesAsync();
                    await dataContext.Database.CloseConnectionAsync();
                }

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> Remove(Book data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();
                    books.Remove(data);

                    foreach (var i in books)
                    {
                        if (i.Id > data.Id)
                            i.Id--;
                    }

                    await dataContext.SaveChangesAsync();
                    await dataContext.Database.CloseConnectionAsync();
                }

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Task<bool> RemoveMany(Book[] data)
        {
            throw new NotImplementedException();
        }

        public Book Select(Book data)
        {
            try
            {
                var book = new Book();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();
                    book = books.First(x => x == data);

                    dataContext.SaveChangesAsync();
                    dataContext.Database.CloseConnectionAsync();
                }

                return book;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Book> SelectAll(int LibraryId)
        {
            try
            {
                var books = new List<Book>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var allOfBooks = dataContext.Books.ToList();
                    books = (List<Book>)allOfBooks.Where(x => x.LibraryId == LibraryId);

                    dataContext.Database.CloseConnection();
                }

                return books;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Book> SelectAll(LibDataModel library)
        {
            try
            {
                IEnumerable<Book> books;

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var allOfBooks = dataContext.Books.ToList();
                    books = dataContext.Books.ToList().Where(x => x.LibraryId == library.Id);

                    dataContext.Database.CloseConnection();
                }

                return books;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Book> SelectAllOfAvailable(int libraryId)
        {
            try
            {
                var availableBooks = new List<Book>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();
                    availableBooks = (List<Book>)books.Where(x => 
                        (!x.IsBorrowed) && (x.LibraryId == libraryId));

                    dataContext.Database.CloseConnectionAsync();
                }

                return availableBooks;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Book> SelectAllOfAvailable(LibDataModel library)
        {
            try
            {
                var availableBooks = new List<Book>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();
                    availableBooks = (List<Book>)books.Where(x =>
                        (!x.IsBorrowed) && (x.LibraryId == library.Id));

                    dataContext.Database.CloseConnectionAsync();
                }

                return availableBooks;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Book> SelectAllOfBorrowed(int libraryId)
        {
            try
            {
                var borrowedBooks = new List<Book>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();
                    borrowedBooks = (List<Book>)books.Where(x => x.IsBorrowed && 
                        (x.LibraryId == libraryId));

                    dataContext.Database.CloseConnectionAsync();
                }

                return borrowedBooks;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Book> SelectAllOfBorrowed(LibDataModel library)
        {
            try
            {
                var borrowedBooks = new List<Book>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();
                    borrowedBooks = (List<Book>)books.Where(x => x.IsBorrowed &&
                        (x.LibraryId == library.Id));

                    dataContext.Database.CloseConnectionAsync();
                }

                return borrowedBooks;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public Book SelectById(int Id)
        {
            try
            {
                var book = new Book();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var books = dataContext.Books.ToList();
                    book = books.First(x => x.Id == Id);

                    dataContext.Database.CloseConnectionAsync();
                }

                return book;
            }


            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
