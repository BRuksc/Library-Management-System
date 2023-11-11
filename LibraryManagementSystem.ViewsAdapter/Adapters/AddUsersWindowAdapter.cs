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
    public class AddUsersWindowAdapter : IActions<AddUsersWindow>, IDisposable
    {
        private readonly AddUsersWindow _view;
        public AddUsersWindow View => _view;

        public AddUsersWindowAdapter(AdminViewModel adminVM)
        {
            _view = new AddUsersWindow(adminVM);
        }

        public void Close()
        {
            View.Close();
        }

        public void Show()
        {
            View.Show();
        }

        public void Dispose()
        {
            View.Close();
        }
    }
}
