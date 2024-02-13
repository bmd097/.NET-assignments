using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApp.contexts {
    public class MyDBContext : DbContext {

        public MyDBContext() : base("MyDB") {  }

        public DbSet<ArticleModel> Articles { get; set; }
    }
}