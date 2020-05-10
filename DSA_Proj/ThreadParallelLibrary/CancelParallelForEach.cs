using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadParallelLibrary
{
    class CancelParallelForEach
    {
        public static void main()
        {
            int[] nums = Enumerable.Range(0, 10000).ToArray();
            CancellationTokenSource cts = new CancellationTokenSource();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            Console.WriteLine("Press any key to start. Press 'c' to cancel.");
            Console.ReadKey();

            // Thread for watching the termination

            Task.Factory.StartNew(()=> {
                if (Console.ReadKey().KeyChar == 'c')
                    cts.Cancel();
            });


            try
            {
                Parallel.ForEach(nums, po, (num) =>
                {
                    double d = Math.Sqrt(num);
                    Console.WriteLine("{0} and {1}", d, Thread.CurrentThread.ManagedThreadId);
                    po.CancellationToken.ThrowIfCancellationRequested();
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }

            Console.WriteLine("Iam done...");
            Console.ReadLine();
        }
    }
}
