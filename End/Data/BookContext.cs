using System;
using Microsoft.EntityFrameworkCore;
using Bookstore.Models;

namespace Bookstore.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        { 

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Lord of the Rings", Description = "Lorem ipsum", Author = "J.R.R. Tolkien", ReleaseDate = new DateTime(1950, 2, 4), ShortTitle="lotr" },
                new Book { Id = 2, Title = "Harry Potter", Description = "Lorem ipsum", Author = "J.K. Rowling", ReleaseDate = new DateTime(2001, 10, 15), ShortTitle="hp" },
                new Book { Id = 3, Title = "Get Programming with F#", Description = "Lorem ipsum", Author = "Isaac Abraham", ReleaseDate = new DateTime(2016, 8, 23), ShortTitle = "fsharp" },
                new Book { Id = 4, Title = "Clean Code", Description = "Lorem ipsum", Author = "Robert C. Martin", ReleaseDate = new DateTime(2006, 6, 3), ShortTitle = "clean-code" },
                new Book { Id = 5, Title = "Are your Lights on?", Description = "Lorem ipsum", Author = "Gerald M. Weinberg", ReleaseDate = new DateTime(1995, 3, 30), ShortTitle="lights-on" },
                new Book { Id = 6, Title = "The Only Story", Description = "Lorem ipsum", Author = "Julian Barnes", ReleaseDate = new DateTime(2019, 2, 1), ShortTitle = "only-story" }
            );
        }
    }
}