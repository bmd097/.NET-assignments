using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart {
    public class Person {
        public int id  { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public DateTime lastLogIn { get; set; }
        public Person(int id, string name, string email, string password, DateTime lastLogIn) {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.lastLogIn = lastLogIn;
        }
    }
}
