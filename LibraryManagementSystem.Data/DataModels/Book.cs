using LibraryManagementSystem.Data.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.DataModels
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = String.Empty;

        [Required]
        public string Author { get; set; } = String.Empty;

        [Required]
        public DateTime DateOfPublished { get; set; }
        public bool IsBorrowed { get; set; }

        [ForeignKey("Libraries")]
        public int LibraryId { get; set; }

        public virtual LibDataModel? Library { get; set; }
    }
}
