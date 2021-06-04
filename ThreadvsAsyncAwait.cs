using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Async_Programing
{
    public class ThreadvsAsyncAwait{

        public static async Task DoTest(){
            Console.WriteLine ("Thead Vs Async/Await");
            UsingThread();
            UsingTask();
            await UsingAsycTask(); //run synchorinze
            await UsingAsycTaskSecond(); // run asychorinize
            Console.ReadKey ();
        
        }

        public static void UsingTask(){
            Console.WriteLine("-----------------------");
            Console.WriteLine ("UsingTask");

            var watch = new System.Diagnostics.Stopwatch ();
            watch.Start ();

            Task task1 = new Task(ThreadOne);
            Task task2 = new Task(ThreadTwo);

            task1.Start();
            task2.Start();
            
            Task.WaitAll(task1,task2);

            watch.Stop ();
            Console.WriteLine ($" Task Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static void UsingThread(){
            Console.WriteLine("-----------------------");
              Console.WriteLine ("UsingThread");
            var watch = new System.Diagnostics.Stopwatch ();
            watch.Start ();

            // sử dụng Thread để lập trình bất đồng bộ
            Thread th_one = new Thread(ThreadOne);
            Thread th_two = new Thread(ThreadTwo);

            th_one.Start ();
            th_two.Start ();

            // Chặn luồng tiếp tục cho tới khi các tiến trình th_one và th_two hoàn thành
            th_one.Join ();
            th_two.Join ();

            watch.Stop ();
            Console.WriteLine ($" Thread Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        public static async Task UsingAsycTask(){
            Console.WriteLine("-----------------------");
            Console.WriteLine ("UsingAsycTask");
            var watch = new System.Diagnostics.Stopwatch ();
            watch.Start ();

            // Task return value. using await but still run synchronize
            var task1 = await AsycnTask1();
            var task2 = await AsycnTask("2");

            
            
            Console.WriteLine("Alreay Finish task 1 : " + task1);           
            Console.WriteLine("Alreay Finish task 2 : " + task2);             

            watch.Stop ();
            Console.WriteLine ($" Async Task Execution Time: {watch.ElapsedMilliseconds} ms");
        }

         public static async Task UsingAsycTaskSecond(){
            Console.WriteLine("-----------------------");
            Console.WriteLine ("UsingAsycTask 2");
            var watch = new System.Diagnostics.Stopwatch ();
            watch.Start ();

            // Task return value. using await and run asynchronize
            var task1 = AsycnTask1();
            Console.WriteLine("11111");
            var task2 = AsycnTask("2");
            Console.WriteLine("2222");
            
            /// waiting for each task
            //var t1value = await task1;
            //var t2value = await task2;

            ////waiting for all task
            var results = await Task.WhenAll(task1,task2);
            Console.WriteLine("Alreay Finish task 1 : " + results[0] + " - at:" + watch.Elapsed.ToString());           
            Console.WriteLine("Alreay Finish task 2 : " + results[1] + " - at:" + watch.Elapsed.ToString());             

            watch.Stop ();
            Console.WriteLine ($" Async Task Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private static async Task<string> AsycnTask1(){
            Console.WriteLine("Start Async task 1");
            var content  = await DownloadFile_Async.DownloadFile("https://google.com.vn");
            Console.WriteLine("Finish Async task 1");
            return content;
        }

        private static async Task<string> AsycnTask(string taksName){
            Console.WriteLine("Start Async task " + taksName);
           var content  = await DownloadFile_Async.DownloadFile("https://google.com");
            Console.WriteLine("Finish Async task " + taksName);
            return "Async Task " + taksName + "  - Content: "+ content;
        }
        private static void ThreadOne () {
            Console.WriteLine("Start Thread 1");
            Thread.Sleep (5000);
            Console.WriteLine ("Finish Thread 1");
        }

        private static void ThreadTwo () {
            Console.WriteLine("Start Thread 2");
            Thread.Sleep (3000);
            Console.WriteLine ("Finish Thread 2");
        }
    }
}