using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebApplication {

    public class CityPair {
        public string CountryCode { get; set; }
        public List<string> CountryNames { get; set; }
    }

    public class Cities {

        public Cities() {
            Debug.WriteLine("CITIES CALLED");
        }

        public List<CityPair> GetCities() {
            return new List<CityPair> {
                new CityPair {
                    CountryCode = "in",
                    CountryNames = new List<string> {
                        "Mumbai",
                        "Bangalore",
                        "Delhi",
                        "Kohima",
                        "Pune",
                    }
                },
                new CityPair {
                    CountryCode = "us",
                    CountryNames = new List<string> {
                        "Las Vegas",
                        "New York",
                        "Miami",
                        "San Francisco",
                        "Los Angeles",
                    }
                },
                new CityPair {
                    CountryCode = "fr",
                    CountryNames = new List<string> {
                        "Paris",
                        "Marseille",
                        "Lyon",
                        "Toulouse",
                        "Nice",
                    }
                },
                new CityPair {
                    CountryCode = "jp",
                    CountryNames = new List<string> {
                        "Tokyo",
                        "Yokohama",
                        "Osaka",
                        "Nagoya",
                        "Sapporo",
                    }
                },
                new CityPair {
                    CountryCode = "cz",
                    CountryNames = new List<string> {
                        "Prague",
                        "Brno",
                        "Ostrava",
                        "Pilsen",
                        "Liberec",
                    }
                }
            };
        }

    }
}