using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace resterauntWeb.Models
{
  
        public class ApplicationDbContext : DbContext
        {

            public ApplicationDbContext() : base("RestDb2")
            {


            }
        public DbSet<Restaurant> Resteraunt { get; set; }

        public System.Data.Entity.DbSet<resterauntWeb.Models.Reviews> Reviews { get; set; }
    }
}