using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    [Serializable]
    public class Person {
        public String name { get; set; }
        public String email { get; set; }
        public int age { get; set; }
        public DateTime createdAt {
            get; set;
        }
        public bool isMale { get; set; }
    }
}
