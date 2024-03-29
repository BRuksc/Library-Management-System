﻿using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces.Data
{
    public interface IViewModelsTypes
    {
        public AdminViewModel? AdminVM { get; set; }
        public WorkerViewModel? WorkerVM { get; set; }
    }
}
