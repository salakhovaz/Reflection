using System.Diagnostics;
using System.Text.Json;

namespace Reflection.Tests.SystemTextJson
{
    public static class SystemTextJsonSerializeTest
    {
        public static SystemTextJsonSerializeTestResult Run(int iterations, F obj)
        {
            SystemTextJsonSerializeTestResult testResult = new();
            Stopwatch sw = new();

            sw.Start();

            testResult.SerializeString = string.Empty;
            for (int i = 0; i < iterations; i++)
            {
                testResult.SerializeString = JsonSerializer.Serialize(obj);
            }

            sw.Stop();

            testResult.SerializeTime = sw.ElapsedMilliseconds;

            return testResult;
        }
    }
}
