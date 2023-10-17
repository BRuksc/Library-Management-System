using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels;

namespace LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews
{
    /// <summary>
    /// Interaction logic for AddBooksWindow.xaml
    /// </summary>
    public partial class AddBooksWindow : Window
    {
        public AddBooksWindow(AdminViewModel adminVM)
        {
            InitializeComponent();

            if (adminVM != null)
                DataContext = new AddingBooksViewModel(adminVM);
        }
    }
}
