using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_app
{
    using System;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            // Create a thread to simulate a background task
            Thread workerThread = new Thread(DoWork);
            workerThread.Start();

            try
            {
                // Simulate some main thread work
                Console.WriteLine("Main thread is doing some work...");
                Thread.Sleep(2000); // Simulating work

                // Intentionally throw an exception for error handling practice
                throw new ApplicationException("An error occurred in the main thread.");
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine($"Error in main thread: {ex.Message}");
            }

            // Wait for the worker thread to complete
            workerThread.Join();

            Console.WriteLine("Main thread completed.");
            Console.ReadLine();
        }

        static void DoWork()
        {
            try
            {
                // Simulate some background work
                Console.WriteLine("Worker thread is doing some work...");
                Thread.Sleep(3000); // Simulating work

                // Intentionally throw an exception for error handling practice
                throw new InvalidOperationException("An error occurred in the worker thread.");
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine($"Error in worker thread: {ex.Message}");
            }

            Console.WriteLine("Worker thread completed.");
        }
    }

}
