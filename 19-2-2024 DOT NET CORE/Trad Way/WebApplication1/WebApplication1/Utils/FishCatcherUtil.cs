using WebApplication1.Models;

namespace WebApplication1.Utils {
    public class FishCatcherUtil {
        public void CatchFish() {
            Console.WriteLine("Caught a Fish🐟!");
        }
        public List<Person> GetFishPersons() {
            return new List<Person> {
                new Person {
                    Name = "Goyal",
                    Age = 34,
                    CreatedAt = DateTime.Now,
                    Id = 6
                },new Person {
                    Name = "Prince Vhima",
                    Age = 33,
                    CreatedAt = DateTime.Now,
                    Id = 7
                },new Person {
                    Name = "Veer Singh",
                    Age = 35,
                    CreatedAt = DateTime.Now,
                    Id = 8
                },new Person {
                    Name = "Raju",
                    Age = 29,
                    CreatedAt = DateTime.Now,
                    Id = 10
                },
            };
        }
    }
}
