using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataModels
{
    internal class LibDataModel
    {
        #region DbData
        [Key]
        public int Id { get; set; }

        [Column("Address", TypeName = "varchar(55)")]
        public string? Address { get; set; }

        [Column("TelephoneNumber", TypeName = "int")]
        public int TelephoneNumber { get; set; }

        [Column("WebsiteAddress", TypeName = "varchar(55)")]
        public string? WebsiteAddress { get; set; }

        [Column("EmailAddress", TypeName = "varchar(55)")]
        public string? EmailAddress { get; set; }

        [Column("NipNumber", TypeName = "int")]
        public int NipNumber { get; set; }

        [Column("RegonNumber", TypeName = "int")]
        public int RegonNumber { get; set; }

        [Column("DunsNumber", TypeName = "int")]
        public int DunsNumber { get; set; }

        [Column("Name", TypeName = "varchar(55)")]
        public string? Name { get; set; }

        [Column("DateOfCommencementOfActivities", TypeName = "DateTime")]
        public DateTime? DateOfCommencementOfActivities { get; set; }

        [Column("Voivodeship", TypeName = "varchar(55)")]
        public string? Voivodeship { get; set; }

        [Column("City", TypeName = "varchar(55)")]
        public string? City { get; set; }

        [Column("ZipCode", TypeName = "int")]
        public int ZipCode { get; set; }
        #endregion

        #region Collections
        public ICollection<Admin>? Admins { get; set; }
        public ICollection<Worker>? Workers { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<Loan>? Loans { get; set; }
        #endregion
    }
}
