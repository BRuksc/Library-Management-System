using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.MVVM.Models.ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem
{
    internal class AdminViewModel : AdminWorkerBaseViewModel
    {
        public AdminViewModel(LibDataModel library)
        {
            model = new AdminModel(library);
        }
    }
}
