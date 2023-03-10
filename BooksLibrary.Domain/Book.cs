using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain
{
    public class Book
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Cover { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public virtual List<Review> Reviews { get; set; }
        public virtual  List<Rating> Ratings { get; set; }
    }
}
