using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Models;

namespace UnitTest.Services
{
    public interface IReservation
    {
        PNRInfo Generate(string name);
    }
}
