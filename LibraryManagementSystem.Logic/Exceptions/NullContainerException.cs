using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Logic.Exceptions
{
    [Serializable]
    public class NullContainerException : Exception
    {
        public NullContainerException() : base()
        {

        }

        public NullContainerException(string message) : base(message) 
        {
        
        }
    }
}
