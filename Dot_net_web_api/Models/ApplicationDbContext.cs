using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dot_net_web_api.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") {
            
        }
        public DbSet<Product2> product2s { get; set; }
    }
}