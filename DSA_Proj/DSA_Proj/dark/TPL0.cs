using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DSA_Proj.dark
{
    class TPL0
    {

         static void main(string[] args)
        {
            int[] nums = Enumerable.Range(0, 10000).ToArray();
            long total = 0;
            Parallel.ForEach<int, long>(nums,
                () => 0,
                (j, loop, subtotal) =>
                {
                    subtotal += j;
                    Console.WriteLine("loop : " + loop);
                    return subtotal;
                },
                (finalResult) => Interlocked.Add(ref total, finalResult));

            Console.ReadLine();
        }
    }
}
