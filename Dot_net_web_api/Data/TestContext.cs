﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dot_net_web_api.Data
{
    public class TestContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TestContext() : base("name=TestContext")
        {
        }

        public System.Data.Entity.DbSet<Dot_net_web_api.Models.Product2> Product2 { get; set; }
    }
}
