using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels
{
    internal class AddingBooksViewModel : BaseAddingViewModel
    {
        public string Title
        {
            get => model.Title;
            set
            {
                model.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Author
        {
            get => model.Author;
            set
            {
                model.Author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public string DateOfPublished
        {
            get => model.DateOfPublished; 
            set
            {
                model.DateOfPublished = value;
                OnPropertyChanged(nameof(DateOfPublished));
            }
        }

        public AddingBooksViewModel()
        {
            model = new AddingBooksModel();
        }

        public override ICommand Add
        {
            get
            {
                return add;
            }
        }
    }
}
