using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public static class AsyncMethods
    {
        public static async Task<int> Method1Async()
        {
            await Task.Delay(2000);
            // Console.WriteLine($"This is Method1");
            return 1;
        }

        public static async Task<int> Method2Async()
        {
            await Task.Delay(2000);
            // Console.WriteLine($"This is Method2");
            return 2;
        }
        public static async Task<int> Method3Async()
        {
            await Task.Delay(2000);
            // Console.WriteLine($"This is Method3");
            return 3;
        }
        public static async Task<int> Method4Async()
        {
            await Task.Delay(2000);
            // Console.WriteLine($"This is Method4");
            return 4;
        }
    }
}