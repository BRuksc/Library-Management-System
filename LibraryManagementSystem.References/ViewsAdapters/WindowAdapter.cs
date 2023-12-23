using LibraryManagementSystem.MVVM.Views.ManagementSystem.AddingViews;
using LibraryManagementSystem.References.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem.References.ViewsAdapters
{
    public class WindowAdapter<T> : IWindowAdapting where T : Window
    {
        private readonly T window;

        public WindowAdapter(T window = null)
        {
            this.window = window;
        }

        public void Close() => window?.Close();

        public void Hide() => window?.Hide();

        public void Show() => window?.Show();
    }
}
