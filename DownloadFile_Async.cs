using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Async_Programing
{
    public class DownloadFile_Async
    {
        
        public static async Task<string> DownloadFile(string url){
            Console.WriteLine($"Starting download {url} on thread {Thread.CurrentThread.ManagedThreadId}");
            if(string.IsNullOrEmpty(url))
                return "0";
            HttpClient client = new HttpClient();            
            var result = await client.GetStringAsync(url);
            Console.WriteLine($"Finish download {url}");
            return result.Length.ToString();
        }
    }
}
   