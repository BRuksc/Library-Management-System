using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using LibraryManagementSystem.MVVM.Models.ManagementSystem;
using LibraryManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem
{
    internal abstract partial class AdminWorkerBaseViewModel
    {
        protected ICommand? addTab1 = null;
        protected ICommand? addTab2 = null;

        public ICommand AddTab1
        {
            get
            {
                if (addTab1 == null)
                {
                    addTab1 = new RelayCommand(
                        async (object o) =>
                        {
                            await model.AddTab1();
                        },
                        (object o) =>
                        {
                            return (Loans != null) || (Users != null)
                            || (Loans == null) || (Users == null);
                        });
                }

                return addTab1;
            }
        }

        public ICommand AddTab2
        {
            get
            {
                if (addTab2 == null)
                {
                    addTab2 = new RelayCommand(
                        async (object o) =>
                        {
                            await model.AddTab2();
                        },
                        (object o) =>
                        {
                            return (Books != null) || (AvailableleBooks != null) || (BorrowedBooks != null)
                            || (Books == null) || (AvailableleBooks == null) || (BorrowedBooks == null);
                        });
                }

                return addTab2;
            }
        }
    }
}
