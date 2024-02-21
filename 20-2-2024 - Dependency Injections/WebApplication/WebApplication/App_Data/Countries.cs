using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebApplication {

    public class Pair {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class Countries {

        public Countries() {
            Debug.WriteLine("Called Counties");
        }

        public List<Pair> GetCounties() {
            return new List<Pair> {
                new Pair {
                    Name = "India",
                    Code = "in",
                },
                new Pair {
                    Name = "America",
                    Code = "us",
                },
                new Pair {
                    Name = "France",
                    Code = "fr",
                },
                new Pair {
                    Name = "Japan",
                    Code = "jp",
                },
                new Pair {
                    Name = "Czech republic",
                    Code = "cz",
                }
            };
        }

    }

}