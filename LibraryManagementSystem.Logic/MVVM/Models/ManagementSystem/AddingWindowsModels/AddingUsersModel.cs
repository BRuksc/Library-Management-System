using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels;
using LibraryManagementSystem.Logic.MVVM.Models.ValidationSystem;
using LibraryManagementSystem.Logic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibraryManagementSystem.WindowsPointing.Interfaces;

namespace LibraryManagementSystem.Logic.MVVM.Models.ManagementSystem.AddingWindowsModels
{
    public class AddingUsersModel : BaseAddingModel
    {
        #region Properties
        public string Email { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Pesel { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public AdminViewModel? AdminVM { get; set; } = null;
        private IWindowPointing windowPointer;

        #endregion

        #region Constructors
        public AddingUsersModel(AdminViewModel viewmodel, IWindowPointing windowPointer)
        {
            AdminVM = viewmodel;
            this.windowPointer = windowPointer;
        }
        #endregion

        #region Methods
        public override async Task<bool> Add()
        {
            try
            {
                var validator = new AddingUsersValidation(this);

                if (validator.Validate.Count == 0)
                {
                    if (AdminVM != null)
                    {
                        if (AdminVM != null)
                        {
                            var userAddedAdmin = await new UsersDataManager().Add(new User()
                            {
                                Email = this.Email,
                                Name = this.Name,
                                Surname = this.Surname,
                                Password = this.Password,
                                Pesel = Convert.ToInt32(this.Pesel),
                                Address = this.Address,
                                //IsActive = false,
                                IsActive = true,
                                LibraryId = AdminVM.Library.Id
                            });

                            if (userAddedAdmin)
                            {
                                /*EmailSender.Send("botlibrarysystemmanagement@gmail.com",
                                    Email,
                                    "Registration confirmation in library " + WorkerVM.Library.Name,
                                    "User",
                                    "Hi, If you confirm, that you want to be registered in the " + WorkerVM.Library.Name + " as " + Name + " " + Surname + " click in the link below... ",
                                    "SECRET-CODE");*/
                                var result = MessageBox.Show("User is registered, and can loan books after confirmation on the email address.", "Confirmation",
                                    MessageBoxButton.OK, MessageBoxImage.Information);

                                if (result == MessageBoxResult.OK)
                                    windowPointer.Close();
                            }

                            AdminVM.OnPropertyChanged(nameof(AdminVM.Users));
                        }
                    }

                    else throw new Exception();

                    return true;
                }

                else
                {
                    foreach (var i in validator.Validate)
                        MessageBox.Show(i, "System cannot register this user", MessageBoxButton.OK, MessageBoxImage.Error);

                    throw new Exception();
                }
            }

            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}
