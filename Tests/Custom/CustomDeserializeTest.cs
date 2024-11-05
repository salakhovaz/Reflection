using System.Diagnostics;

namespace Reflection.Tests.Custom
{
    public static class CustomDeserializeTest
    {
        public static long Run(int iterations, string serializeString)
        {
            Stopwatch sw = new();

            sw.Start();

            F deserializedObj = null;
            for (int i = 0; i < iterations; i++)
            {
                deserializedObj = CustomJsonDeserializer.Deserialize<F>(serializeString);
            }

            sw.Stop();

            long customDeserializeTime = sw.ElapsedMilliseconds;

            return customDeserializeTime;
        }
    }
}
