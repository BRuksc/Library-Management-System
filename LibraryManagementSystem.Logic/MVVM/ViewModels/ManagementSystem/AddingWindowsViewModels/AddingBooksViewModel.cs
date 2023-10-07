using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels;
using LibraryManagementSystem.Tools;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels
{
    internal class AddingBooksViewModel : BaseAddingViewModel<AddingBooksModel>
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

        public override bool IsOne
        {
            get => model.IsOne;
            set
            {
                model.IsOne = value;
                OnPropertyChanged(nameof(model.IsOne));
            }
        }
        public override bool IsMany
        {
            get => model.IsMany;
            set
            {
                model.IsMany = value;
                OnPropertyChanged(nameof(IsMany));
            }
        }
        public override string ManyValue
        {
            get => model.ManyValue;
            set
            {
                model.ManyValue = value;
                OnPropertyChanged(nameof(ManyValue));
            }
        }
        public override bool ManyValueActive
        {
            get => model.ManyValueActive;
            set
            {
                model.ManyValueActive = value;
                OnPropertyChanged(nameof(ManyValueActive));
            }
        }
        public override ICommand Add
        {
            get
            {
                return add;
            }
        }

        public AddingBooksViewModel(AdminViewModel viewmodel)
        {
            model = new AddingBooksModel(viewmodel);
        }
    }
}
