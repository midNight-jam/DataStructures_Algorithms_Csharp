using System;

namespace ThreadParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //ParallelForEachPartitionLocalVariable.main();
            //CancelParallelForEach.main();
            //HandleExceptionInParallelLoops.main();
            //DataflowReadWrite.main();
            DataflowProducerConsumer.main();




            Console.ReadLine();
        }
    }
}
