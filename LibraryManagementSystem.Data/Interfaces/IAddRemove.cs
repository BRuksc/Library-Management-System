using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Interfaces
{
    public interface IAddRemove<T>
    {
        public abstract  T AddTab1(dynamic viewmodel);
        public abstract T AddTab2(dynamic viewmodel);
        public T RemoveTab1(dynamic viewmodel);
        public T RemoveTab2(dynamic viewmodel);
    }
}
