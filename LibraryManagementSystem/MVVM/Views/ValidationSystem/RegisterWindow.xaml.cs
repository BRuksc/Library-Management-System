using LibraryManagementSystem.Logic.MVVM.ViewModels.ValidationSystem;
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

namespace LibraryManagementSystem.MVVM.Views.ValidationSystem
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow(IWindowGuidContainer windowGuidContainer)
        {
            InitializeComponent();

            var run = new Task(new Action(() => this.Show()));
            var close = new Task(new Action(() => this.Close()));
            var hide = new Task(new Action(() => this.Hide()));
            var windowsPointer = new WindowPointer(run, close, hide, windowGuidContainer.LibraryManagementWindow);

            DataContext = new RegisterWindowViewModel(windowsPointer);

            MessageBox.Show("You have not to get data with '*' symbol");
        }
    }
}
