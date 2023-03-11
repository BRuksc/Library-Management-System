using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels;
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
        public AddUsersWindow(AdminViewModel adminVM, WorkerViewModel workerVM)
        {
            InitializeComponent();

            if (adminVM != null)
                DataContext = new AddingUsersViewModel(adminVM, this);

            if (workerVM != null)
                DataContext = new AddingUsersViewModel(workerVM, this);
        }
    }
}
