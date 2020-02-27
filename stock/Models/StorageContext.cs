using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace stock.Models
{
    public class StorageContext : DbContext
    {
            public DbSet<Storage> Storages { get; set; }
            public DbSet<Product> Products { get; set; }
        public StorageContext(DbContextOptions<StorageContext> options)
                : base(options)
            {
                Database.EnsureCreated();   
            }
       
    }
}
