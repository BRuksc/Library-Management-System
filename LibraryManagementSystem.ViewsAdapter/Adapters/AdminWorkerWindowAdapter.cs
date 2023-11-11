using LibraryManagementSystem.MVVM.Views.ManagementSystem;
using LibraryManagementSystem.ViewsAdapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewsAdapter.Adapters
{
    public class AdminWorkerWindowAdapter : IActions<AdminWorkerWindow>, IDisposable
    {
        private readonly AdminWorkerWindow _view;
        public AdminWorkerWindow View => _view;

        public AdminWorkerWindowAdapter()
        {
            _view = new AdminWorkerWindow();
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
