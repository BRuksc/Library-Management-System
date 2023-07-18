using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tools
{
    public class DbTableDroper : IDbTable<Task>
    {
        private readonly DbsDataModel dataModel;

        public DbTableDroper(DbsDataModel dataModel)
        {
            this.dataModel = dataModel;
        }

        public async Task DropAll()
        {
            await ExecuteAdmins();
            await ExecuteBooks();
            await ExecuteLibraries();
            await ExecuteLoans();
            await ExecuteUsers();
            await ExecuteWorkers();
        }

        public async Task ExecuteAdmins()
        {
            await dataModel.Database.ExecuteSqlRawAsync("IF EXISTS(dbo.Admins) DROP TABLE dbo.Admins");
        }

        public async Task ExecuteBooks()
        {
            await dataModel.Database.ExecuteSqlRawAsync("IF EXISTS(dbo.Books) DROP TABLE dbo.Books");
        }

        public async Task ExecuteLibraries()
        {
            await dataModel.Database.ExecuteSqlRawAsync("IF EXISTS(dbo.Libraries) DROP TABLE dbo.Libraries");
        }

        public async Task ExecuteLoans()
        {
            await dataModel.Database.ExecuteSqlRawAsync("IF EXISTS(dbo.Loans) DROP TABLE dbo.Loans");
        }

        public async Task ExecuteUsers()
        {
            await dataModel.Database.ExecuteSqlRawAsync("IF EXISTS(dbo.Users) DROP TABLE dbo.Users");
        }

        public async Task ExecuteWorkers()
        {
            await dataModel.Database.ExecuteSqlRawAsync("IF EXISTS(dbo.Users) DROP TABLE dbo.Users");
        }
    }
}
