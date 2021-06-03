using System;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Async_Programing
{
    public class Parallel_Test
    {
        public Parallel_Test(){

        }
      public static void PrintInfor(string infor, ConsoleColor color){
          lock(Console.Out){
              Console.ForegroundColor = color;
              Console.WriteLine($"{infor} task:{Task.CurrentId} thread:{Thread.CurrentThread.ManagedThreadId}");
              Console.ResetColor();
          }
            
        }

        public static async void RunTask(int i, ConsoleColor color){
            await Task.Delay(1000);
            PrintInfor($"Start task {i}", color);
            await Task.Delay(1000);
            PrintInfor($"Finish task {i}", color);
        }

        public static void ParallelFor(){
            Console.WriteLine("Start testing Parallel.");
            ParallelLoopResult result = Parallel.For(1, 10, 
                i => {                    
                    RunTask(i,(ConsoleColor)new Random().Next(1,10));
                }                
            );   // Vòng lặp tạo ra 20 lần chạy RunTask
            Console.WriteLine($"All parallel task start and finish: {result.IsCompleted}");
            
            Console.ReadLine();
            
        }
    }
}
   