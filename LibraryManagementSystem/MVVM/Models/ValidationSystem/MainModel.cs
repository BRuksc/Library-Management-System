using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Tools;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using LibraryManagementSystem.MVVM.Views.ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;

namespace LibraryManagementSystem.MVVM.Models.ValidationSystem
{
    public class MainModel
    {
        public string LibNip { get; set; } = string.Empty;

        public string LoginText { get; set; } = string.Empty;

        public string PasswordText { get; set; } = string.Empty;

        public MainModel()
        {
            LibNip = "1111111111";
            LoginText = "Admin";
            PasswordText = "Password";
        }

        public string GetExceptions()
        {

            if (LibNip == string.Empty)
                return "NIP is empty!";

            else if (!int.TryParse(LibNip, out int result))
                return "Uncorrect NIP number! There can be only numbers.";

            else
            {
                try
                {
                    var lib = new LibraryDataManager().SelectByNip(result);

                    if (lib == null)
                        return "Library with this NIP does not exist!";

                    var admin = new AdminDataManager().Select(new Admin()
                    {
                        LibraryId = lib.Id,
                        Login = LoginText,
                        Password = PasswordText
                    });

                    var worker = new WorkersDataManager().Select(new Worker()
                    {
                        LibraryId = lib.Id,
                        Login = LoginText,
                        Password = PasswordText
                    });

                    var user = new UsersDataManager().Select(new User()
                    {
                        LibraryId = lib.Id,
                        Email = LoginText,
                        Password = PasswordText
                    });

                    if (admin == null && worker == null && user == null)
                        return "Uncorrect login or password.";

                    else if (admin != null && worker != null ||
                        admin != null && user != null ||
                        worker != null && user != null)
                        return "Application see more than one user with that data. " +
                            "Contact with our support";

                    else return string.Empty;
                }

                catch (Exception)
                {
                    return "System have any error, try again.";
                }
            }
        }

        public async Task Login()
        {
            try
            {
                var lib =
                    new LibraryDataManager().SelectByNip(Convert.ToInt32(LibNip));

                if (lib != null)
                {
                    var admin = new AdminDataManager().Select(new Admin()
                    {
                        LibraryId = lib.Id,
                        Login = LoginText,
                        Password = PasswordText
                    });

                    var worker = new WorkersDataManager().Select(new Worker()
                    {
                        LibraryId = lib.Id,
                        Login = LoginText,
                        Password = PasswordText
                    });

                    var user = new UsersDataManager().Select(new User()
                    {
                        LibraryId = lib.Id,
                        Email = LoginText,
                        Password = PasswordText
                    });

                    if (admin != null)
                    {
                        ViewModelLocator.ViewModelManagementWindow = new AdminViewModel(lib);
                        var win = new AdminWorkerWindow();
                        win.Show();
                    }

                    else MessageBox.Show("I cannot find user with that login data!");
                }

                else MessageBox.Show("Cannot connect with database!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
