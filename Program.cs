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
            PrintInfor($"Finish task {i}");
        }

        public static void ParallelFor(){
            Console.WriteLine("Start testing Parallel.");
            ParallelLoopResult result = Parallel.For(1, 20, RunTask);   // Vòng lặp tạo ra 20 lần chạy RunTask
            Console.WriteLine($"All parallel task start and finish: {result.IsCompleted}");
            
            Console.ReadLine();
            Console.WriteLine("Start testing Task Run in Loop.");
            for(int a= 0; a <= 20; a++){
               Task.Run(() => RunTask(a));
            }
            Console.WriteLine("End testing Task Run in Loop.");
            Console.ReadLine();
            Console.WriteLine("Start testing Loop in task run.");
            Task.Run(() => {
                for(int a= 0; a <= 20; a++){
                    RunTask(a);
                }             
            });
            
            Console.WriteLine("End testing Loop in task rung.");
            
        }ß
    }
}
   