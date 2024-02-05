using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollections {
    internal class ConcurrentCollectionsTest {
        static async Task Func1(ConcurrentBag<int> c, ConcurrentStack<int> stack,
            ConcurrentQueue<int> queue, ConcurrentDictionary<int, String> concurrentDictionary) {
            _ = Task.Run(() => {
                c.Add(1);
                c.Add(10);
                stack.Push(1);
                stack.Push(10);
                queue.Enqueue(1);
                queue.Enqueue(10);
                concurrentDictionary[1] = "One";
                concurrentDictionary[10] = "Ten";
            });

        }
        static async Task Func2(ConcurrentBag<int> c, ConcurrentStack<int> stack,
            ConcurrentQueue<int> queue, ConcurrentDictionary<int, String> concurrentDictionary) {
            _ = Task.Run(() => {
                c.Add(13);
                c.Add(16);
                stack.Push(13);
                stack.Push(16);
                queue.Enqueue(13);
                queue.Enqueue(16);
                concurrentDictionary[13] = "Thirteen";
                concurrentDictionary[16] = "Sixteen";
            });
        }
        static async Task Func3(ConcurrentBag<int> c, ConcurrentStack<int> stack,
            ConcurrentQueue<int> queue, ConcurrentDictionary<int, String> concurrentDictionary) {
            _ = Task.Run(() => {
                c.Add(20);
                c.Add(30);
                c.Add(40);
                stack.Push(20);
                stack.Push(30);
                stack.Push(40);
                queue.Enqueue(20);
                queue.Enqueue(30);
                queue.Enqueue(40);
                concurrentDictionary[20] = "Twenty";
                concurrentDictionary[30] = "Thirty";
                concurrentDictionary[40] = "Fourty";
            });
        }
        public static void Run() {
            ConcurrentBag<int> c = new ConcurrentBag<int>();
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            ConcurrentDictionary<int, String> concurrentDictionary = new ConcurrentDictionary<int, String>();


            var tasks = new Task[] {
                Func1(c,stack,queue, concurrentDictionary),
                Func2(c, stack,queue, concurrentDictionary),
                Func3(c, stack, queue, concurrentDictionary) };
            Task.WaitAll(tasks);
            Console.WriteLine("Set");
            foreach (var i in c) {
                Console.WriteLine(i);
            }
            Console.WriteLine("Stack");
            foreach (var i in stack) {
                Console.WriteLine(i);
            }
            Console.WriteLine("Queue");
            foreach (var i in queue) {
                Console.WriteLine(i);
            }
            Console.WriteLine("Dictionary");
            foreach (var i in concurrentDictionary) {
                Console.WriteLine(i.Key + " = " + i.Value);
            }

            
        }
    }
}
