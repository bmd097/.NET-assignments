using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVoyegerBackend {
    public class User {
        public int id { get; set; }
        public String name { get; set; }
        public String email { get; set; }

        public override string ToString() {
            return $"User ID: {id}\nName: {name}\nEmail: {email}";
        }
    }
}
