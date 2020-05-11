using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ThreadParallelLibrary
{
    class PerformActionWhenDataflowBlockReceivesData
    {

        static int CountZeroBytes(string path)
        {
            byte[] buffer = new byte[1024];
            int totalZeroBytesRead = 0;
            using (var fileStream = File.OpenRead(path))
            {
                int bytesRead = 0;

                do
                {
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    totalZeroBytesRead += buffer.Count(b => b == 0);
                } while (bytesRead > 0);
            }

            return totalZeroBytesRead;
        }

        public static void main()
        {

            string tempFile = Path.GetTempFileName();

            using (var fileStream = File.OpenWrite(tempFile))
            {
                Random rand = new Random();
                byte[] buffer = new byte[1024];
                for (int i = 0; i < 512; i++)
                {
                    rand.NextBytes(buffer);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }


            // Action block that puts out how many of the bytes read are 0 bytes from the file
            var printResultActionBlock = new ActionBlock<int>(zeroBytesRead =>
            {
                Console.WriteLine("{0} till now contains {1} zeroBytes", Path.GetFileName(tempFile), zeroBytesRead);
            });


            // Transform block that will call the CountZeroBytes function for evert chunk of data written in to the file
            //var countBytesTransformBlock = new TransformBlock<string, int>(new Func<string, int>(CountZeroBytes));


            var countBytesTransformBlock = new TransformBlock<string, int>(async path =>
            {
                byte[] buffer = new byte[1024];
                int totalZeroBytesRead = 0;
                using (var fileStream = new FileStream(
                   path, FileMode.Open, FileAccess.Read, FileShare.Read, 0x1000, true))
                {
                    int bytesRead = 0;
                    do
                    {
                        // Asynchronously read from the file stream.
                        bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length);
                        totalZeroBytesRead += buffer.Count(b => b == 0);
                    } while (bytesRead > 0);
                }

                return totalZeroBytesRead;
            });



            // Linking transformBlock to Actionblock
            countBytesTransformBlock.LinkTo(printResultActionBlock);

            // Create the continuation block that completes the action block when the transform block completes
            countBytesTransformBlock.Completion.ContinueWith(delegate { printResultActionBlock.Complete(); });

            // post the path to transformation block
            countBytesTransformBlock.Post(tempFile);


            //Request completion of transformation Block
            countBytesTransformBlock.Complete();

            // Wait for the printActionBlock to print to console.
            printResultActionBlock.Completion.Wait();

            File.Delete(tempFile);
        }
    }
}




















