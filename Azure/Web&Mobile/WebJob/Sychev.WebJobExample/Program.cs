using System;
using Microsoft.WindowsAzure.Jobs;

namespace Sychev.WebJobExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "DefaultEndpointsProtocol=https;AccountName=sychevigortestsite;AccountKey=dWDlc0DEcOvHufjiA2uZ7SjID5ZflmTeZvkhrEFIOQNFwqbZ3JNOjXgJ+GTYqvxhludZVVZBbTAQbnNTCBI/7g==";
            var host = new JobHost(str, str);
            host.RunAndBlock();
        }

        public static void ProcessQueue([QueueInput("myqueue")] string input,
            [QueueOutput("myqueuecopy")] out string output)
        {
            Console.WriteLine(input);
            output = input + " from WebJob";
        }

        //public static void HandleQueue(
        //    [BlobInput(@"images-output/{name}")] Stream inputStream,
        //    string name,
        //    [BlobOutput(@"images-processed/{name}")] Stream outputStream)
        //{
        //    if (name.Contains("SomeValue"))
        //    {
        //        inputStream.CopyTo(outputStream);
        //    }
        //}


        //public static void HandleQueue(
        //  [QueueInput(queueName: "myqueue")] CustomObject obj,
        //  [BlobInput("input/{Text}.txt")] Stream input,
        //  int Number,
        //  [BlobOutput("results/{Text}.txt")] Stream output)
        //{
        //}

        //public class CustomObject
        //{
        //    public string Text { get; set; }

        //    public int Number { get; set; }
        //}
    }
}
