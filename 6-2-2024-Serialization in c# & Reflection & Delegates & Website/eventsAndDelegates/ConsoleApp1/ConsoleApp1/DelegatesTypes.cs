using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public class DelegatesTypes {
        public static void Run() {
            Action<int, int> add = (a, b) => { // no return value
                Console.WriteLine(a + b);
            };
            add(5, 3);
            Func<int, int, String> someFun = (a, b) => { // return value
                return "Hello";
            };
            Console.WriteLine(someFun(5, 3));
            Predicate<int> isEven = (number) => { // special func delgate takes only 1 input but returns a bool value
                return number % 2 == 0;
            };
            Console.WriteLine(isEven(6));
        }
    }
}
