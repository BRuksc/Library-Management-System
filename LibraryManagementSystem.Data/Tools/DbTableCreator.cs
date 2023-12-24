using LibraryManagementSystem.Data.DataModels;
using LibraryManagementSystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tools
{
    internal class DbTableCreator : IDbTable<bool>
    {
        private readonly DbsDataModel dataModel;

        public DbTableCreator(DbsDataModel dataModel)
        {
            this.dataModel = dataModel;
        }

        public bool ExecuteLibraries()
        {
            try
            {
                dataModel.Database.ExecuteSqlRaw("CREATE TABLE dbo.Libraries\r\n(\r\n\t" +
                    "[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),\r\n\t" +
                    "[Address] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[TelephoneNumber] INT NOT NULL,\r\n\t" +
                    "[WebsiteAddress] VARCHAR(55) NULL,\r\n\t" +
                    "[EmailAddress] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[NipNumber] INT NOT NULL,\r\n\t" +
                    "[RegonNumber] INT NOT NULL,\r\n\t" +
                    "[DunsNumber] INT NOT NULL,\r\n\t" +
                    "[Name] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[DateOfCommencementOfActivities] DATETIME NOT NULL,\r\n\t" +
                    "[Voivodeship] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[City] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[ZipCode] INT NOT NULL\r\n);");

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExecuteAdmins()
        {
            try
            {
                dataModel.Database.ExecuteSqlRaw("CREATE TABLE dbo.Admins\r\n(\r\n\t" +
                    "[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),\r\n\t" +
                    "[Login] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[Password] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[LibraryId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Libraries(Id)\r\n);");

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExecuteWorkers()
        {
            try
            {
                dataModel.Database.ExecuteSqlRaw("CREATE TABLE dbo.Workers\r\n(\r\n\t" +
                    "[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),\r\n\t" +
                    "[Login] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[Password] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[LibraryId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Libraries(Id)\r\n);");

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExecuteUsers()
        {
            try
            {
                dataModel.Database.ExecuteSqlRaw("CREATE TABLE dbo.Users\r\n(\r\n\t" +
                    "[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),\r\n\t" +
                    "[Email] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[Password] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[Pesel] INT NOT NULL,\r\n\t" +
                    "[Address] VARCHAR(55) NULL,\r\n\t" +
                    "[LibraryId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Libraries(Id)\r\n);");

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExecuteBooks()
        {
            try
            {
                dataModel.Database.ExecuteSqlRaw("CREATE TABLE dbo.Books\r\n(\r\n\t" +
                    "[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),\r\n\t" +
                    "[Title] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[Author] VARCHAR(55) NOT NULL,\r\n\t" +
                    "[DateOfPublished] DATETIME NOT NULL,\r\n\t" +
                    "[IsBorrowed] BIT NULL ,\r\n\t" +
                    "[LibraryId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Libraries(Id)\r\n);");

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExecuteLoans()
        {
            try
            {
                dataModel.Database.ExecuteSqlRaw("CREATE TABLE dbo.Loans\r\n(\r\n\t" +
                    "[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),\r\n\t" +
                    "[DateOfLoan] DATETIME NOT NULL,\r\n\t" +
                    "[MaxTerm] DATETIME NOT NULL,\r\n\t" +
                    "[LibraryId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Libraries(Id),\r\n\t" +
                    "[BookId] INT NOT NULL FOREIGN KEY REFERENCES dbo.Books(Id)\r\n);");

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
