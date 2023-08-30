using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem
{
    public class WorkerModel : BaseModel
    {
        public WorkerModel(LibDataModel library) : base(library)
        {
            WindowTitle = "Library Management System - worker panel";
        }

        public override async Task AddTab1(dynamic viewmodel)
        {
            if (TabSelectedBeforeAdd == "Users")
                new AddUsersWindow(viewmodel).Show();

            else new AddLoansWindow().Show();
        }

        public override async Task AddTab2(dynamic viewmodel)
        {
            new AddBooksWindow(viewmodel).Show();
        }
    }
}
