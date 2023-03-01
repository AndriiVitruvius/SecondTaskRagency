using BooksLibrary.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Persistence.EntityTypeConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Title).HasMaxLength(512);
            builder.HasMany(b => b.Reviews).WithOne(r => r.Book).HasForeignKey(r => r.BookId);
            builder.HasMany(b => b.Ratings).WithOne(r => r.Book).HasForeignKey(r => r.BookId);

        }
    }
}
