using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        public DateTime RentData { get; set; }
        [DataType(DataType.Date)]
        public DateTime DropOfData { get; set; }
        public string AliasofReader { get; set; }

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
