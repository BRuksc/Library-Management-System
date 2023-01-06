using LibraryManagementSystem.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryManagementSystem.MVVM.Models.ValidationSystem;
using LibraryManagementSystem.MVVM.ViewModels.ValidationSystem;

namespace LibraryManagementSystem.MVVM.Views.ValidationSystem
{
    /// <summary>
    /// Interaction logic for VerifyingRegistrationWindow.xaml
    /// </summary>
    public partial class EmailCodeVerification : Window
    {
        internal EmailCodeVerification
            (RegisterWindowModel registerData, string verifyingCode, string whatDoYouWantToVerify)
        {
            InitializeComponent();

            this.DataContext = new EmailCodeViewModel(this, registerData, verifyingCode, whatDoYouWantToVerify);
        }
    }
}
