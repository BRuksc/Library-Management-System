using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Logic.MVVM.Models.ManagementSystem
{
    public class AdminModel : BaseModel
    {
        public AdminModel(LibDataModel library) : base(library)
        {
            WindowTitle = "Library Management System - admin panel";
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
