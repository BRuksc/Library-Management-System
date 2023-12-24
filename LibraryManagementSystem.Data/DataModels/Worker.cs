using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.DataModels
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;

        [ForeignKey("Libraries")]
        public int LibraryId { get; set; }

        public LibDataModel? Library { get; set; }
    }
}
