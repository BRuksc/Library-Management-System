using LibraryManagementSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.MVVM.Models.ManagementSystem
{
    internal class WorkerModel : BaseModel
    {
        public WorkerModel(LibDataModel library) : base(library)
        {
            WindowTitle = "Library Management System - worker panel";
        }
    }
}
