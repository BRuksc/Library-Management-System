using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.Interfaces
{
    public interface IAddingViewModel
    {
        public bool IsOne { get; set; }
        public bool IsMany { get; set; }
        public string ManyValue { get; set; }
        public bool ManyValueActive { get; set; }
        public ICommand Add { get; }
    }
}
