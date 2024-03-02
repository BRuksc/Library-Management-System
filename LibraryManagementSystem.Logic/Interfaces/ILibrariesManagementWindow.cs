using LibraryManagementSystem.Data.DataModels;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.Logic.Interfaces
{
    public interface ILibrariesManagementWindow
    {
        public DelegateCommand Open { get; set; }
        public DelegateCommand Create { get; set; }
        public DelegateCommand JoinFromServer { get; set; }
        public LibDataModel SelectedItem { get; set; }
        public bool DatabaseOperationsEnabled { get; set; }
    }
}
