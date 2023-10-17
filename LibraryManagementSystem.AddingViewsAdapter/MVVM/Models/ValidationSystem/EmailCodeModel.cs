using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.MVVM.Models.ValidationSystem
{
    internal class EmailCodeModel
    {
        public readonly RegisterWindowModel RegisterData;
        public readonly string VerifyingCode;

        public static string VerifyingRegistration
        {
            get => "VerifyingRegistration";
        }

        public string WindowCode { get; set; }

        public EmailCodeModel(RegisterWindowModel registerData, string verifyingCode)
        {
            RegisterData = registerData;
            VerifyingCode = verifyingCode;
        }
    }
}
