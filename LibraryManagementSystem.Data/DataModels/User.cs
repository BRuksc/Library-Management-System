using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.DataModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Surname { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
        [Required]
        public int Pesel { get; set; }

        public string? Address { get; set; }

        [ForeignKey("libraries")]
        public int LibraryId { get; set; }

        public LibDataModel? Library { get; set; }
    }
}
