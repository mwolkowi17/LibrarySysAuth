using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySysAuth.Models
{
    public class BookB
    {
        public int BookBID { get; set; }
        public string TitleB { get; set; }
        public string AuthorB { get; set; }
        public bool Rented { get; set; }
        public int RentedbyReader { get; set; }

        public BookB(  string title, string author)
        {
            
            TitleB = title;
            AuthorB = author;
        }

        public BookB()
        {

        }
    } 

}
