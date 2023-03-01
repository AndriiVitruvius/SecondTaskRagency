using BooksLibrary.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Persistence.EntityTypeConfiguration
{
    internal class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        void IEntityTypeConfiguration<Rating>.Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Score).HasMaxLength(5);
        }
    }
}
