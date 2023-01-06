using LibraryManagementSystem.MVVM.Models.ValidationSystem;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Tools;
using LibraryManagementSystem.MVVM.Views.ValidationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagementSystem.MVVM.ViewModels.ValidationSystem
{
    internal class MainViewModel : BasicViewModel
    {
        private MainModel model;
        private readonly MainWindow view;
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

        public MainViewModel(MainWindow view)
        {
            model = new MainModel();
            this.view = view;
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
                    registering = new RelayCommand(
                       (o) =>
                       {
                           var rw = new RegisterWindow();
                           rw.Show();

                           view.Close();
                       }, null);
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
                    login = new RelayCommand(
                        async (o) =>
                        {
                            if (model.GetExceptions() == string.Empty)
                            {
                                await model.Login();
                                view.Close();
                            }

                            else MessageBox.Show(model.GetExceptions());
                        },
                        (o) =>
                        {
                            return login != null;
                        });
                }

                return login;
            }
        }
    }
}
