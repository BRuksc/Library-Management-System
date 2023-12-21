using LibraryManagementSystem.Interfaces.UI;
using LibraryManagementSystem.Logic.MVVM.Models.ValidationSystem;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Logic.Tools;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ValidationSystem
{
    public class EmailCodeViewModel : BasicViewModel
    {
        private readonly IWindowPointing windowPointer;

        private readonly EmailCodeModel model;

        private readonly string whatVerify;

        public string WindowCode
        {
            get => model.WindowCode;
            set
            {
                model.WindowCode = value;
                OnPropertyChanged(nameof(WindowCode));
            }
        }

        public EmailCodeViewModel
            (IWindowPointing windowPointer, RegisterWindowModel registerData, string verifyingCode,
            string whatYouWantToVerify)
        {
            model = new EmailCodeModel(registerData, verifyingCode);
            whatVerify = whatYouWantToVerify;
            this.windowPointer = windowPointer;
        }

        private async Task GoToRegister()
        {
            //TODO
            //var regWin = new RegisterWindow();
            //window.Show();
            windowPointer.Close();
        }

        private async Task GoToLogin()
        {
            //TODO
            //var logWin = new MainWindow();
            //logWin.Show();
            windowPointer.Close();
        }

        private ICommand goBackToPrevousWindow = null;
        private ICommand verify = null;

        public ICommand GoBackToPrevousWindow
        {
            get
            {
                //goBackToPrevousWindow = new RelayCommand(async (o) =>
                //{
                //    if (whatVerify == EmailCodeModel.VerifyingRegistration)
                //    {
                //        MessageBoxResult result = MessageBox.Show
                //        ("Are you sure you want to back to the provous window? You will cannot use the same code a second time!");

                //        switch (result)
                //        {
                //            case MessageBoxResult.Yes:
                //                await GoToRegister();
                //                break;

                //            case MessageBoxResult.Cancel:
                //                break;
                //        }
                //    }
                //}, null);

                return goBackToPrevousWindow;
            }
        }

        public ICommand Verify
        {
            get
            {
                //TODO
                //verify = new RelayCommand(async (o) =>
                //{

                //    if (WindowCode == model.VerifyingCode)
                //    {
                //        if (whatVerify == EmailCodeModel.VerifyingRegistration)
                //        {
                //            bool isRegistered = await model.RegisterData.RegisterLibrary();

                //            if (isRegistered)
                //            {
                //                MessageBox.Show("Everything is ok! Library was registered successfully!");
                //                await GoToLogin();
                //            }

                //            else MessageBox.Show("Library has not been registered!");
                //        }
                //    }

                //    else MessageBox.Show("This code is diffrent of code, that we sent you into email!");

                //}, null);

                return verify;
            }
        }
    }
}
