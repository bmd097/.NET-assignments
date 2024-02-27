using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Models;

namespace UnitTest.Services
{
    public class FlightReservation : IReservation
    {
        public PNRInfo Generate(string name)
        {
            return new PNRInfo
            {
                CreatedAt = DateTime.Now,
                Pnr = "sc7suc",
                Status = true
            };
        }
    }
}
