using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public class Animal {
        public Animal() { }
        public void MakeSound() {
            Console.WriteLine("I am Animal!");
        }
    }
    public class Cat:Animal {
        public void MakeSound() {
            Console.WriteLine("I am Cat!");
        }
    }
    public class Ostrich : Animal {}
    public class CovarienceAndContravarienceTypes {

        // Covarience :: Return Type
        // Covariance allows you to use a more derived type in place of a less derived type.
        // It preserves the assignment compatibility relationship between types.
        public delegate Animal DoSomethingCallback(int a);
        public event DoSomethingCallback DoSomething;
        public Animal Sound(int a) => new Animal();
        public Cat SoundKorea(int a) => new Cat(); // Cat is also an Animal

        // Contravariance :: Parameter
        // Contravariance allows you to use a less derived type in place of a more
        // derived type.
        // It reverses the assignment compatibility relationship between types.
        public delegate int DoSomethingMagicCallback(Cat animal);
        public event DoSomethingMagicCallback DoSomthingMagic;
        public int Food(Cat a) => 1;
        public int FoodKorea(Animal a) => 0;

        public void Run() {
            DoSomething += Sound;
            DoSomething += SoundKorea;

            DoSomthingMagic += Food;
            DoSomthingMagic += FoodKorea; // This is also allowed due to contravariance.
            // In the second line, even though FoodKorea expects an Animal, it’s allowed
            // to be assigned to DoSomthingMagic which expects a Cat.This is because any
            // Cat is also an Animal, but not all Animal objects are Cat objects. This
            // is the concept of contravariance.

            Cat cat = new Cat();
            cat.MakeSound();
            Animal animal = cat;
            animal.MakeSound(); // Method Hiding 
        }
    }
}
