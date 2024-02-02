using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    /// <summary>
    /// This class adds more functionalities
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// Concatenates two strings with a separator in between
        /// </summary>
        /// <param name="_">The first string</param>
        /// <param name="S1">The second string</param>
        /// <param name="Separator">The separator to be used</param>
        /// <returns>The concatenated string</returns>
        public static string ConcatWithSeparator(this string _, string S1, string Separator) {
            return _ + Separator + S1;
        }
        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="_">The first number</param>
        /// <param name="y">The second number</param>
        /// <param name="z">The third number</param>
        /// <returns>The sum of the three numbers</returns>
        public static int Add2Nums(this int _, int y, int z) {
            return y + z + _;
        }
        /// <summary>
        /// Adds two doubles
        /// </summary>
        /// <param name="_">The first double</param>
        /// <param name="y">The second double</param>
        /// <param name="z">The third double</param>
        /// <returns>The sum of the three doubles</returns>
        public static double Add2Doubles(this double _, double y, double z) {
            return _ + y + z;
        }
    }

    internal class Program {

        /// <summary>
        /// The runner method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            Logger logger = new Logger();
            logger.Run();
            int A = int.Parse("123"); // Parsing
            int B = (int)67f; // C++ conversion
            int C = Convert.ToInt32("567"); 
            
            CoffeeShop coffeeShop = new CoffeeShop();
            var list = coffeeShop.GetAllCoffees();
            Console.WriteLine(list.Count);

            string name = "Cat";
            Console.WriteLine(name.ConcatWithSeparator("is an animal!"," "));

            int i = 9;
            Console.WriteLine(i.Add2Nums(1, 2));

            double d = 10;
            Console.WriteLine(d.Add2Doubles(5, (double)10));

            Console.ReadLine();
        }
    }
}
