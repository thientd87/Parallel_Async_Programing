using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Async_Programing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"Thread Count:{Thread.GetCurrentProcessorId()}");
            ParallelFor();

            Console.WriteLine("Press any key ..."); 
            Console.ReadKey();
        }

        public static void PrintInfor(string infor){
            Console.WriteLine($"{infor} task:{Task.CurrentId} thread:{Thread.CurrentThread.ManagedThreadId}");
        }

        public static async void RunTask(int i){
            PrintInfor($"Start task {i}");
            await Task.Delay(1000);
            PrintInfor($"Finish task{i}");
        }

        public static void ParallelFor(){
            ParallelLoopResult result = Parallel.For(1, 20, RunTask);   // Vòng lặp tạo ra 20 lần chạy RunTask
            Console.WriteLine($"All task start and finish: {result.IsCompleted}");
        }
    }
}
