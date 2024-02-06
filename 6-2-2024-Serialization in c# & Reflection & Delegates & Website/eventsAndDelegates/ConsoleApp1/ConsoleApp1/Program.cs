using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    /*
     * Understanding Events:
    Events are a way to provide notifications to subscribers when a specific action or state change
        occurs. They are based on delegates and provide a layer of abstraction and encapsulation. 
        Events define a contract that specifies the signature of the delegate that can be subscribed to.

    Creating Events:
    To create an event, you need to define a delegate type that represents the event's signature. 
        Then, you can declare an event using the event keyword and associate it with the delegate type.
        Events are typically declared as public and can be subscribed to by external code.

    Handling Events:
    To handle an event, you need to subscribe to it by providing a method that matches the delegate's
        signature. This method will be executed when the event is raised. Event handlers can be added 
        or removed using the += and -= operators respectively.

    Removing Event Handlers:
    Event handlers can be removed from an event using the -= operator. It is important to remove event 
        handlers when they are no longer needed to prevent memory leaks and unexpected behavior.
     */
    public class Maths {
        public delegate void MathOperation(int a, int b);
        public delegate void MultiCastOperation(int a, int b);

        public event MathOperation substract;
        public event MultiCastOperation multiCastOperation;

        // Event accessors
        public event MathOperation add {
            add {
                Console.WriteLine("Adding assessor!");
                mathOperationAdd += value;
            }
            remove {
                Console.WriteLine("Removing assessor!");
                mathOperationAdd -= value;
            }
        }
        public MathOperation mathOperationAdd;
        

        public void Run() {
            mathOperationAdd(5,7);
            substract(10,7);
            multiCastOperation(10,7);
        }
    }
    public class Program {
        static void TestFunc(int a,int b) {
            Console.WriteLine("LO LO!");
        }
        static void Main(string[] args) {
            Maths maths = new Maths();
            maths.add += (a, b) => {
                Console.WriteLine(a + b);
            };
            maths.substract += (a, b) => {
                Console.WriteLine(a - b);
            };
            // This is multicast delegates as we are subscribing two methods to it
            maths.multiCastOperation += (a, b) => {
                Console.WriteLine("HA HA!");
            };
            maths.multiCastOperation += TestFunc;
            maths.Run();
            Thread.Sleep(3000);
            maths.multiCastOperation -= TestFunc;
            maths.Run();

            DelegatesTypes.Run();

            CovarienceAndContravarienceTypes covarienceAndContravarienceTypes = new CovarienceAndContravarienceTypes();
            covarienceAndContravarienceTypes.Run();

            // Demonstate an application with Events and Listeners 
            ApplicationWithEvents applicationWithEvents = new ApplicationWithEvents();
            applicationWithEvents.OnClickEvent += (sender, e) => {
                Console.WriteLine(sender.ToString());
            };
            applicationWithEvents.OnDblClickEvent += (sender, e) => {
                Console.WriteLine(sender.ToString());
            };
            applicationWithEvents.Run();

            Console.ReadLine();
        }
    }
}
