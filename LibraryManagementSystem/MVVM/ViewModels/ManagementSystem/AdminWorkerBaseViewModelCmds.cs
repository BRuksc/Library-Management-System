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
    public abstract partial class AdminWorkerBaseViewModel
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
                            await model.AddTab1(this);
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

        public ICommand RemoveTab1 { get; }

        public abstract ICommand AddTab2 { get; }
        public abstract ICommand RemoveTab2 { get; }
    }
}
