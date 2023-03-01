using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain;
using BooksLibrary.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Persistence
{
    public class BooksLibDbContext : DbContext, IBooksDbContext
    {
        public DbSet<Book> Books { get ; set ; }
        public DbSet<Rating> Ratings { get ; set ; }
        public DbSet<Review> Reviews { get; set ; }

        public BooksLibDbContext(DbContextOptions<BooksLibDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());



            base.OnModelCreating(builder);
        }



    }
}
