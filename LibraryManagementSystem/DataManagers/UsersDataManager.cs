using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManagementSystem.DataManagers
{
    internal class UsersDataManager : IDataManagement<User>, IManyRecordsOperations<User>
    {
        public async Task<bool> Add(User data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var users = dataContext.Users.ToList();
                    users.Add(data);

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

        public async Task<bool> AddMany(User[] data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    foreach (var i in data)
                    {
                        i.Id = dataContext.Users.ToList().Max(x => x.Id) + 1;

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

        public Task<bool> Edit(User oldData, User newData)
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

                    var users = dataContext.Users.ToList();
                    var dataModel = users.Where(x => x.Id == Id).First();

                    users.Remove(dataModel);

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

        public async Task<bool> Remove(User data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var users = dataContext.Users.ToList();
                    users.Remove(data);

                    foreach (var i in users)
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

        public async Task<bool> RemoveMany(User[] data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var users = dataContext.Users.ToList();

                    foreach (var i in data)
                    {
                        users.Remove(i);

                        foreach (var y in users)
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

        public User Select(User data)
        {
            try
            {
                var user = new User();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var users = dataContext.Users.ToList();
                    user = users.First(x => (x.LibraryId == data.LibraryId) && (x.Email == data.Email)
                    && (x.Password == data.Password));

                    dataContext.SaveChangesAsync();
                    dataContext.Database.CloseConnectionAsync();
                }

                return user;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> SelectAll(int LibraryId)
        {
            try
            {
                var users = new List<User>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var allOfUsers = dataContext.Users.ToList();
                    users = (List<User>)allOfUsers.Where(x => x.LibraryId == LibraryId);

                    dataContext.Database.CloseConnection();
                }

                return users;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> SelectAll(LibDataModel library)
        {
            try
            {
                var users = new List<User>();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var allOfUsers = dataContext.Users.ToList();
                    users = (List<User>)allOfUsers.Where(x => x.LibraryId == library.Id);

                    dataContext.Database.CloseConnection();
                }

                return users;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public User SelectById(int Id)
        {
            try
            {
                var user = new User();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var users = dataContext.Users.ToList();
                    user = users.First(x => x.Id == Id);

                    dataContext.Database.CloseConnectionAsync();
                }

                return user;
            }


            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
