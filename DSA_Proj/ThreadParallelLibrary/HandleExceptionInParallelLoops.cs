using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadParallelLibrary
{
    class HandleExceptionInParallelLoops
    {

        public static void main()
        {
            byte[] data = new byte[5000];
            Random r = new Random();
            r.NextBytes(data);

            try
            {
                processDataInParallel(data);
            }
            catch (AggregateException e)
            {
                var ignoredExceptions = new List<Exception>();
                foreach (var ex in e.Flatten().InnerExceptions)
                {
                    if (ex is ArgumentException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else {
                        ignoredExceptions.Add(ex);
                    }
                }

                if (ignoredExceptions.Count > 0)
                    throw new AggregateException(ignoredExceptions);
            }
            catch (Exception e)
            {
                Console.WriteLine("Somethign else went wrong");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void processDataInParallel(byte [] data)
        {
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(data, d => {
                try
                {
                    if (d < 3)
                    {
                        throw new ArgumentException("Must be >= 3");
                    }
                    else
                        Console.Write(d + " ");

                }

                catch (Exception e)
                {
                    exceptions.Enqueue(e);
                }
            });

            Console.WriteLine();

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }
    }
}
