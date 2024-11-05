using System.Diagnostics;

namespace Reflection.Tests
{
    public static class ConsoleWriteTest
    {
        public static long Run(string serializeString) 
        {  
            Stopwatch sw = new();

            sw.Start();

            Console.WriteLine(serializeString);

            sw.Stop();

            long consoleWriteTime = sw.ElapsedMilliseconds;

            return consoleWriteTime;
        }
    } 
}
