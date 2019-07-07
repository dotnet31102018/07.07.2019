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

        interface A
        {
            void foo();
        }
        class B : A
        {
            public async void foo() // adding async into interface method will not break the interface!!!
            {
                //
            }
        }

        static async Task foo()
        {
            Console.WriteLine("hello");
            await Task.Run(() =>
            {
                Console.WriteLine("sleeping........");
                Thread.Sleep(3 * 1000);
            }); // waiing for task to be finished
            Console.WriteLine("after await............");

        }

        static void Main(string[] args)
        {
            Task t = foo();

            Console.WriteLine("hello");
            Console.WriteLine("working.........");
            t.Wait();
            //Console.ReadLine();
        }
    }
}
