using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Tools;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels
{
    public class AddingUsersModel : BaseAddingModel, IViewModelsTypes
    {
        #region Properties
        public string Email { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Pesel { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public AdminViewModel? AdminVM { get; set; } = null;
        public WorkerViewModel? WorkerVM { get; set; } = null;

        #endregion

        #region Constructors
        public AddingUsersModel(AdminViewModel viewmodel)
        {
            AdminVM = viewmodel;
        }

        public AddingUsersModel(WorkerViewModel viewmodel)
        {
            WorkerVM = viewmodel;
        }
        #endregion

        #region Methods
        public override async Task<bool> Add()
        {
            try
            {
                if (AdminVM != null)
                {
                    var userAddedAdmin = await new UsersDataManager().Add(new User()
                    {
                        Email = this.Email,
                        Name = this.Name,
                        Surname = this.Surname,
                        Password = this.Password,
                        Address = this.Address,
                        //IsActive = false,
                        IsActive = true,
                        LibraryId = AdminVM.Library.Id
                    });

                    if (userAddedAdmin)
                        EmailSender.Send("botlibrarysystemmanagement@gmail.com",
                            Email,
                            "Registration confirmation in library " + WorkerVM.Library.Name,
                            "User",
                            "Hi, If you confirm, that you want to be registered in the " + WorkerVM.Library.Name + " as " + Name + " " + Surname + " click in the link below... ",
                            "SECRET-CODE");

                   AdminVM.OnPropertyChanged(nameof(AdminVM));
                }

                if (WorkerVM != null)
                {
                    var userAddedWorker = await new UsersDataManager().Add(new User()
                    {
                        Email = this.Email,
                        Name = this.Name,
                        Surname = this.Surname,
                        Password = this.Password,
                        Address = this.Address,
                        //IsActive = false,
                        IsActive = true,
                        LibraryId = WorkerVM.Library.Id
                    });

                    if (userAddedWorker)
                    {
                        /*EmailSender.Send("botlibrarysystemmanagement@gmail.com",
                            Email,
                            "Registration confirmation in library " + WorkerVM.Library.Name,
                            "User",
                            "Hi, If you confirm, that you want to be registered in the " + WorkerVM.Library.Name + " as " + Name + " " + Surname + " click in the link below... ",
                            "SECRET-CODE");*/

                        var result = MessageBox.Show("User is added to system, has accept validation email for getting loans.", "Adding", 
                            MessageBoxButton.OK, MessageBoxImage.Information);

                        //if (result == MessageBoxResult.OK)
                            
                    }

                    WorkerVM.OnPropertyChanged(nameof(WorkerVM));
                }

                else throw new Exception();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
