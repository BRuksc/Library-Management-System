using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels
{
    public class AddingBooksModel : BaseAddingModel
    {
        #region Properties
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string DateOfPublished { get; set; } = String.Empty;
        #endregion

        #region Methods
        public AddingBooksModel(AdminViewModel viewmodel) : base(viewmodel)
        {
            Title = "Test";
            Author = "Test";
            DateOfPublished = "01-01-2001";
            IsOne = true;
        }

        public AddingBooksModel(WorkerViewModel viewmodel) : base(viewmodel)
        {
            Title = "Test";
            Author = "Test";
            DateOfPublished = "01-01-2001";
            IsOne = true;
        }

        public override async Task<bool> Add()
        {
            try
            {
                if (IsOne)
                {
                    await new BooksDataManager().Add(new Book()
                    {
                        Title = this.Title,
                        Author = this.Author,
                        DateOfPublished = Convert.ToDateTime(this.DateOfPublished),
                        LibraryId = BasicVM.Library.Id
                    });
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

                BasicVM.OnPropertyChanged(nameof(BasicVM.Books));

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
