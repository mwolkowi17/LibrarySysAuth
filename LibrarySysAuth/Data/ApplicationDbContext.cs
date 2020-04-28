using System;
using System.Collections.Generic;
using System.Text;
using LibrarySysAuth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySysAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<BookB> BookB { get; set; }
        public DbSet<BookC> BookC { get; set; }
    }

    
}
