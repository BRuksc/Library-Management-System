using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.MVVM.Models.ManagementSystem.AddingWindowsModels;
using LibraryManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem.AddingWindowsViewModels
{
    internal abstract class BaseAddingViewModel<T> : BasicViewModel, IAddingViewModel where T : class
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
