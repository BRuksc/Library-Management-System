using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels;
using LibraryManagementSystem.Tools;

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

        public AddingBooksViewModel(AdminViewModel viewmodel)
        {
            model = new AddingBooksModel(viewmodel);
        }

        public AddingBooksViewModel(WorkerViewModel viewmodel)
        {
            model = new AddingBooksModel(viewmodel);
        }
    }
}
