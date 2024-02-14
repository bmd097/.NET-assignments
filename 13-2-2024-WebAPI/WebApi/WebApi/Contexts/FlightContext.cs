using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.contexts {
    public class FlightContext : DbContext {

        public FlightContext() : base("FlightDb") { }

        public DbSet<Flight> flights { get; set; }

    }
}