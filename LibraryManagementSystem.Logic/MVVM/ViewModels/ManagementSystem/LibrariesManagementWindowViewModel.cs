using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Logic.Interfaces;
using Prism.Commands;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem
{
    public class LibrariesManagementWindowViewModel : BasicViewModel, ILibrariesManagementWindow
    {
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

        private readonly Func<Task> createAndShowConnectToServerView;
        private readonly Func<Task> openDatabase;
        private readonly Func<Task> joinFromServerFunc;

        public LibrariesManagementWindowViewModel(
            ref Autofac.IContainer container,
            Func<Task> createAndShowConnectToServerView,
            Func<Task> openDatabase,
            Func<Task> joinFromServerFunc
            ) : base()
        {
            this.container = container;
            this.createAndShowConnectToServerView = createAndShowConnectToServerView;
            this.openDatabase = openDatabase;
            this.joinFromServerFunc = joinFromServerFunc;

            _canExecuteChanged += ExecuteChangedEnabled;

            Open = new DelegateCommand(open, () => _canExecuteCommand);
            Create = new DelegateCommand(create, () => true);
            JoinFromServer = new DelegateCommand(joinFromServer, () => _canExecuteCommand);
        }

        private void ExecuteChangedEnabled(object? sender, EventArgs e)
        {
            DatabaseOperationsEnabled = _canExecuteCommand;
            OnPropertyChanged(nameof(DatabaseOperationsEnabled));
        }

        public DelegateCommand Open { get; set; }
        public DelegateCommand Create { get; set; }
        public DelegateCommand JoinFromServer { get; set; }

        private event EventHandler _canExecuteChanged;

        private bool _canExecuteCommand => SelectedItem == null ? false : true;

        private void open() => openDatabase?.Invoke();
        private void create() => createAndShowConnectToServerView?.Invoke();
        private void joinFromServer() => joinFromServerFunc?.Invoke();
    }
}
