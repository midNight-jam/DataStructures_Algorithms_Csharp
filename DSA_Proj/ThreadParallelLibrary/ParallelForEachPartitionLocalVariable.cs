using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadParallelLibrary
{
    class ParallelForEachPartitionLocalVariable
    {
        public static void main()
        {
            int[] nos = Enumerable.Range(0, 100000).ToArray();
            long total = 0;
            Parallel.ForEach<int, long>(nos,
                ()=>0,
                (j, loop, subTotal)=>{
                    subTotal += j;
                    //Console.WriteLine("l# : " + loop.LowestBreakIteration, loop.IsStopped);
                    return subTotal;
                }, (finalresult)=> Interlocked.Add(ref total, finalresult));

            Console.WriteLine("res : " + total);
        }
    }
}
