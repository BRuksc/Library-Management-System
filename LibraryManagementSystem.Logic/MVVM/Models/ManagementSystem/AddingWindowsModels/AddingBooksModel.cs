using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem;

namespace LibraryManagementSystem.Logic.MVVM.Models.ManagementSystem.AddingWindowsModels
{
    public class AddingBooksModel : BaseAddingModel, IViewModelsTypes
    {
        #region Properties
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string DateOfPublished { get; set; } = String.Empty;
        public AdminViewModel? AdminVM { get; set; } = null;
        LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AdminViewModel? IViewModelsTypes.AdminVM { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
