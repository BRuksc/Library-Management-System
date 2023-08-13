using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;

namespace LibraryManagementSystem.DataManagers
{
    public class WorkersDataManager : IDataManagement<Worker>, IManyRecordsOperations<Worker>
    {
        public async Task<bool> Add(Worker data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var workers = dataContext.Workers.ToList();
                    workers.Add(data);

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

        public async Task<bool> AddMany(Worker[] data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    foreach (var i in data)
                    {
                        i.Id = dataContext.Workers.ToList().Max(x => x.Id) + 1;

                        dataContext.Add(i);
                        await dataContext.SaveChangesAsync();
                    }

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

        public Task<bool> Edit(Worker oldData, Worker newData)
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

                    var workers = dataContext.Workers.ToList();
                    var dataModel = workers.Where(x => x.Id == Id).First();

                    workers.Remove(dataModel);

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

        public async Task<bool> Remove(Worker data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var workers = dataContext.Workers.ToList();
                    workers.Remove(data);

                    foreach (var i in workers)
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

        public async Task<bool> RemoveMany(Worker[] data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var workers = dataContext.Workers.ToList();

                    foreach (var i in data)
                    {
                        workers.Remove(i);

                        foreach (var y in workers)
                        {
                            if (y.Id > i.Id)
                                y.Id--;
                        }
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

        public Worker Select(Worker data)
        {
            try
            {
                var worker = new Worker();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var workers = dataContext.Workers.ToList();
                    worker = workers.First(x => (x.LibraryId == data.LibraryId) && (x.Login == data.Login)
                    && (x.Password == data.Password));

                    dataContext.SaveChangesAsync();
                    dataContext.Database.CloseConnectionAsync();
                }

                return worker;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Worker> SelectAll(int LibraryId)
        {
            throw new NotImplementedException();
        }

        public List<Worker> SelectAll(LibDataModel library)
        {
            throw new NotImplementedException();
        }

        public Worker SelectById(int Id)
        {
            try
            {
                var worker = new Worker();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var workers = dataContext.Workers.ToList();
                    worker = workers.First(x => x.Id == Id);

                    dataContext.Database.CloseConnectionAsync();
                }

                return worker;
            }


            catch (Exception ex)
            {
                return null;
            }
        }

        IEnumerable<Worker> IManyRecordsOperations<Worker>.SelectAll(int LibraryId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Worker> IManyRecordsOperations<Worker>.SelectAll(LibDataModel library)
        {
            throw new NotImplementedException();
        }
    }
}
