using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Logic.Interfaces;
using Prism.Commands;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem
{
    public class LibrariesManagementWindowViewModel : BasicViewModel, ILibrariesManagementWindow
    {
        private readonly ILibraryManagementWindowOperations _operations;
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

        public LibrariesManagementWindowViewModel(
            ref Autofac.IContainer container,
            ILibraryManagementWindowOperations operations
            ) : base()
        {
            this.container = container;
            _canExecuteChanged += ExecuteChangedEnabled;
            _operations = operations;
        }

        private void ExecuteChangedEnabled(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(DatabaseOperationsEnabled));
        }

        private event EventHandler _canExecuteChanged;
    }
}
