using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Async_Programing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string selectedMenu;
            Console.WriteLine("Demo prallel - multi thread - async programing");
            PrintMenu();
            
            selectedMenu = Console.ReadLine();

            switch(selectedMenu){
                case "1":
                    Parallel_Test.ParallelFor();
                    break;
                case "2":       
                    var download = DownloadFile_Async.DownloadFile("https://google.com");     
                    Task_Test.DoSomething(5,"T1",ConsoleColor.Yellow);
                    var contentLength = await download;                                  
                    Console.WriteLine($"Content length is {contentLength}");
                    break;
                case "3":           
                    Task_Test.DoTest();
                    break;
                case "4":           
                    await ThreadvsAsyncAwait.DoTest();
                    break;
                case "5":
                    await TaskWhenAny.SumPageSizesAsync();
                    break;
                default:
                    Console.WriteLine("Wrong menu. Please select again");
                    break;
            }
         
         

            Console.WriteLine("Press any key ..."); 
            Console.ReadKey();
        }

        

        public static void PrintMenu(){
            Console.WriteLine("1. Paralel.");
            Console.WriteLine("2. Download file async");
            Console.WriteLine("3. Task - multi Task3");
            Console.WriteLine("4. Thread vs Async Await");
            Console.WriteLine("5. Task When Any");
            Console.WriteLine("Please select your choice:");        
        }
        
    }
}
   