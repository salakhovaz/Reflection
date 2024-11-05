using Reflection;
using Reflection.Tests;
using Reflection.Tests.Custom;
using Reflection.Tests.SystemTextJson;

class Program
{
    static void Main(string[] args)
    {
        int iterations = 100000;

        F obj = F.Get();

        // Сериализация Custom
        CustomSerializeTestResult customSerializeTestResult = CustomSerializeTest.Run(iterations, obj);

        Console.WriteLine("Сериализация Custom с использованием Reflection:");
        Console.WriteLine($"Время на сериализацию = {customSerializeTestResult.SerializeTime} мс");
        Console.WriteLine($"Время вывода в консоль: {ConsoleWriteTest.Run(customSerializeTestResult.SerializeString)} мс");

        // Десериализация Custom
        long customDeserializeTime = CustomDeserializeTest.Run(iterations, customSerializeTestResult.SerializeString);

        Console.WriteLine($"Время на десериализацию = {customDeserializeTime} мс\n");

        // Сериализация System.Text.Json
        SystemTextJsonSerializeTestResult systemTextJsonSerializeTestResult = SystemTextJsonSerializeTest.Run(iterations, obj);

        Console.WriteLine("Сериализация System.Text.Json:");
        Console.WriteLine($"Время на сериализацию = {systemTextJsonSerializeTestResult.SerializeTime} мс");
        Console.WriteLine($"Время вывода в консоль: {ConsoleWriteTest.Run(systemTextJsonSerializeTestResult.SerializeString)} мс");

        // Десериализация System.Text.Json
        long systemTextJsonDeserializeTime = SystemTextJsonDeserializeTest.Run(iterations, systemTextJsonSerializeTestResult.SerializeString);

        Console.WriteLine($"Время на десериализацию = {systemTextJsonDeserializeTime} мс");
    }
}