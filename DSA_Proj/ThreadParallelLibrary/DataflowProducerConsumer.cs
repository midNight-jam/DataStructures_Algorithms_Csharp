using System;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ThreadParallelLibrary
{
    class DataflowProducerConsumer
    {

        static void Produce(ITargetBlock<byte[]> target)
        {
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                byte[] chunkData = new byte[1024];
                rand.NextBytes(chunkData);
                target.Post(chunkData);
            }

            // signal that producer has finished
            target.Complete();
        }

        static async Task<int> ConsumeAsync(ISourceBlock<byte[]> source)
        {
            int chunksProcessed = 0;
            int byteProcessed = 0;

            // keep reading untill source data is exhausted
            while (await source.OutputAvailableAsync())
            {
                byte[] sourceChunkData = source.Receive();
                chunksProcessed++;
                byteProcessed += sourceChunkData.Length;
            }


            Console.WriteLine("Chunks ; " + chunksProcessed);
            return byteProcessed;
        }

        public static void main()
        {
            var buffer = new BufferBlock<byte[]>();

            var consumer = ConsumeAsync(buffer);


            // start producer

            Produce(buffer);

            consumer.Wait();

            Console.WriteLine("Processed bytes : {0}", consumer.Result);
        }
    }
}
