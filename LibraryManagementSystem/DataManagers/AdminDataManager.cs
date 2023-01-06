using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibraryManagementSystem.Interfaces.Data;

namespace LibraryManagementSystem.DataManagers
{
    internal class AdminDataManager : IDataManagement<Admin>, IManyRecordsOperations<Admin>
    {
        public async Task<bool> Add(Admin data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    if (dataContext.Admins == null)
                        data.Id = 1;

                    else data.Id = dataContext.Admins.ToList().Count() + 1;

                    dataContext.Add(data);

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

        public async Task<bool> AddMany(Admin[] data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    foreach (var i in data)
                    {
                        i.Id = dataContext.Admins.ToList().Max(x => x.Id) + 1;

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

        public Task<bool> Edit(Admin oldData, Admin newData)
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

                    var admins = dataContext.Admins.ToList();
                    var dataModel = admins.Where(x => x.Id == Id).First();

                    admins.Remove(dataModel);

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

        public async Task<bool> Remove(Admin data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var admins = dataContext.Admins.ToList();
                    admins.Remove(data);

                    foreach (var i in admins)
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

        public async Task<bool> RemoveMany(Admin[] data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var admins = dataContext.Admins.ToList();

                    foreach (var i in data)
                    {
                        admins.Remove(i);

                        foreach (var y in admins)
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

        public Admin Select(Admin data)
        {
            try
            {
                var admin = new Admin();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var admins = dataContext.Admins.ToList();
                    admin = admins.First(x => (x.LibraryId == data.LibraryId) && (x.Login == data.Login)
                    && (x.Password == data.Password));

                    dataContext.SaveChangesAsync();
                    dataContext.Database.CloseConnectionAsync();
                }

                return admin;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Admin> SelectAll(int LibraryId)
        {
            throw new NotImplementedException();
        }

        public List<Admin> SelectAll(LibDataModel library)
        {
            throw new NotImplementedException();
        }

        public Admin SelectById(int Id)
        {
            try
            {
                var admin = new Admin();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var admins = dataContext.Admins.ToList();
                    admin = admins.First(x => x.Id == Id);

                    dataContext.Database.CloseConnectionAsync();
                }

                return admin;
            }


            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
