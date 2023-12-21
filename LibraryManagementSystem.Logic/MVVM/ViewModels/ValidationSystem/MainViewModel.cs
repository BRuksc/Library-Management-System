using LibraryManagementSystem.Interfaces.UI;
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

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ValidationSystem
{
    public class MainViewModel : BasicViewModel
    {
        private MainModel model;
        private readonly IWindowPointing windowPointer;
        public string LoginText
        {
            get => model.LoginText;
            set
            {
                model.LoginText = value;
                OnPropertyChanged(nameof(LoginText));
            }
        }

        public string PasswordText
        {
            get => model.PasswordText;
            set
            {
                model.PasswordText = value;
                OnPropertyChanged(nameof(PasswordText));
            }
        }

        public string LibNip
        {
            get => model.LibNip;
            set
            {
                model.LibNip = value;
                OnPropertyChanged(nameof(LibNip));
            }
        }

        public MainViewModel(IWindowPointing windowPointer)
        {
            model = new MainModel();
            this.windowPointer = windowPointer;
        }

        private ICommand passwordRecovery = null;
        private ICommand registering = null;
        private ICommand login = null;

        public ICommand PasswordRecovery
        {
            get
            {
                return passwordRecovery;
            }
        }

        public ICommand Registering
        {
            get
            {
                if (registering == null)
                {
                    //registering = new RelayCommand(
                    //   (o) =>
                    //   {
                           //TODO
                           //var rw = new RegisterWindow();
                           //rw.Show();

                       //    windowPointer.Close();
                       //}, null);
                }

                return registering;
            }
        }

        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    //TODO
                    //login = new RelayCommand(
                    //    async (o) =>
                    //    {
                    //        if (model.GetExceptions() == string.Empty)
                    //        {
                    //            await model.Login();
                    //            windowPointer.Close();
                    //        }

                    //        else MessageBox.Show(model.GetExceptions());
                    //    },
                    //    (o) =>
                    //    {
                    //        return login != null;
                    //    });
                }

                return login;
            }
        }
    }
}
