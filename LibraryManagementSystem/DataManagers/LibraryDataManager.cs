using LibraryManagementSystem.DataModels;
using LibraryManagementSystem.DataManagers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using LibraryManagementSystem.Interfaces.Data;

namespace LibraryManagementSystem.DataManagers
{
    internal class LibraryDataManager : IDataManagement<LibDataModel>
    {
        public LibDataModel SelectByName(string name)
        {
            try
            {
                var lib = new LibDataModel();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libs = dataContext.Libraries.ToList();
                    lib = libs.First(x => x.Name == name);

                    dataContext.Database.CloseConnectionAsync();
                }

                return lib;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public LibDataModel SelectByDuns(int dunsNumber)
        {
            try
            {
                var lib = new LibDataModel();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libs = dataContext.Libraries.ToList();
                    lib = libs.First(x => x.DunsNumber == dunsNumber);

                    dataContext.Database.CloseConnectionAsync();
                }

                return lib;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public LibDataModel SelectByRegon(int regonNumber)
        {
            try
            {
                var lib = new LibDataModel();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libs = dataContext.Libraries.ToList();
                    lib = libs.First(x => x.RegonNumber == regonNumber);

                    dataContext.Database.CloseConnectionAsync();
                }

                return lib;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public LibDataModel SelectByEmail(string email)
        {
            try
            {
                var lib = new LibDataModel();

                using (var dataContext = new DbsDataModel())
                {
                    if (dataContext.Libraries != null)
                    {
                        dataContext.Database.OpenConnection();

                        var libs = dataContext.Libraries.ToList();
                        lib = libs.First(x => x.EmailAddress == email);

                        dataContext.Database.CloseConnectionAsync();
                    }
                }

                return lib;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public LibDataModel SelectByNip(int nip)
        {
            try
            {
                var lib = new LibDataModel();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libs = dataContext.Libraries.ToList();
                    lib = libs.First(x => x.NipNumber == nip);

                    dataContext.Database.CloseConnectionAsync();
                }

                return lib;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public LibDataModel SelectById(int Id)
        {
            try
            {
                var lib = new LibDataModel();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libs = dataContext.Libraries.ToList();
                    lib = libs.First(x => x.Id == Id);

                    dataContext.Database.CloseConnectionAsync();
                }

                return lib;
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<bool> Add(LibDataModel data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    if (dataContext.Libraries == null)
                        data.Id = 1;

                    else data.Id = dataContext.Libraries.ToList().Count() + 1;

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

        public async Task<bool> Remove(int Id)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libs = dataContext.Libraries.ToList();
                    var dataModel = libs.Where(x => x.Id == Id).First();

                    libs.Remove(dataModel);

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

        public async Task<bool> Remove(LibDataModel data)
        {
            try
            {
                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libs = dataContext.Libraries.ToList();
                    libs.Remove(data);

                    foreach (var i in libs)
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

        public async Task<bool> Edit(LibDataModel oldData, LibDataModel newData)
        {
            return false;
        }

        public LibDataModel Select(LibDataModel data)
        {
            try
            {
                var lib = new LibDataModel();

                using (var dataContext = new DbsDataModel())
                {
                    dataContext.Database.OpenConnection();

                    var libraries = dataContext.Libraries.ToList();
                    lib = libraries.First(x => x == data);

                    dataContext.Database.CloseConnectionAsync(); 
                }

                return lib;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
