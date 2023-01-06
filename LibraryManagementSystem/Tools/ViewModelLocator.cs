using LibraryManagementSystem.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tools
{
    internal static class ViewModelLocator
    {
        public static dynamic? ViewModelManagementWindow { get; set; }
        public static dynamic? ViewModelAddRecordsWindow { get; set; }
    }
}
