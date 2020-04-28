using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySysAuth.Models
{
    public class LibraryViewModel
    {
       
        public List<Reader> Readers { get; set; }
        public List<BookB> BookBs { get; set; }
        public List<BookC> BookCs { get; set; }

        public void AddBook(  string title, string author)
        {
            BookB newbook = new BookB( title, author)
            {
                
                TitleB = title,
                AuthorB = author
            };

            BookBs.Add(newbook);
        }       
    }
}
