using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Logic.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.Primitives;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem
{
    public class LibraryManagementWindowOperations : ILibraryManagementWindowOperations
    {
        #region fields and properties
        private LibDataModel _selectedItem;
        public LibDataModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == null)
                {
                    _selectedItem = value;
                }
            }
        }

        private DelegateCommand _open;
        private DelegateCommand _create;
        private DelegateCommand _joinFromServer;

        public DelegateCommand Open
        {
            get => _open;
            set
            {
                if (_open == null)
                {
                    _open = value;
                }
            }
        }
        public DelegateCommand Create
        {
            get => _create;
            set
            {
                if (_create == null)
                {
                    _create = value;
                }
            }
        }
        public DelegateCommand JoinFromServer
        {
            get => _joinFromServer;
            set
            {
                if (_joinFromServer == null)
                {
                    _joinFromServer = value;
                }
            }
        }
        #endregion

        #region constructors

        public LibraryManagementWindowOperations(
            Func<Task> open,
            Func<Task> create, 
            Func<Task> joinFromServer)
        {
            _open = new DelegateCommand(() => open?.Invoke(), 
                CanExecute);

            _create = new DelegateCommand(() => create?.Invoke(),
                () => true);

            _joinFromServer = new DelegateCommand(() => joinFromServer?.Invoke(),
                CanExecute);
        }
        #endregion

        private bool CanExecute() => _selectedItem == null ? false : true;
    }
}
