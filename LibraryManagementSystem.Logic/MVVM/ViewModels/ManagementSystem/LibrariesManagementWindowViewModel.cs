using Autofac;
using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Logic.Exceptions;
using LibraryManagementSystem.Logic.Interfaces;
using LibraryManagementSystem.WindowsPointing;
using LibraryManagementSystem.WindowsPointing.Interfaces;
using Prism.Commands;
using System.Windows;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem
{
    public class LibrariesManagementWindowViewModel : BasicViewModel, ILibrariesManagementWindow
    {
        private readonly ILibraryManagementWindowOperations operations;
        private LibDataModel selectedItem;
        public LibDataModel SelectedItem
        {
            get
            {
                //_canExecuteChanged?.Invoke(this, EventArgs.Empty);
                return this.selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                _canExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool databaseOperationsEnabled;
        public bool DatabaseOperationsEnabled 
        {
            get => databaseOperationsEnabled;
            set
            {
                databaseOperationsEnabled = value;
                OnPropertyChanged(nameof(DatabaseOperationsEnabled));
            }
        }

        private readonly Autofac.IContainer container;

        public LibrariesManagementWindowViewModel(ref Autofac.IContainer container) : base()
        {
            _canExecuteChanged += ExecuteChangedEnabled;
            
            try
            {
                if (container == null)
                {
                    throw new NullContainerException(nameof(container));
                }

                this.container = container;
                operations = container.Resolve<ILibraryManagementWindowOperations>();
            }
            catch (NullContainerException ex)
            {
                MessageBox.Show("IoC container cannot be null!");

                var guid = container.Resolve<IWindowGuidContainer>()
                    .LibraryManagementWindow;

                container.Resolve<WindowPointersCollection<IWindowPointing>>()
                    .Collection.First(x => x.WindowGuid == guid).Close();
            }
        }

        private void ExecuteChangedEnabled(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(DatabaseOperationsEnabled));
        }

        private event EventHandler _canExecuteChanged;
    }
}
