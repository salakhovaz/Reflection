using System.Diagnostics;
using System.Text.Json;

namespace Reflection.Tests.SystemTextJson
{
    public static class SystemTextJsonDeserializeTest
    {
        public static long Run(int iterations, string serializeString)
        {
            Stopwatch sw = new();

            sw.Start();

            F systemTextJsonDeserializedObj = null;
            for (int i = 0; i < iterations; i++)
            {
                systemTextJsonDeserializedObj = JsonSerializer.Deserialize<F>(serializeString);
            }

            sw.Stop();

            long systemTextJsonDeserializeTime = sw.ElapsedMilliseconds;

            return systemTextJsonDeserializeTime;
        }
    }
}
