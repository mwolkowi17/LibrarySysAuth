using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySysAuth.Data;
using LibrarySysAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibrarySysAuth.Controllers
{
    //[Authorize]
    public class ReadersListController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReadersListController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            var readeroflist = from m in _context.Reader
                             select m;
            var readerVM = new LibraryViewModel
            {
                Readers = readeroflist.ToList()
            };
            return View(readerVM);
        }

        //GET: /add user/

        public IActionResult AddUser(string nameuser, string surnameuser)
        {
            Reader nowy = new Reader(nameuser, surnameuser);
            _context.Reader.Add(nowy);
            _context.SaveChanges();
            var readeroflist = from m in _context.Reader
                               select m;
            var readerVM = new LibraryViewModel
            {
                Readers = readeroflist.ToList()
            };
            return View(readerVM);
        }

        //GET: /delete user/

        public IActionResult Delete(int id)
        {
            var newuser = (from Reader item in _context.Reader
                           where item.ReaderID == id
                           select item).FirstOrDefault();
            _context.Reader.Remove(newuser);
            _context.SaveChanges();
            var readeroflist = from m in _context.Reader
                               select m;
            var readerVM = new LibraryViewModel
            {
                Readers = readeroflist.ToList()
            };
            //return View(readerVM);
            return RedirectToAction(nameof(Index));
        }

        //GET: /Select user/

        public IActionResult Select(int id)
        {
            var newuser = (from Reader item in _context.Reader
                           where item.ReaderID == id
                           select item).FirstOrDefault();

            var bookoflist = from n in _context.BookC
                             where n.RentedbyReader == newuser.ReaderID
                             select n;
            var bookVM = new LibraryViewModel
            {
                BookCs = bookoflist.ToList()
            };

            ViewBag.Nameuser = newuser.Name;
            ViewBag.Surnameuser = newuser.Surname;
            return View(bookVM);
        }
    }
}
