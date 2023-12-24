using LibraryManagementSystem.Data.DataManagers;
using LibraryManagementSystem.Logic.MVVM.Models.ValidationSystem;
using LibraryManagementSystem.MVVM.Views.ValidationSystem;
using LibraryManagementSystem.WindowsPointing.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tools
{
    public class LibraryRegisterValidator
    {
        private readonly RegisterWindowModel model;
        private readonly IWindowGuidContainer windowGuidContainer;

        public LibraryRegisterValidator(RegisterWindowModel model, IWindowGuidContainer windowGuidContainer)
        {
            this.model = model;
            this.windowGuidContainer = windowGuidContainer;
        }

        public List<string> GetExceptions()
        {
            List<string> exceptions = new List<string>();

            if (model.IsNecessaryDataEmpty())
                exceptions.Add("You did not get all of necessary data!");

            if ((model.AdminAccountPassword.Length < 8) && (model.AdminAccountPassword.Length > 0))
                exceptions.Add("Admin password is too short!");

            else if (model.AdminAccountPassword.Length > 20)
                exceptions.Add("Admin password is too long!");

            if (model.AdminAccountPassword != model.AdminAccountRepeatPassword)
                exceptions.Add("Repeated password is diffrent from the password!");

            string nip1String = model.NipNumber.Substring(0, model.NipNumber.Length / 2 - 1);
            string nip2String = model.NipNumber.Remove(0, model.NipNumber.Length / 2 - 1);

            int nip1Int, nip2Int;

            bool tryParseNip1 = int.TryParse(nip1String, out nip1Int);
            bool tryParseNip2 = int.TryParse(nip2String, out nip2Int);

            if ((!tryParseNip1) || (!tryParseNip2))
                exceptions.Add("Uncorrect NIP number. Contains another characters than numbers!");

            if (model.NipNumber.Length > 10)
                exceptions.Add("Uncorrect NIP number. Value of characters is greater than 10!");

            if ((model.NipNumber.Length < 10) && (model.NipNumber.Length > 0))
                exceptions.Add("Uncorrect NIP number. Value of characters is smaller than 10!");

            int regon;

            if (!int.TryParse(model.RegonNumber, out regon))
                exceptions.Add("Uncorrect REGON number. Contains another characters than numbers!");

            if (model.RegonNumber.Length > 9)
                exceptions.Add("Uncorrect REGON number. Value of characters is greater than 9!");

            if ((model.RegonNumber.Length < 9) && (model.RegonNumber.Length > 0))
                exceptions.Add("Uncorrect REGON number. Value of characters is smaller than 9!");

            int telNum;

            if (!int.TryParse(model.TelephoneNumber, out telNum))
                exceptions.Add("Uncorrect telephone number. Contains another characters than numbers!");

            if ((!model.EmailAddress.Contains("@")) || (!model.EmailAddress.Contains(".")))
                exceptions.Add("Uncorrect email address! It has to contains \"@\" and \".\" symbols!");

            if (model.Address.Contains("\"") || model.TelephoneNumber.Contains("\"")
                || model.EmailAddress.Contains("\"") || model.NipNumber.Contains("\"")
                || model.RegonNumber.Contains("\"") || model.DunsNumber.Contains("\"")
                || model.Name.Contains("\"") || model.DateOfCommencementOfActivities.Contains("\"")
                || model.Voivodeship.Contains("\"") || model.City.Contains("\"") || model.ZipCode.Contains("\"")
                || model.AdminAccountLogin.Contains("\"") || model.AdminAccountPassword.Contains("\"")
                || model.AdminAccountRepeatPassword.Contains("\""))
                exceptions.Add("None variable can contains \" symbol!");

            if (model.DunsNumber.Length > 9)
                exceptions.Add("Uncorrect DUNS number. Value of characters is greater than 9!");

            if ((model.DunsNumber.Length < 9) && (model.DunsNumber.Length > 0))
                exceptions.Add("Uncorrect DUNS number. Value of characters is smaller than 9!");

            int dunsNumber;

            if (!int.TryParse(model.DunsNumber, out dunsNumber))
                exceptions.Add("Uncorrect DUNS number. Contains another characters than numbers!");

            if (model.ZipCode.Length != 6)
                exceptions.Add("Uncorrect ZIP code!");

            if ((model.Voivodeship != "Dolnośląskie") && (model.Voivodeship != "Kujawsko-pomorskie")
                && (model.Voivodeship != "Lubelskie") && (model.Voivodeship != "Lubuskie")
                && (model.Voivodeship != "Łódzkie") && (model.Voivodeship != "Mazowieckie")
                && (model.Voivodeship != "Opolskie") && (model.Voivodeship != "Podkarpackie")
                && (model.Voivodeship != "Podlaskie") && (model.Voivodeship != "Pomorskie")
                && (model.Voivodeship != "Śląskie") && (model.Voivodeship != "Świętokrzyskie")
                && (model.Voivodeship != "Warmińsko-mazurskie") && (model.Voivodeship != "Wielkopolskie")
                && (model.Voivodeship != "Zachodnio-pomorskie"))
                exceptions.Add("That voivodeship does not exist in Poland!");

            var libDataManager = new LibraryDataManager();

            if ((libDataManager.SelectByNip(nip1Int) != null) ||
                (libDataManager.SelectByDuns(dunsNumber) != null) ||
                (libDataManager.SelectByRegon(regon) != null) ||
                ((libDataManager.SelectByEmail(model.EmailAddress) != null)))
                exceptions.Add("Name, duns number, email and regon have to be unique!");

            return exceptions;
        }

        public async Task<bool> SendRegistrationEmail()
        {
            int[] code = new int[4];

            var rnd = new Random();

            code[0] = rnd.Next(1, 9);
            code[1] = rnd.Next(1, 9);
            code[2] = rnd.Next(1, 9);
            code[3] = rnd.Next(1, 9);

            string verifyingCode = code[0].ToString() + code[1].ToString()
            + code[2].ToString() + code[3].ToString();

            string emailBody = " Hi, here is Library Management System team, we would like to " +
            "confirmation your registration. Write this code to application: " + verifyingCode;

            if (EmailSender.Send("botlibrarysystemmanagement@gmail.com",
            model.EmailAddress,
            "Registration confirmation on Library Management System",
            "User",
            emailBody,
            "SECRET-CODE"))
            {
                var verifyingView = new EmailCodeVerification
                (this.model, verifyingCode, EmailCodeModel.VerifyingRegistration, windowGuidContainer);
                verifyingView.Show();

                return true;
            }

            else return false;
        }
    }
}
