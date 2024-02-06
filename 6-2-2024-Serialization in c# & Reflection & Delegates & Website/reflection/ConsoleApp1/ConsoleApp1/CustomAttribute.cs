using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,AllowMultiple = true)]
    public class MyCustomAttribute : System.Attribute {
        private int id;
        private string name;
        public MyCustomAttribute(int id, string name) {
            this.id = id;
            this.name = name;
        }
        public int Id { get { return id; } }
        public string Name { get { return name; } }
    }
}
