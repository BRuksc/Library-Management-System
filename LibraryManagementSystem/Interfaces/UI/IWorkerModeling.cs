using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interfaces
{
    public interface IWorkerModeling
    {
        public Task EditUser(User user);
        public Task<bool> RemoveUser(int Id);
        public Task<bool> RemoveUser(User user);
        public Task EditLoan(Loan loan);
        public Task<bool> RemoveLoan(int Id);
        public Task<bool> RemoveLoan(Loan loan);
    }
}
