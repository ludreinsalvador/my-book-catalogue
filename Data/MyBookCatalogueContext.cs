using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookCatalogue.Model;

namespace MyBookCatalogue.Data
{
    public class MyBookCatalogueContext : DbContext
    {
        public MyBookCatalogueContext (DbContextOptions<MyBookCatalogueContext> options)
            : base(options)
        {
        }

        public DbSet<MyBookCatalogue.Model.BookCatalogue> BookCatalogue { get; set; } = default!;
    }
}
