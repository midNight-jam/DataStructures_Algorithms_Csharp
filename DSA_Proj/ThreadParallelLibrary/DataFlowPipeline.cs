using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks.Dataflow;

namespace ThreadParallelLibrary
{
    class DataFlowPipeline
    {

        public static void main()
        {
            //
            // Create the members of the pipeline.
            //

            // Downloads the requested resource as a string.
            var downloadString = new TransformBlock<string, string>(async uri =>
            {
                Console.WriteLine("Downloading '{0}'...", uri);

                return await new HttpClient().GetStringAsync(uri);
            });

            // Separates the specified text into an array of words.
            var createWordList = new TransformBlock<string, string[]>(text =>
            {
                Console.WriteLine("Creating word list...");

                // Remove common punctuation by replacing all non-letter characters
                // with a space character.
                char[] tokens = text.Select(c => char.IsLetter(c) ? c : ' ').ToArray();
                text = new string(tokens);

                // Separate the text into an array of words.
                return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            });

            // Removes short words and duplicates.
            var filterWordList = new TransformBlock<string[], string[]>(words =>
            {
                Console.WriteLine("Filtering word list...");

                return words
                   .Where(word => word.Length > 3)
                   .Distinct()
                   .ToArray();
            });

            // Finds all words in the specified collection whose reverse also
            // exists in the collection.
            var findReversedWords = new TransformManyBlock<string[], string>(words =>
            {
                Console.WriteLine("Finding reversed words...");

                var wordsSet = new HashSet<string>(words);

                return from word in words.AsParallel()
                       let reverse = new string(word.Reverse().ToArray())
                       where word != reverse && wordsSet.Contains(reverse)
                       select word;
            });

            // Prints the provided reversed words to the console.
            var printReversedWords = new ActionBlock<string>(reversedWord =>
            {
                Console.WriteLine("Found reversed words {0}/{1}",
                   reversedWord, new string(reversedWord.Reverse().ToArray()));
            });

            //
            // Connect the dataflow blocks to form a pipeline.
            //

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            downloadString.LinkTo(createWordList, linkOptions);
            createWordList.LinkTo(filterWordList, linkOptions);
            filterWordList.LinkTo(findReversedWords, linkOptions);
            findReversedWords.LinkTo(printReversedWords, linkOptions);

            // Process "The Iliad of Homer" by Homer.
            downloadString.Post("http://www.gutenberg.org/cache/epub/16452/pg16452.txt");

            // Mark the head of the pipeline as complete.
            downloadString.Complete();

            // Wait for the last block in the pipeline to process all messages.
            printReversedWords.Completion.Wait();
        }
    }
}
