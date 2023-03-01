using BooksLibrary.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Interfaces
{
    public interface IBooksDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Review> Reviews { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    }
}
