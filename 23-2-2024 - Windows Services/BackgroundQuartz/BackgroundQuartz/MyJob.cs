using Quartz;
using System;
using System.Threading.Tasks;
namespace BackgroundQuartz {
    public class MyJob : IJob {
        public async Task Execute(IJobExecutionContext context) {
            // Your job logic goes here
            Console.WriteLine("My job is running!");
            await Task.CompletedTask;
        }
    }
}