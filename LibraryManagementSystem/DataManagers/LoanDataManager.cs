using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DataModels;
using System.Windows;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Interfaces.Data;

namespace LibraryManagementSystem.DataManagers
{
    internal class LoanDataManager : IDataManagement<Loan>, IManyRecordsOperations<Loan>
    {
        public async Task<bool> Add(Loan data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var loans = dataContext.Loans.ToList();
                    loans.Add(data);

                    await dataContext.SaveChangesAsync();
                    await dataContext.Database.CloseConnectionAsync();
                }

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Task<bool> AddMany(Loan[] data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(Loan oldData, Loan newData)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int Id)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var loans = dataContext.Loans.ToList();
                    var dataModel = loans.Where(x => x.Id == Id).First();

                    loans.Remove(dataModel);

                    await dataContext.SaveChangesAsync();
                    await dataContext.Database.CloseConnectionAsync();
                }

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> Remove(Loan data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var loans = dataContext.Loans.ToList();
                    loans.Remove(data);

                    foreach (var i in loans)
                    {
                        if (i.Id > data.Id)
                            i.Id--;
                    }

                    await dataContext.SaveChangesAsync();
                    await dataContext.Database.CloseConnectionAsync();
                }

                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Task<bool> RemoveMany(Loan[] data)
        {
            throw new NotImplementedException();
        }

        public Loan Select(Loan data)
        {
            try
            {
                var loan = new Loan();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var loans = dataContext.Loans.ToList();
                    loan = loans.First(x => x == data);

                    dataContext.SaveChangesAsync();
                    dataContext.Database.CloseConnectionAsync();
                }

                return loan;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Loan> SelectAll(int LibraryId)
        {
            try
            {
                var loans = new List<Loan>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var allOfLoans = dataContext.Loans.ToList();
                    allOfLoans = (List<Loan>)allOfLoans.Where(x => x.LibraryId == LibraryId);

                    dataContext.Database.CloseConnectionAsync();
                }

                return loans;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Loan> SelectAll(LibDataModel library)
        {
            try
            {
                var loans = new List<Loan>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var allOfLoans = dataContext.Loans.ToList();
                    loans = (List<Loan>)allOfLoans.Where(x => x.LibraryId == library.Id);

                    dataContext.Database.CloseConnectionAsync();
                }

                return loans;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public Loan SelectById(int Id)
        {
            try
            {
                var loan = new Loan();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var loans = dataContext.Loans.ToList();
                    loan = loans.First(x => x.Id == Id);

                    dataContext.Database.CloseConnectionAsync();
                }

                return loan;
            }


            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
