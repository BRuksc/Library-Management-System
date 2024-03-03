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
        public LibDataModel SelectedItem { get; set; }
        public bool DatabaseOperationsEnabled { get; set; }
    }
}
