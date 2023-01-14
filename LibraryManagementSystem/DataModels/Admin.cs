using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataModels
{
    internal class Admin
    {
        [Key]
        public int Id { get; set; }

        [Column("Login", TypeName = "varchar(55)")] 
        [Required]
        public string Login { get; set; } = String.Empty;

        [Column("Password", TypeName = "varchar(55)")]
        [Required]
        public string Password { get; set; } = String.Empty;

        [ForeignKey("Libraries")]
        [Required]
        public int LibraryId { get; set; }

        public LibDataModel? Library { get; set; }
    }
}
