using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels
{
    public class AddingBooksModel : BaseAddingModel, IViewModelsTypes
    {
        #region Properties
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string DateOfPublished { get; set; } = String.Empty;
        public AdminViewModel? AdminVM { get; set; } = null;
        public WorkerViewModel? WorkerVM { get; set; } = null;
        #endregion

        #region Methods
        public AddingBooksModel(AdminViewModel viewmodel)
        {
            Title = "Test";
            Author = "Test";
            DateOfPublished = "01-01-2001";
            IsOne = true;

            AdminVM = viewmodel;
        }

        public AddingBooksModel(WorkerViewModel viewmodel)
        {
            Title = "Test";
            Author = "Test";
            DateOfPublished = "01-01-2001";
            IsOne = true;

            WorkerVM = viewmodel;
        }

        public override async Task<bool> Add()
        {
            try
            {
                if (IsOne)
                {
                    if (AdminVM != null)
                    {
                        await new BooksDataManager().Add(new Book()
                        {
                            Title = this.Title,
                            Author = this.Author,
                            DateOfPublished = Convert.ToDateTime(this.DateOfPublished),
                            LibraryId = AdminVM.Library.Id
                        });
                    }

                    if (WorkerVM != null)
                    {
                        await new BooksDataManager().Add(new Book()
                        {
                            Title = this.Title,
                            Author = this.Author,
                            DateOfPublished = Convert.ToDateTime(this.DateOfPublished),
                            LibraryId = WorkerVM.Library.Id
                        });
                    }
                }

                else
                {
                    var books = new Book[Convert.ToInt32(ManyValue)];

                    foreach (var i in books)
                    {
                        i.Title = this.Title;
                        i.Author = this.Author;
                        i.DateOfPublished = Convert.ToDateTime(this.DateOfPublished);
                    }

                    await new BooksDataManager().AddMany(books);
                }

                if (AdminVM != null)
                {
                    AdminVM.OnPropertyChanged(nameof(AdminVM.Books));
                    AdminVM.OnPropertyChanged(nameof(AdminVM.BorrowedBooks));
                    AdminVM.OnPropertyChanged(nameof(AdminVM.AvailableBooks));
                }

                if (WorkerVM != null)
                {
                    WorkerVM.OnPropertyChanged(nameof(WorkerVM.Books));
                    WorkerVM.OnPropertyChanged(nameof(WorkerVM.BorrowedBooks));
                    WorkerVM.OnPropertyChanged(nameof(WorkerVM.AvailableBooks));
                }

                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
