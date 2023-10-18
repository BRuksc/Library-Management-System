using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using LibraryManagementSystem.ViewsAdapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewsAdapter.Adapters
{
    public class AddLoansWindowAdapter : IActions<AddLoansWindow>
    {
        private readonly AddLoansWindow _view;
        public AddLoansWindow View => _view;

        public AddLoansWindowAdapter()
        {
            _view = new AddLoansWindow();
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
