using JWTApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtils {
    internal class Program {
        static void Main(string[] args) {
            JWTUtils.secretKey = "jbjbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbjbjbjbjbjbj";
            string rea = JWTUtils.GetToken(new Dictionary<string, string> {
                { "hjn","jjbjbjb" },
                { "oij","guijhhi" }
            });
            Console.WriteLine(rea);
            var dict = new Dictionary<string, string>();
            JWTUtils.VerifyToken(rea, out dict);
            foreach (var trav in dict) {
                Console.WriteLine(trav.Key + " - " + trav.Value);
            }
            Console.Read();
        }
    }
}
