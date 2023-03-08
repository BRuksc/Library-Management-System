using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.MVVM.Models.ManagementSystem;
using LibraryManagementSystem.MVVM.Views.ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem
{
    public abstract partial class AdminWorkerBaseViewModel : BasicViewModel
    {
        public dynamic Model { get => model; }
        protected dynamic model { get; set; }
        public LibDataModel Library
        {
            get => model.Library;
            set
            {
                model.Library = value;
                OnPropertyChanged(nameof(Library));
            }
        }

        public string WindowTitle
        {
            get => model.WindowTitle;
            set
            {
                model.WindowTitle = value;
                OnPropertyChanged(nameof(WindowTitle));
            }
        }

        public TabItem TabSelected
        {
            get => model.TabSelected;
            set
            {
                model.TabSelected = value;
                OnPropertyChanged(nameof(TabSelected));
            }
        }

        public List<User> Users
        {
            get => model.Users;
            set
            {
                model.Users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public List<Loan> Loans
        {
            get => model.Loans;
            set
            {
                model.Loans = value;
                OnPropertyChanged(nameof(Loans));
            }
        }

        public List<Book> Books
        {
            get => model.Books;
            set
            {
                model.Books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public List<Book> AvailableBooks
        {
            get => model.AvailableBooks; set
            {
                model.AvailableBooks = value;
                OnPropertyChanged(nameof(AvailableBooks));
            }
        }

        public List<Book> BorrowedBooks
        {
            get => model.BorrowedBooks;
            set
            {
                model.BorrowedBooks = value;
                OnPropertyChanged(nameof(BorrowedBooks));
            }
        }
    }
}
