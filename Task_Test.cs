using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Async_Programing
{
    public class Task_Test{
        public Task_Test(){

        }

        public static void DoTest(){
            Console.WriteLine("Start do multile Task Test on thread " + Thread.CurrentThread.ManagedThreadId);

            Task task1 = new Task(() => DoSomething(5, "T1", ConsoleColor.Red));
            Task task3 = new Task(
                (obj)=> {
                        var taskName = (string)obj;
                        DoSomething(5, taskName, ConsoleColor.Green);
                }
                , "T3" );
            task1.Start();//new Thread
            Task.Run(() => DoSomething(5, "T2", ConsoleColor.Yellow)); // new thread
            task3.Start();// new thread
            DoSomething(5, "T4", ConsoleColor.Blue); // current thread;

            Task.WaitAll(task1,task3);
            Console.WriteLine("Finish do multile Task Test on thread " + Thread.CurrentThread.ManagedThreadId);
        }

        public static void DoSomething(int count, string taskName, ConsoleColor color)
        {       
            Console.WriteLine($"Task {taskName} start on thread {Thread.CurrentThread.ManagedThreadId}");
            for(int i = 1; i < count; i ++)
            {
                lock(Console.Out)
                {
                    Console.ForegroundColor = color;                    
                    Console.WriteLine($"Tast {taskName} : count{i}");
                    Console.ResetColor();
                }                                      
                Thread.Sleep(1 * 1000);
            }            
            
            Console.WriteLine($"Task {taskName} finish");
                   
        }
    }
}