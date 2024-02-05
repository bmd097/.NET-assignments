using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollections { 

    internal class Program {

        static async Task<int> AlwaysWaitFor3Sec() {
            await Task.Delay(3000);
            Console.WriteLine("Completed!");
            return 1;
        }

        static async Task MultiLineExecution() {
            // It will wait for all tasks to complete 
            Console.WriteLine("MIL");
            var results = await Task.WhenAll(new Task<int>[] { // returns int told to WhenAll 
                AlwaysWaitFor3Sec(),
                AlwaysWaitFor3Sec(),
                AlwaysWaitFor3Sec(),
                AlwaysWaitFor3Sec()
            }); // This is a synchronous operation
            Console.WriteLine("ATE");
            Task.WhenAll(new Task[] {
                AlwaysWaitFor3Sec(),
                AlwaysWaitFor3Sec(),
                AlwaysWaitFor3Sec(),
                AlwaysWaitFor3Sec()
            }); // THIS IS NOT SYNCHRONOUS TASK
            // Now you can access the results
            foreach (var result in results) {
                Console.WriteLine(result);
            }
        }


        public static async Task SubPartFunc1() {
            await Task.Delay(3000);
            Console.WriteLine("Sub Fun 1");
        }
        public static async Task SubPartFunc2() {
            await Task.Delay(2000);
            Console.WriteLine("Sub Fun 2");
        }
        public static async Task SubPartFunc3() {
            await Task.Delay(2000);
            Console.WriteLine("Sub Fun 3");
        }
        public static async Task SubPartFunc4() {
            await Task.Delay(2000);
            Console.WriteLine("Sub Fun 4");
        }
        public static async Task SubPartFunc5() {
            await Task.Delay(1000);
            Console.WriteLine("Sub Fun 5");
        }

        public static async Task RunSomeFunctionWithNoAwait() {
            long start = DateTime.Now.Ticks;
            Console.WriteLine("Tatoo");
            SubPartFunc1();
            SubPartFunc2();
            SubPartFunc3();
            SubPartFunc4();
            SubPartFunc5();
            Console.WriteLine("Prank");
            long end = DateTime.Now.Ticks;
            Console.WriteLine((end - start) / (double)TimeSpan.TicksPerSecond);
        }
        public static async Task RunSomeFunctionWithAwait() {
            long start = DateTime.Now.Ticks;
            Console.WriteLine("Tatoo");
            await SubPartFunc1();
            await SubPartFunc2();
            await SubPartFunc3();
            await SubPartFunc4();
            await SubPartFunc5();
            Console.WriteLine("Prank");
            long end = DateTime.Now.Ticks;
            Console.WriteLine((end - start) / (double)TimeSpan.TicksPerSecond);
        }
        public static async Task RunSomeFunctionWithTaskWhenAll() {
            long start = DateTime.Now.Ticks;
            Console.WriteLine("Tatoo");
            List<Task> tasks = new List<Task>();
            for(int i = 0; i < 50; i++) {
                var t1 = SubPartFunc1();
                var t2 = SubPartFunc2();
                var t3 = SubPartFunc3();
                var t4 = SubPartFunc4();
                var t5 = SubPartFunc5();
                tasks.Add(t1);
                tasks.Add(t2);
                tasks.Add(t3);
                tasks.Add(t4);
                tasks.Add(t5);
            }
            await Task.WhenAll(tasks);
            Console.WriteLine("Prank");
            long end = DateTime.Now.Ticks;
            Console.WriteLine((end - start) / (double)TimeSpan.TicksPerSecond);
        }




        public static void Main(string[] args) {
            // ConcurrentCollectionsTest.Run();

            // long startTime = DateTime.Now.Ticks;
            // Console.WriteLine("A");
            // Task.Run(MultiLineExecution).GetAwaiter().GetResult();
            // Console.WriteLine("B");
            // long endTime = DateTime.Now.Ticks;
            // Console.WriteLine((endTime - startTime));

            // RunSomeFunctionWithNoAwait();
            // RunSomeFunctionWithAwait();
            RunSomeFunctionWithTaskWhenAll();


            // Concept of Progress
            Progress<int> progress = new Progress<int>(); // catch it in IProgress
            // Subscribe to the ProgressChanged event
            progress.ProgressChanged += (sender, e) => {
                Console.WriteLine($"Progress: {e}%");
            };
            Thread.Sleep(5000);
            IProgress<int> containerProgress = progress;
            containerProgress.Report(177);
            Thread.Sleep(5000);
            containerProgress.Report(197);


            // Cancellation Token concept
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            Task.Run(() => {
                try {
                    while (true) token.ThrowIfCancellationRequested();
                } catch (OperationCanceledException e) {
                    Console.WriteLine($"Canceled: {e.Message}");
                }
            });
            Task.Run(async () => {
                await Task.Delay(4000);
                cts.Cancel();
            });


            // Parallel ForEach
            string[] items = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            Parallel.ForEach(items, item => {
                Console.WriteLine($"Processing {item} on thread {Task.CurrentId}");
                Task.Delay(1000).Wait(); // Simulate some work
            });

            Console.ReadLine();
        }
    }
}
