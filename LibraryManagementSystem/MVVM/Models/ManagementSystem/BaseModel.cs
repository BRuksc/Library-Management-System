using LibraryManagementSystem.DataModels;
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

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem
{
    public abstract class BaseModel
    {
        public LibDataModel Library { get; set; }

        public string WindowTitle { get; set; } = String.Empty;
        protected string TabSelectedBeforeAdd { get; set; } = "Users";

        protected TabItem tabSelected = new TabItem() { Header = (object)"Users" };

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
        public List<User> Users { get; set; } = new List<User>();
        public List<Loan> Loans { get; set; } = new List<Loan>();
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Book> AvailableBooks { get; set; } = new List<Book>();
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public BaseModel(LibDataModel library)
        {
            Users = new UsersDataManager().SelectAll(library);
            Loans = new LoanDataManager().SelectAll(library);
            Books = new BooksDataManager().SelectAll(library).ToList();

            this.Library = library;
        }

        public async Task AddTab1()
        {
            if (TabSelectedBeforeAdd == "Users")
                new AddUsersWindow().Show();

            else new AddLoansWindow().Show();
        }

        public abstract Task AddTab2(dynamic viewmodel);
    }
}
