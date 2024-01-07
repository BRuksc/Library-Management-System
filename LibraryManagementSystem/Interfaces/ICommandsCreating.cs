using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces
{
    public interface ICommandsCreating
    {
        public Func<Task> CreateAndShowConnectToServerView { get; }
        public Func<Task> OpenDatabase { get; }
        public Func<Task> JoinFromServerFunc { get; }
    }
}
