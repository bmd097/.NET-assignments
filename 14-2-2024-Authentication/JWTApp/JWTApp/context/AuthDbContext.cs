using JWTApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JWTApp.context {
    public class AuthDbContext :DbContext{

        public DbSet<AuthModel> authModel {  get; set; }

        public AuthDbContext() : base("MyAuthDb") { }

    }
}