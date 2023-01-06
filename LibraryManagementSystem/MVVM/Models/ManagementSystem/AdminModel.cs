using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem
{
    internal class AdminModel : BaseModel
    {
        public AdminModel(LibDataModel library) : base(library)
        {
            WindowTitle = "Library Management System - admin panel";
        }

    }
}
