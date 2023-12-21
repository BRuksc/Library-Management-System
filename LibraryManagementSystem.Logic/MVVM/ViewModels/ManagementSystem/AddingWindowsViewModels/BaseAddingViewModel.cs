using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Logic.MVVM.Models.ManagementSystem.AddingWindowsModels;
using LibraryManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels
{
    public abstract class BaseAddingViewModel<T> : BasicViewModel where T : class
    {
        public abstract bool IsOne { get; set; }
        public abstract bool IsMany { get; set; }
        public abstract string ManyValue { get; set; }
        public abstract bool ManyValueActive { get; set; }
        public abstract ICommand Add { get; }

        protected T model;
        protected ICommand? add = null;
    }
}
