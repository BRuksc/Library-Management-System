using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels;
using LibraryManagementSystem.WindowsPointing;
using LibraryManagementSystem.WindowsPointing.Interfaces;
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

namespace LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews
{
    /// <summary>
    /// Interaction logic for AddUsersWindow.xaml
    /// </summary>
    public partial class AddUsersWindow : Window
    {
        public AddUsersWindow(AdminViewModel adminVM, IWindowGuidContainer windowGuidContainer)
        {
            InitializeComponent();

            var run = new Task(new Action(() => this.Show()));
            var close = new Task(new Action(() => this.Close()));
            var hide = new Task(new Action(() => this.Hide()));
            var windowsPointer = new WindowPointer(run, close, hide, windowGuidContainer.LibraryManagementWindow);

            DataContext = new AddingUsersViewModel(adminVM, windowsPointer);
        }
    }
}
