using LibraryManagementSystem.MVVM.Views.ValidationSystem;
using LibraryManagementSystem.ViewsAdapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewsAdapter.Adapters
{
    public class RegisterWindowAdapter : IActions<RegisterWindow>, IDisposable
    {
        private readonly RegisterWindow _view;
        public RegisterWindow View => throw new NotImplementedException();

        public RegisterWindowAdapter()
        {
            _view = new RegisterWindow();
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
            Close();
        }
    }
}
