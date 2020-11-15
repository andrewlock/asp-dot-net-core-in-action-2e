using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocketExhaustion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Run netstat in a console to see sockets being used
            // Use netstat -n on Windows to skip DNS resolution
            int i = 0;
            while (true)
            {
                using (var client = new HttpClient())
                {
                    i++;
                    // jsonplaceholder.typicode.com = 172.64.107.5
                    var result = await client.GetAsync("https://jsonplaceholder.typicode.com/albums/1");
                    Console.WriteLine($"Response {i}: {result.StatusCode}");
                }
            }
        }
    }
}
