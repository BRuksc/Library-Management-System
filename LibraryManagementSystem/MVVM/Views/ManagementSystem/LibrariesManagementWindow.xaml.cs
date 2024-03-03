using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Autofac;
using Autofac.Core;
using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Logic.Interfaces;
using LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.Tools;
using LibraryManagementSystem.WindowsPointing;
using LibraryManagementSystem.WindowsPointing.Interfaces;

namespace LibraryManagementSystem.MVVM.Views.ManagementSystem
{
    /// <summary>
    /// Interaction logic for LibrariesManagementWindow.xaml
    /// </summary>
    public partial class LibrariesManagementWindow : Window
    {
        private readonly IList<LibDataModel> testLibs;

        private readonly Autofac.IContainer container;
        private IAddingTestCollectionData<LibDataModel> addingTestCollectionData => 
            container.Resolve<IAddingTestCollectionData<LibDataModel>>();

        private WindowPointersCollection<IWindowPointing> validatingCollection =>
            container.Resolve<WindowPointersCollection<IWindowPointing>>();

        private IWindowGuidContainer windowGuidContainer =>
            container.Resolve<IWindowGuidContainer>();

        private ILibraryManagementWindowOperations libraryManagementOperations
            => container.Resolve<ILibraryManagementWindowOperations>();

        public LibrariesManagementWindow()
        {
            this.testLibs = new List<LibDataModel>();
            this.container = Bootstrapper.Container;
            AddWindowPointer();

            this.DataContext = new LibrariesManagementWindowViewModel(
                ref container,
                libraryManagementOperations
            );

            InitializeComponent();

            addingTestCollectionData.AddingTestAdminsCollection(ref testLibs, 10);
            librariesDataGrid.ItemsSource = testLibs;
        }

        private void AddWindowPointer()
        {
            Func<Task> show = async () =>
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

            var libraryManagementSystemGuid =
                windowGuidContainer.LibraryManagementWindow;
            IWindowPointing windowPointer =
                new WindowPointer(show, close, hide, libraryManagementSystemGuid);
            validatingCollection.Add(windowPointer);
        }
    }
}
