using BookStoreInlämning4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreInlämning4.Data
{
    internal class BookstoreDbContext : DbContext
    {
        private static BookstoreDbContext? _dbContext;

        public static BookstoreDbContext? DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new BookstoreDbContext();
                }
                return _dbContext;
            }
        }

        public DbSet<Author> _Authors { get; set; }
        public DbSet<Books> _Books { get; set; }
        public DbSet<Categories> _Categories { get; set; }
        public DbSet<Store> _Stores { get; set; }

        public DbSet<InventoryBalance> _InventoryBalance { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreInlämning4;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
