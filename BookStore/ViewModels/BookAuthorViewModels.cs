﻿using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookAuthorViewModels
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(20,MinimumLength =5)]
        public string Title { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 5)]
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public List<Author> Authors { set; get; }
    }
}
