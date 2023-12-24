using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Data.DataManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem;
using System.Windows;
using LibraryManagementSystem.Data.Interfaces;

namespace LibraryManagementSystem.Logic.MVVM.Models.ManagementSystem
{
    public abstract class BaseModel : IDataWinLibWorkers<List<Book>, List<Loan>, List<User>>, IAddRemove<Task>
    {
        public LibDataModel Library { get; protected set; }

        public string WindowTitle { get; set; } = String.Empty;
        protected string TabSelectedBeforeAdd { get; set; } = "Users";
        protected string Tab2SelectedBeforeAdd { get; set; } = "Books";

        protected TabItem tabSelected = new TabItem() { Header = (object)"Users" };
        protected TabItem tab2Selected = new TabItem() { Header = (object)"Books" };

        protected readonly BooksDataManager booksDataManager;
        protected readonly UsersDataManager usersDataManager;
        protected readonly LoanDataManager loanDataManager;

        public User? SelectedUser { get; set; }
        public Loan? SelectedLoans { get; set; }
        public Book? SelectedBooks { get; set; }
        public Book? SelectedBorrowedBooks { get; set; }
        public Book? SelectedAvailableBooks { get; set; }

        public TabItem TabSelected
        {
            get => tabSelected;
            set
            {
                tabSelected = value;
                if ((tabSelected.Header.ToString() != "+") && (tabSelected.Header.ToString() != "-"))
                    TabSelectedBeforeAdd = (string)tabSelected.Header;
            }
        }

        public TabItem Tab2Selected
        {
            get => tab2Selected;
            set
            {
                tab2Selected = value;
                if ((tab2Selected.Header.ToString() != "+") && (tab2Selected.Header.ToString() != "-"))
                    Tab2SelectedBeforeAdd = (string)tab2Selected.Header;
            }
        }

        #region Collections
        public List<User> Users { get => usersDataManager.SelectAll(Library.Id); }
        public List<Loan> Loans { get => loanDataManager.SelectAll(Library.Id); }
        public List<Book> Books { get => booksDataManager.SelectAll(Library.Id).ToList(); }
        public List<Book> AvailableBooks { get => booksDataManager.SelectAllOfAvailable(Library.Id).ToList(); }
        public List<Book> BorrowedBooks { get => booksDataManager.SelectAllOfBorrowed(Library.Id).ToList(); }
        #endregion

        public BaseModel(LibDataModel library)
        {
            this.booksDataManager = new BooksDataManager();
            this.usersDataManager = new UsersDataManager();
            this.loanDataManager = new LoanDataManager();

            this.Library = library;
        }

        /*public async Task AddTab1()
        {
            if (TabSelectedBeforeAdd == "Users")
                new AddUsersWindow().Show();

            else new AddLoansWindow().Show();
        }*/

        public abstract Task AddTab1(dynamic viewmodel);

        public abstract Task AddTab2(dynamic viewmodel);

        public async Task RemoveTab1(dynamic viewmodel)
        {
            try
            {
                if (tabSelected.Header.ToString() == "Users")
                {
                    if (SelectedUser != null)
                    {
                        await usersDataManager.Remove(SelectedUser.Id);
                        viewmodel.OnPropertyChanged(viewmodel.Users);
                    }
                }

                else if (tabSelected.Header.ToString() == "Loans")
                {
                    if (SelectedLoans != null)
                    {
                        await loanDataManager.Remove(SelectedLoans.Id);
                        SelectedLoans = null;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task RemoveTab2(dynamic viewmodel)
        {
            try
            {
                if (tab2Selected.Header.ToString() == "Books")
                {
                    if (SelectedUser != null)
                    {
                        await booksDataManager.Remove(SelectedUser.Id);
                        viewmodel.OnPropertyChanged(nameof(viewmodel.Tab2Selected));
                        viewmodel.OnPropertyChanged(nameof(viewmodel.Books));
                        viewmodel.OnPropertyChanged(nameof(viewmodel.AvailableBooks));
                        viewmodel.OnPropertyChanged(nameof(viewmodel.BorrowedBooks));
                    }
                }

                else if (tab2Selected.Header.ToString() == "Available books")
                {
                    var book = booksDataManager.SelectById(SelectedAvailableBooks.Id);
                    book.IsBorrowed = false;
                    await booksDataManager.Edit(booksDataManager.SelectById(SelectedAvailableBooks.Id), book);
                    refreshTab2(viewmodel);
                }

                else if (tab2Selected.Header.ToString() == "Borrowed books")
                {
                    var book = booksDataManager.SelectById(SelectedBorrowedBooks.Id);
                    book.IsBorrowed = false;
                    await booksDataManager.Edit(booksDataManager.SelectById(SelectedBorrowedBooks.Id), book);
                    refreshTab2(viewmodel);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshTab2(dynamic viewmodel)
        {
            viewmodel.OnPropertyChanged(nameof(viewmodel.Tab2Selected));
            viewmodel.OnPropertyChanged(nameof(viewmodel.Books));
            viewmodel.OnPropertyChanged(nameof(viewmodel.AvailableBooks));
            viewmodel.OnPropertyChanged(nameof(viewmodel.BorrowedBooks));
        }
    }
}
