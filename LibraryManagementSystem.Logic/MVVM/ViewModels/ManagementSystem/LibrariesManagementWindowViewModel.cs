using LibraryManagementSystem.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementSystem.Logic.MVVM.ViewModels.ManagementSystem
{
    public class LibrariesManagementWindowViewModel : BasicViewModel, ILibrariesManagementWindow
    {
        private readonly Autofac.IContainer container;

        private ICommand? open;
        private ICommand? create;
        private ICommand? joinFromServer;

        public ICommand Open
        {
            get
            {
                if (open == null)
                {

                }

                return open;
            }
        }

        public ICommand Create
        {
            get
            {
                if (create == null) 
                {
                
                }

                return create;
            }
        }

        public ICommand JoinFromServer
        {
            get
            {
                if (joinFromServer == null)
                {

                }

                return joinFromServer;
            }
        }

        public LibrariesManagementWindowViewModel(Autofac.IContainer container) : base()
        {
            this.container = container;
        }
    }
}
