using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
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
            int i = 0;
            while (true)
            {
                using (var client = new HttpClient())
                {
                    i++;
                    var result = await client.GetAsync("https://jsonplaceholder.typicode.com/albums/1");
                    Console.WriteLine($"Response: {result.StatusCode}");
                }
            }
        }
    }
}
