using System.Diagnostics;

namespace Reflection.Tests.Custom
{
    public static class CustomSerializeTest
    {
        public static CustomSerializeTestResult Run(int iterations, F obj)
        {
            CustomSerializeTestResult testResult = new();
            Stopwatch sw = new();

            sw.Start();

            testResult.SerializeString = string.Empty;
            for (int i = 0; i < iterations; i++)
            {
                testResult.SerializeString = CustomJsonSerializer.Serialize(obj);
            }

            sw.Stop();

            testResult.SerializeTime = sw.ElapsedMilliseconds;

            return testResult;
        }
    }
}
