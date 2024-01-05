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
        private readonly IWindowGuidContainer windowGuidContainer;

        private readonly WindowPointersCollection<IWindowPointing> 
            windowPointings;

        public RegisterWindow
            (IWindowGuidContainer windowGuidContainer, 
            WindowPointersCollection<IWindowPointing> windowPointings)
        {
            InitializeComponent();

            Func<Task> run = async () =>
            {
                this.Show();
            };

            Func<Task> hide = async () =>
            {
                this.Hide();
            };

            Func<Task> close = async () =>
            {
                this.Close();
            };

            var windowsPointer = 
                new WindowPointer(run, close, hide, windowGuidContainer.RegisterWindow);
            windowPointings.Add(windowsPointer);

            DataContext = new RegisterWindowViewModel(windowsPointer);

            MessageBox.Show("You have not to get data with '*' symbol");
            this.windowGuidContainer = windowGuidContainer;
            this.windowPointings = windowPointings;
        }
    }
}
