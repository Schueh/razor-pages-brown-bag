using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ShortTitle { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Description { get; set; }
        
        public DateTime ReleaseDate { get; set; }
    }
}