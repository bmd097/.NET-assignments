using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialUtils.Test {
    public class Fish {
        private Gills gills;
        public Fish(Gills gills) {
            this.gills = gills;
            Console.WriteLine("Fish Created!");
        }
    }
}
