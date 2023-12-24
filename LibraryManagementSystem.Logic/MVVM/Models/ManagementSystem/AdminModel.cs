using LibraryManagementSystem.Data.DataManagers;
using LibraryManagementSystem.Data.DataModels;
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
            //TODO
            //if (TabSelectedBeforeAdd == "Users")
            //    new AddUsersWindowAdapter(viewmodel).Show();

            //else new AddLoansWindowAdapter().Show();
        }

        public override async Task AddTab2(dynamic viewmodel)
        {
            //TODO
            //new AddBooksWindowAdapter(viewmodel).Show();
        }
    }
}
