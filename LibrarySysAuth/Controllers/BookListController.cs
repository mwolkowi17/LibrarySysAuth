using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySysAuth.Data;
using LibrarySysAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibrarySysAuth.Controllers
{
    public class BookListController : Controller
    {

        private readonly ApplicationDbContext _context;
        public BookListController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            var bookoflist = from m in _context.BookC
                             select m;
            var bookVM = new LibraryViewModel
            {
                BookCs = bookoflist.ToList()
            };
            return View(bookVM);
        }

        // GET: /new book/

        public IActionResult AddBook(string titlebook, string authorbook)
        {
            BookC nowa = new BookC(titlebook, authorbook);
            _context.BookC.Add(nowa);
            _context.SaveChanges();

            var bookoflist = from m in _context.BookC
                             select m;
            var bookVM = new LibraryViewModel
            {
                BookCs = bookoflist.ToList()
            };


            //bookVM.AddBook(titlebook,authorbook);


            return RedirectToAction(nameof(Index));
            

        }

        // GET: /delete book/

        public IActionResult Delete (int id)
        {
            var newbook = (from BookC item in _context.BookC
                             where item.BookCID == id
                             select item).FirstOrDefault();
            _context.BookC.Remove(newbook);
            _context.SaveChanges();

            var bookoflist = from m in _context.BookC
                             select m;
            var bookVM = new LibraryViewModel
            {
                BookCs = bookoflist.ToList()
            };

            //return View(bookVM
            return RedirectToAction(nameof(Index));
        }

        //GET: /Rent book/

        public IActionResult RentBook (int idofbook, int idofreader)
        {
            var newbook = (from BookC item in _context.BookC
                           where item.BookCID == idofbook
                           select item).FirstOrDefault();
            var newreader = (from Reader n in _context.Reader
                             where n.ReaderID == idofreader
                             select n).FirstOrDefault();
            newbook.RentedbyReader = newreader.ReaderID;
            newbook.Rented = true;
            newbook.RentData = DateTime.Today;
            newbook.DropOfData = DateTime.Today.AddDays(14);
            newbook.AliasofReader = newreader.Alias;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //GET: /Drop off/

        public IActionResult DropOff (int id)
        {
            var newbook = (from BookC item in _context.BookC
                           where item.BookCID == id
                           select item).FirstOrDefault();

            newbook.RentedbyReader = 0;
            newbook.Rented = false;
           
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //GET: /Find book/

        public IActionResult FindBook (string titlebook)
        {
            var bookoflist = from BookC item in _context.BookC
                          where item.TitleC == titlebook
                          select item;
            if (bookoflist.ToList().Count != 0) { 
            var bookVM = new LibraryViewModel
            {
                BookCs = bookoflist.ToList()
            };
                return View(bookVM);
            }

            var bookoflistB = from BookC n in _context.BookC
                              where n.AuthorC == titlebook
                              select n;
            if (bookoflistB.ToList().Count != 0)
            {
                var bookVM = new LibraryViewModel
                {
                    BookCs = bookoflistB.ToList()
                };
                return View(bookVM);
            }
            else
            {
                string inform = "Niestety nie mamy tej książki";
                ViewBag.Information = inform;
                var bookVM = new LibraryViewModel
                {
                    BookCs = bookoflist.ToList()
                };
                return View(bookVM);
            }
            
        }
    }
}
