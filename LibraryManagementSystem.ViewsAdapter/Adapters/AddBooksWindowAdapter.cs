using LibraryManagementSystem.MVVM.ViewModels.ManagementSystem;
using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using LibraryManagementSystem.ViewsAdapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewsAdapter.Adapters
{
    public class AddBooksWindowAdapter : IActions<AddBooksWindow>
    {
        private readonly AddBooksWindow _view;
        public AddBooksWindow View => throw new NotImplementedException();

        public AddBooksWindowAdapter(AdminViewModel adminVM)
        {
            _view = new AddBooksWindow(adminVM);
        }

        public void Hide()
        {
            View.Hide();
        }

        public void Show()
        {
            View.Show();
        }
    }
}
