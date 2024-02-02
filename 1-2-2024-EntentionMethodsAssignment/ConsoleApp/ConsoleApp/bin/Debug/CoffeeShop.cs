using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    /// <summary>
    /// This enum defines all the different types of Coffee
    /// </summary>
    enum CoffeeType {
        LIGHT, MEDIUM, STRONG
    }

    /// <summary>
    /// Its a simple coffee class!
    /// </summary>
    class Coffee {
        #region Attributes
        /// <summary>
        /// Gets or sets the Id of the coffee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the coffee.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the coffee.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the coffee.
        /// </summary>
        public CoffeeType Type { get; set; }
        #endregion

        /// <summary>
        /// Constructor to initialize coffee properties.
        /// </summary>
        /// <param name="Id">The Id of the coffee.</param>
        /// <param name="Name">The name of the coffee.</param>
        /// <param name="Description">The description of the coffee.</param>
        /// <param name="Type">The type of the coffee.</param>
        public Coffee(int Id, String Name, String Description, CoffeeType Type) {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Type = Type;
        }
    }

    internal class CoffeeShop {
        private List<Coffee> coffees = new List<Coffee> {
            new Coffee (1,"Latte","Taste like milk!",CoffeeType.LIGHT),
            new Coffee (2,"Cappacino","Best Coffee!",CoffeeType.MEDIUM),
            new Coffee (3,"Expresso","Extreme Hard Coffee!",CoffeeType.STRONG),
            new Coffee (4,"Arabica","Indian Coffee!",CoffeeType.MEDIUM)
        };

        /// <summary>
        /// Gets all the coffees in the coffee shop.
        /// </summary>
        /// <returns>A list of all the coffees.</returns>
        public List<Coffee> GetAllCoffees() {
            return coffees;
        }

        /// <summary>
        /// Gets a specific coffee by its Id.
        /// </summary>
        /// <param name="Id">The Id of the coffee.</param>
        /// <returns>The coffee with the specified Id.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the Id is less than 0.</exception>
        /// <exception cref="Exception">Thrown when the Id is greater than the number of coffees.</exception>
        public Coffee GetCoffee(int Id) {
            if (Id < 0) throw new ArgumentOutOfRangeException();
            if (Id > coffees.Count) throw new Exception("Bad Index!");
            return coffees[Id];
        }

        /// <summary>
        /// Gets all the coffees of a specific type.
        /// </summary>
        /// <param name="Type">The type of coffee.</param>
        /// <returns>A list of coffees of the specified type.</returns>
        public List<Coffee> GetCoffeeFromType(CoffeeType Type) {
            List<Coffee> coffeesToReturn = new List<Coffee>();
            foreach (Coffee coffee in coffees)
                if (coffee.Type.Equals(Type))
                    coffeesToReturn.Add(coffee);
            return coffeesToReturn;
        }
    }
}