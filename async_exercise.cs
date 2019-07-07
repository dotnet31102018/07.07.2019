using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _070719
{
    class Program
    {

        static async Task PrintMeAndNext(int number)
        {
            Console.WriteLine($"{number}: Thread id {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => {
                Console.WriteLine(number);
                Console.WriteLine($"{number}: Thread id {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            });

            Console.WriteLine($"Thread id {Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(() =>
            {
                Console.WriteLine(number + 1);
                Console.WriteLine($"{number}: Thread id {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            });

            Console.WriteLine($"{number}: Thread id {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Finished!!");

        }

        static void Main(string[] args)
        {
            Task t1 = PrintMeAndNext(10);
            Task t2 = PrintMeAndNext(20);
            Task t3 = PrintMeAndNext(30);

            Task.WaitAll(t1, t2, t3);
            Console.ReadLine();
        }
    }
}
