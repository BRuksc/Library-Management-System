using LibraryManagementSystem.Tools;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autofac;
using LibraryManagementSystem.WindowsPointing;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ValidationSystem;
using LibraryManagementSystem.WindowsPointing.Interfaces;

namespace LibraryManagementSystem.MVVM.Views.ValidationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWindowGuidContainer windowGuidContainer;
        private readonly WindowPointersCollection<IWindowPointing> windowPointings;

        public MainWindow(IWindowGuidContainer windowGuidContainer,
            WindowPointersCollection<IWindowPointing> windowPointings)
        {
            InitializeComponent();

            Func<Task> run = async () =>
            {
                this.Show();
            };

            Func<Task> close = async () =>
            {
                this.Close();
            };

            Func<Task> hide = async () =>
            {
                this.Hide();
            };

            var windowsPointer = new WindowPointer(run, close, hide, windowGuidContainer.LoginWindow);


            this.DataContext = new MainViewModel(windowsPointer);
            this.windowGuidContainer = windowGuidContainer;
            this.windowPointings = windowPointings;
        }
    }
}
