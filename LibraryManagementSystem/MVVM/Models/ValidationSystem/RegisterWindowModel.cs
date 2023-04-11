using LibraryManagementSystem.DataManagers;
using LibraryManagementSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem.MVVM.Models.ValidationSystem
{
    public class RegisterWindowModel
    {
        public string Address { get; set; }

        public string TelephoneNumber { get; set; }

        public string WebsiteAddress { get; set; }

        public string EmailAddress { get; set; }

        public string NipNumber { get; set; }

        public string RegonNumber { get; set; }

        public string DunsNumber { get; set; }

        public string Name { get; set; }

        public string DateOfCommencementOfActivities { get; set; }

        public string Voivodeship { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string AdminAccountLogin { get; set; }

        public string AdminAccountPassword { get; set; }

        public string AdminAccountRepeatPassword { get; set; }
        public bool LibraryCanBeCreated { get; set; }

        public RegisterWindowModel()
        {
            ClearAll();
        }

        public void ClearAll()
        {
            Address = string.Empty;
            TelephoneNumber = string.Empty;
            WebsiteAddress = string.Empty;
            EmailAddress = string.Empty;
            NipNumber = string.Empty;
            RegonNumber = string.Empty;
            DunsNumber = string.Empty;
            Name = string.Empty;
            DateOfCommencementOfActivities = string.Empty;
            Voivodeship = string.Empty;
            City = string.Empty;
            ZipCode = string.Empty;
            AdminAccountLogin = string.Empty;
            AdminAccountPassword = string.Empty;
            AdminAccountRepeatPassword = string.Empty;
        }

        public bool IsNecessaryDataEmpty()
        {
            if (Address == string.Empty || TelephoneNumber == string.Empty ||
                EmailAddress == string.Empty || NipNumber == string.Empty ||
                RegonNumber == string.Empty || DunsNumber == string.Empty ||
                DateOfCommencementOfActivities == string.Empty ||
                Voivodeship == string.Empty || City == string.Empty ||
                ZipCode == string.Empty || AdminAccountLogin == string.Empty ||
                AdminAccountPassword == string.Empty ||
                AdminAccountRepeatPassword == string.Empty)
                return true;

            else return false;
        }

        public async Task<bool> RegisterLibrary()
        {
            if (LibraryCanBeCreated)
            {
                try
                {
                    var lib = new LibDataModel()
                    {
                        Address = Address,
                        TelephoneNumber = Convert.ToInt32(TelephoneNumber),
                        WebsiteAddress = WebsiteAddress,
                        EmailAddress = EmailAddress,
                        NipNumber = Convert.ToInt32(NipNumber),
                        RegonNumber = Convert.ToInt32(RegonNumber),
                        DunsNumber = Convert.ToInt32(DunsNumber),
                        Name = Name,
                        DateOfCommencementOfActivities =
                        Convert.ToDateTime(DateOfCommencementOfActivities),
                        Voivodeship = Voivodeship,
                        City = City,
                        ZipCode = Convert.ToInt32(ZipCode),

                        Admins = new List<Admin>()
                    };

                    var admin = new Admin()
                    {
                        Id = 1,
                        Login = AdminAccountLogin,
                        Password = AdminAccountPassword,
                        Library = lib,
                        LibraryId = lib.Id
                    };

                    lib.Admins.Add(admin);

                    var create = await new LibraryDataManager().Add(lib);
                    var addAdmin = await new AdminDataManager().Add(admin);

                    if (create && addAdmin) return true;
                    else return false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

            else return false;
        }
    }
}
