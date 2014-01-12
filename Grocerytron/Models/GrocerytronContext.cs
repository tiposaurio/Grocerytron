using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Grocerytron.Models
{
    public class GrocerytronContext : DbContext
    {
        public GrocerytronContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<List> Lists { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}