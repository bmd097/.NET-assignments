using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    public class QueriesCollector {

        private string filePath;

        public QueriesCollector(String path) {
            filePath = path;
        }

        public IEnumerable<string> Collect(){
            List<string> results = new List<string>();
            string[] lines = File.ReadAllLines(filePath);
            string currentQuery = "";
            foreach (string line in lines) {
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("--")) {
                    continue; 
                }
                currentQuery += line.Trim();
                if (currentQuery.EndsWith(";")) {
                    results.Add(currentQuery);
                    currentQuery = "";
                }
            }
            return results;
        }

    }
}
