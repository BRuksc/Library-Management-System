using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Logic.MVVM.Models.ManagementSystem.AddingWindowsModels
{
    public abstract class BaseAddingModel
    {
        public bool IsOne { get; set; } = true;
        public bool IsMany { get; set; }
        public string ManyValue { get; set; } = String.Empty;
        public bool ManyValueActive { get; set; }


        public abstract Task<bool> Add();
    }
}
