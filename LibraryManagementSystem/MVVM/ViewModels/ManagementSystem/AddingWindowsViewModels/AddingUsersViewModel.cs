using LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels;
using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using LibraryManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels
{
    internal class AddingUsersViewModel : BaseAddingViewModel
    {
        #region Properties
        public string Email
        {
            get => model.Email;
            set
            {
                model.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Name
        {
            get => model.Name;
            set
            {
                model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => model.Surname;
            set
            {
                model.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Password
        {
            get => model.Password; 
            set
            {
                model.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Pesel
        {
            get => model.Pesel; 
            set
            {
                model.Pesel = value;
                OnPropertyChanged(nameof(Pesel));
            }
        }

        public string Address
        {
            get => model.Address; 
            set
            {
                model.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        #endregion

        #region Constructors
        public AddingUsersViewModel(AdminViewModel viewmodel, AddUsersWindow view)
        {
            model = new AddingUsersModel(viewmodel, view);
        }

        public AddingUsersViewModel(WorkerViewModel viewmodel, AddUsersWindow view)
        {
            model = new AddingUsersModel(viewmodel, view);
        }
        #endregion
    }
}
