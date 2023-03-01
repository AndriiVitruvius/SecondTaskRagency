using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public uint BookId { get; set; }
        public  string Reviewer { get; set; }   
        public Book Book { get; set; }

    }
}
