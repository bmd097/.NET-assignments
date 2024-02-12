using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVoyegerBackend {
    internal class Program {
        static void Main(string[] args) {

            var api = WordVoyegerAPI.GetInstance();
            

            User user = new User();
            Console.WriteLine(api.SignIn("kavya@epam.com", "Kavya@9876", out user));

            Console.ReadLine();

        }
    }
}