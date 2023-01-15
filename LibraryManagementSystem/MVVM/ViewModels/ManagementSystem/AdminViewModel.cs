using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.MVVM.Models.ManagementSystem;
using LibraryManagementSystem.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.MVVM.ViewModels.ManagementSystem
{
    public class AdminViewModel : AdminWorkerBaseViewModel
    {
        public AdminViewModel(LibDataModel library)
        {
            model = new AdminModel(library);
        }

        public override ICommand AddTab2
        {
            get
            {
                if (addTab2 == null)
                {
                    addTab2 = new RelayCommand(
                        async (object o) =>
                        {
                            await model.AddTab2(this);
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
