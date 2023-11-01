using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Logic.MVVM.Models.ManagementSystem;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.MVVM.Views.ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem
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

        public TabItem Tab2Selected
        {
            get => model.Tab2Selected;
            set
            {
                model.Tab2Selected = value;
                OnPropertyChanged(nameof(Tab2Selected));
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

        public User? SelectedUsers
        {
            get => model.SelectedUsers;

            set
            {
                model.SelectedUser = value;
                OnPropertyChanged(nameof(SelectedUsers));
            }
        }

        public Loan? SelectedLoans
        {
            get => model.SelectedLoans;
            set
            {
                model.SelectedLoans = value;
                OnPropertyChanged(nameof(SelectedLoans));
            }
        }

        public Book? SelectedBooks
        {
            get => model.SelectedBooks; 
            set
            {
                model.SelectedBooks = value;
                OnPropertyChanged(nameof(SelectedBooks));
            }
        }

        public Book? SelectedBorrowedBooks
        {
            get => model.SelectedBorrowedBooks; 
            set
            {
                model.SelectedBorrowedBooks = value;
                OnPropertyChanged(nameof(SelectedBorrowedBooks));
            }
        }

        public Book? SelectedAvailableBooks
        {
            get => model.SelectedAvailableBooks; 
            set
            {
                model.SelectedAvailableBooks = value;
                OnPropertyChanged(nameof(SelectedAvailableBooks));
            }
        }
    }
}
