using LibraryManagementSystem.Logic.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem
{
    public class LibrariesManagementWindowViewModel : BasicViewModel, ILibrariesManagementWindow
    {
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

            Open = new DelegateCommand(open, () => true);
            Create = new DelegateCommand(create, () => true);
            JoinFromServer = new DelegateCommand(joinFromServer, () => true);
        }

        public DelegateCommand Open { get; set; }
        public DelegateCommand Create { get; set; }
        public DelegateCommand JoinFromServer { get; set; }

        private void open() => openDatabase?.Invoke();
        private void create() => createAndShowConnectToServerView?.Invoke();
        private void joinFromServer() => joinFromServerFunc?.Invoke();
    }
}
