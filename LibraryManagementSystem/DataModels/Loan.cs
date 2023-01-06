﻿using LibraryManagementSystem.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    internal class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfLoan { get; set; }

        [Required]
        public DateTime MaxTerm { get; set; }

        [ForeignKey("libraries")]
        [Required]
        public int LibraryId { get; set; }

        [Required]
        public int BookId { get; set; }

        public virtual LibDataModel? Library { get; set; }
    }
}
