﻿using Microsoft.EntityFrameworkCore;

namespace ThirdDotNet.Models
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}