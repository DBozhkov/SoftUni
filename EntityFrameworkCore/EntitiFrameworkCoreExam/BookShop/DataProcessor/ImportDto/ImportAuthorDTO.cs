﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDTO
    {
        public ImportAuthorDTO()
        {
            this.Books = new List<ImportAuthorBookDTO>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[\d +]{3}-[\d+]{3}-[\d+]{4}$")]
        public string Phone { get; set; }
        
        public List<ImportAuthorBookDTO> Books { get; set; }
    }
}