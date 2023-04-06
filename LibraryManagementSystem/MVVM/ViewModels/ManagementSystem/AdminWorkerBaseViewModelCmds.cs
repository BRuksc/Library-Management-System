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

        protected ICommand? removeTab1 = null;

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

        public ICommand RemoveTab1
        {
            get
            {
                if (removeTab1 == null)
                {
                    removeTab1 = new RelayCommand(
                        async (object o) =>
                        {
                            await model.RemoveTab1(this);
                        },
                        (object o) =>
                        {
                            return (Loans != null) || (Users != null)
                                || (Loans == null) || (Users == null);
                        });
                }

                return removeTab1;
            }
        }

        public abstract ICommand AddTab2 { get; }
        public ICommand RemoveTab2
        {
            get
            {

            }
        }
    }
}
