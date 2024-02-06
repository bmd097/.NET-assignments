using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {

    [MyCustomAttribute(123,"Doggy")]
    public class Dog {
        [MyCustomAttribute(1234, "Doggy_Bark")]
        public void Bark() {
            Console.WriteLine("Wow Bow");
        }
        [MyCustomAttribute(1235, "Doggy_Eat")]
        public void Eat() {
            Console.WriteLine("Eating Dog!");
        }
    }

    public class Program {
        static void Main(string[] args) {
            Action<object> log = Console.WriteLine;
            // Reflection
            Type type = typeof(Dog);
            foreach (var classAttribute in type.GetCustomAttributes(true)) {
                if (classAttribute is MyCustomAttribute) {
                    MyCustomAttribute customAttribute = classAttribute as MyCustomAttribute;
                    if (customAttribute != null) {
                        log(customAttribute.Id);
                        log(customAttribute.Name);
                    }
                    log("");
                    var methods = type.GetMethods();
                    foreach (var method in methods) {
                        foreach (var methodAttribute in method.GetCustomAttributes(true)) {
                            if (methodAttribute is MyCustomAttribute) {
                                log(method.Name);
                                MyCustomAttribute customMethodAttribute = methodAttribute as MyCustomAttribute;
                                if (customMethodAttribute != null) {
                                    log(customMethodAttribute.Id);
                                    log(customMethodAttribute.Name);
                                }
                                log("");
                            }
                        }
                        
                    }
                }   
            }
            Console.ReadLine();
        }
    }
}
