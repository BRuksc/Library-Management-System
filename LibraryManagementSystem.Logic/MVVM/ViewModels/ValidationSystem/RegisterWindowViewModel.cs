using LibraryManagementSystem.Models;
using LibraryManagementSystem.Logic.MVVM.Models.ValidationSystem;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Logic.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LibraryManagementSystem.Interfaces.UI;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ValidationSystem
{
    public class RegisterWindowViewModel : BasicViewModel
    {
        private RegisterWindowModel model;
        private readonly IWindowPointing windowPointer;

        public RegisterWindowViewModel(IWindowPointing windowPointer)
        {
            model = new RegisterWindowModel();

            OnPropertyChangedAll();
            this.windowPointer = windowPointer;
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

        public string TelephoneNumber
        {
            get => model.TelephoneNumber;

            set
            {
                model.TelephoneNumber = value;
                OnPropertyChanged(nameof(TelephoneNumber));
            }
        }

        public string WebsiteAddress
        {
            get => model.WebsiteAddress;

            set
            {
                model.WebsiteAddress = value;
                OnPropertyChanged(nameof(WebsiteAddress));
            }
        }

        public string EmailAddress
        {
            get => model.EmailAddress;

            set
            {
                model.EmailAddress = value;
                OnPropertyChanged(nameof(EmailAddress));
            }
        }

        public string NipNumber
        {
            get => model.NipNumber;

            set
            {
                model.NipNumber = value;
                OnPropertyChanged(nameof(NipNumber));
            }
        }

        public string RegonNumber
        {
            get => model.RegonNumber;

            set
            {
                model.RegonNumber = value;
                OnPropertyChanged(nameof(RegonNumber));
            }
        }

        public string DunsNumber
        {
            get => model.DunsNumber;

            set
            {
                model.DunsNumber = value;
                OnPropertyChanged(nameof(DunsNumber));
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

        public string DateOfCommencementOfActivities
        {
            get => model.DateOfCommencementOfActivities;

            set
            {
                model.DateOfCommencementOfActivities = value;
                OnPropertyChanged(nameof(DateOfCommencementOfActivities));
            }
        }

        public string Voivodeship
        {
            get => model.Voivodeship;

            set
            {
                model.Voivodeship = value;
                OnPropertyChanged(nameof(Voivodeship));
            }
        }

        public string City
        {
            get => model.City;

            set
            {
                model.City = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string ZipCode
        {
            get => model.ZipCode;

            set
            {
                model.ZipCode = value;
                OnPropertyChanged(nameof(ZipCode));
            }
        }

        public string AdminAccountLogin
        {
            get => model.AdminAccountLogin;

            set
            {
                model.AdminAccountLogin = value;
                OnPropertyChanged(nameof(AdminAccountLogin));
            }
        }

        public string AdminAccountPassword
        {
            get => model.AdminAccountPassword;

            set
            {
                model.AdminAccountPassword = value;
                OnPropertyChanged(nameof(AdminAccountPassword));
            }
        }

        public string AdminAccountRepeatPassword
        {
            get => model.AdminAccountRepeatPassword;

            set
            {
                model.AdminAccountRepeatPassword = value;
                OnPropertyChanged(nameof(AdminAccountRepeatPassword));
            }
        }

        private void OnPropertyChangedAll()
        {
            OnPropertyChanged(nameof(Address));
            OnPropertyChanged(nameof(TelephoneNumber));
            OnPropertyChanged(nameof(WebsiteAddress));
            OnPropertyChanged(nameof(EmailAddress));
            OnPropertyChanged(nameof(NipNumber));
            OnPropertyChanged(nameof(RegonNumber));
            OnPropertyChanged(nameof(DunsNumber));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(DateOfCommencementOfActivities));
            OnPropertyChanged(nameof(Voivodeship));
            OnPropertyChanged(nameof(City));
            OnPropertyChanged(nameof(ZipCode));
            OnPropertyChanged(nameof(AdminAccountLogin));
            OnPropertyChanged(nameof(AdminAccountPassword));
            OnPropertyChanged(nameof(AdminAccountRepeatPassword));
        }

        private ICommand clearAll = null;
        private ICommand register = null;

        public ICommand ClearAll
        {
            get
            {
                if (clearAll == null)
                {
                    //clearAll = new RelayCommand(
                    //    (o) =>
                    //    {
                    //        model.ClearAll();
                    //        OnPropertyChangedAll();
                    //    }, null);
                }

                return clearAll;
            }
        }

        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    //register = new RelayCommand(
                    //    async (o) =>
                    //    {
                    //        var validator = new LibraryRegisterValidator(model);

                    //        if (validator.GetExceptions().Count == 0)
                    //        {
                    //            model.LibraryCanBeCreated = true;
                    //            validator = new LibraryRegisterValidator(model);

                    //            var wasEmailSent =
                    //                await validator.SendRegistrationEmail();
                    //            windowPointer.Close();
                    //        }

                    //        else
                    //        {
                    //            foreach (var i in validator.GetExceptions())
                    //                MessageBox.Show(i);
                    //        }


                    //    }, null);
                }

                return register;
            }
        }
    }
}
//botlibrarysystemmanagement@onet.eu