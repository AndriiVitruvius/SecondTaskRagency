using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain
{
    public class Rating
    {
        public uint Id { get; set; }
        public int Score { get; set; }
        public uint BookId { get; set; }
        public Book Book { get; set; }  
    }
}
