using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DataModels
{
    internal class DbsDataModel : DbContext
    {
        #region ConnString
        private const string connectionString =
            "Server=localhost;Database=DbLibraryManager;Trusted_Connection=true;";
        #endregion

        #region Tables
        public DbSet<LibDataModel> Libraries => Set<LibDataModel>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Worker> Workers => Set<Worker>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Loan> Loans => Set<Loan>();
        #endregion

        #region Methods
        public DbsDataModel() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibDataModel>()
                .ToTable("Libraries", x => x.ExcludeFromMigrations()).HasKey(x => x.Id);
            modelBuilder.Entity<Admin>().ToTable("Admins").HasKey(x => x.Id);
            modelBuilder.Entity<Worker>().ToTable("Workers").HasKey(x => x.Id);
            modelBuilder.Entity<User>().ToTable("Users").HasKey(x => x.Id);
            modelBuilder.Entity<Book>().ToTable("Books").HasKey(x => x.Id);
            modelBuilder.Entity<Loan>().ToTable("Loans").HasKey(x => x.Id);

            modelBuilder.Entity<LibDataModel>().HasMany(x => x.Admins).WithOne(x => x.Library);
            modelBuilder.Entity<LibDataModel>().HasMany(x => x.Workers).WithOne(x => x.Library);
            modelBuilder.Entity<LibDataModel>().HasMany(x => x.Users).WithOne(x => x.Library);
            modelBuilder.Entity<LibDataModel>().HasMany(x => x.Books).WithOne(x => x.Library);
            modelBuilder.Entity<LibDataModel>().HasMany(x => x.Loans).WithOne(x => x.Library);

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
