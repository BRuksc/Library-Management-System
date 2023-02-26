﻿using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Interfaces.Data;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem
{
    public abstract class BaseModel : IDataWinLibWorkers<List<Book>, List<Loan>, List<User>>, IBooksCollectionsChangeAsync<Task>
    {
        public LibDataModel Library { get; protected set; }

        public string WindowTitle { get; set; } = String.Empty;
        protected string TabSelectedBeforeAdd { get; set; } = "Users";

        protected TabItem tabSelected = new TabItem() { Header = (object)"Users" };

        protected readonly BooksDataManager booksDataManager;
        protected readonly UsersDataManager usersDataManager;
        protected readonly LoanDataManager loanDataManager;

        public TabItem TabSelected
        {
            get => tabSelected;
            set
            {
                tabSelected = value;
                if (tabSelected.Header.ToString() != "+")
                    TabSelectedBeforeAdd = (string)tabSelected.Header;
            }
        }
        #region Collections
        public List<User> Users { get; set; } = new List<User>();
        public List<Loan> Loans { get; set; } = new List<Loan>();
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Book> AvailableBooks { get; set; } = new List<Book>();
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        #endregion

        public BaseModel(LibDataModel library)
        {
            this.booksDataManager = new BooksDataManager();
            this.usersDataManager = new UsersDataManager();
            this.loanDataManager = new LoanDataManager();

            Users = usersDataManager.SelectAll(library);
            Loans = loanDataManager.SelectAll(library);
            Books = booksDataManager.SelectAll(library).ToList();

            this.Library = library;
        }

        public async Task AddTab1()
        {
            if (TabSelectedBeforeAdd == "Users")
                new AddUsersWindow().Show();

            else new AddLoansWindow().Show();
        }

        public abstract Task AddTab2(dynamic viewmodel);

        public async Task AllOfBooksChanged()
        {
            Books = booksDataManager.SelectAll(Library.Id).ToList();
        }

        public async Task BorrowedBooksChanged()
        {
            BorrowedBooks = booksDataManager.SelectAllOfBorrowed(Library.Id).ToList();
        }

        public async Task AvailableBooksChanged()
        {
            AvailableBooks = booksDataManager.SelectAllOfAvailable(Library.Id).ToList();
        }
    }
}
