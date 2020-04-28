using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySysAuth.Models
{
    public class BookC
    {
        public int BookCID { get; set; }
        public string TitleC { get; set; }
        public string AuthorC { get; set; }
        public bool Rented { get; set; }
        public int RentedbyReader { get; set; }

        public BookC(string title, string author)
        {

            TitleC = title;
            AuthorC = author;
        }

        public BookC()
        {

        }
    }
}
