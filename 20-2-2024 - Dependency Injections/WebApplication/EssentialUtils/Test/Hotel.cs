using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialUtils.Test {
    public class Hotel {
        private Ostrich ostrich;
        private Fish fish;
        public Hotel(Ostrich ostrich,Fish fish) {
            this.ostrich = ostrich;
            this.fish = fish;
            Console.WriteLine("Hotel Created!");
        }
    }
}
