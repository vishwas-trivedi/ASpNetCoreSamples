using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ParallelActionBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main start");
            var program = new Program();
            program.PerformCompute(5, 10);
            Console.WriteLine("main end");
        }
        
        public void PerformCompute(int maxParallalism, int executionCount)
        {
            var actionBlock = new ActionBlock<object[]>(DoSomething ,new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = maxParallalism });

            for (var indx = 0; indx < executionCount; indx++)
            {
                actionBlock.Post(new object[] { indx });
            }

            actionBlock.Complete();
            actionBlock.Completion.Wait();
        }

        public async Task DoSomething(object obj)
        {
            var data = obj as object[];
            var n = (int)data[0];

            Console.WriteLine($"Start : {n}");

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"[{n}] : [{i}]");
            }
            await Task.Delay(5000);
            Console.WriteLine($"End : {n}");
        }
    }
}
