using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Models;

namespace UnitTest.Services
{
    public class ReservationService
    {
        private readonly IReservation reservation;

        public ReservationService(IReservation reservation)
        {
            this.reservation = reservation;
        }

        public PNRInfo GenerateReservation(string name)
        {
            return reservation.Generate(name);
        }
    }
}
