using LibraryManagementSystem.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tools
{
    public class DbCreator
    {
        private readonly DbsDataModel dataModel;

        public DbCreator(DbsDataModel dataModel)
        { 
            this.dataModel = dataModel;
        }

        public bool CreateDb()
        {
            try
            {
                if (!(dataModel.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                {
                    var creator = dataModel.Database.GetService<IDatabaseCreator>().EnsureCreated();
                    var createTables = CreateTables();
                }

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        private bool CreateTables()
        {
            try
            {
                var DbTableCreator = new DbTableCreator(dataModel);

                var lib = DbTableCreator.ExecuteLibraries();
                var admins = DbTableCreator.ExecuteAdmins();
                var workers = DbTableCreator.ExecuteWorkers();
                var users = DbTableCreator.ExecuteUsers();
                var books = DbTableCreator.ExecuteBooks();
                var loans = DbTableCreator.ExecuteLoans();

                if ((!lib) || (!admins) || (!workers) || (!users) || (!books) || (!loans))
                    return false;

                else return true;
            }

            catch (Exception)
            {
                new DbTableDroper(dataModel).DropAll();
                return false;
            }
        }
       
    }
}
