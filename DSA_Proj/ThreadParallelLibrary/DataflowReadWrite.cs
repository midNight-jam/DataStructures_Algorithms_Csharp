using System;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ThreadParallelLibrary
{
    class DataflowReadWrite
    {



        public static void main()
        {
            var bufferBlock = new BufferBlock<int>();
            // post several mesage to buffer block
            for (int i = 0; i < 5; i++)
            {
                bufferBlock.Post(i);
            }


            // recieve the message back from buffer block
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(bufferBlock.Receive());
            }



            // post more mesage to buffer block
            for (int i = 0; i < 5; i++)
            {
                bufferBlock.Post(i);
            }


            int msg = -1;
            while (bufferBlock.TryReceive(out msg))
            {
                Console.WriteLine(msg + ":");
            }


            // Write & read concurrently 

            var post1 = Task.Run(() =>
            {
                bufferBlock.Post(0);
                bufferBlock.Post(1);
            });

            var receive = Task.Run(() =>
             {
                 for (int i = 0; i < 3; i++)
                     Console.WriteLine(bufferBlock.Receive());
             });

            var post2 = Task.Run(() =>
            {
                bufferBlock.Post(2);
            });


            Task.WaitAll(receive, post2, post2);

            AsyncTaskPostRecieve(bufferBlock).Wait();
        }

        private static async Task AsyncTaskPostRecieve(BufferBlock<int> bufferBlock)
        {

            for (int i = 0; i < 3; i++)
            {
                await bufferBlock.SendAsync(i);
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("mm :: "+ await bufferBlock.ReceiveAsync());
            }
        }
    }
}
