using System;
using System.IO;

namespace _1_Задание
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLogger = new LocalFileLogger<string>(@"C:\Bars.txt");
            fileLogger.LogInfo("Информация о файле");
            fileLogger.LogWarrning("Опасность");
            fileLogger.LogError("Ошибка", new Exception());

            var fileLogger1 = new LocalFileLogger<float>(@"C:\Bars.txt");
            fileLogger1.LogInfo("Information");
            fileLogger1.LogWarrning("Dangerous");
            fileLogger1.LogError("Error", new Exception());

            var fileLogger2 = new LocalFileLogger<int>(@"C:\Bars.txt");
            fileLogger2.LogInfo("Infolrmation or Zadanie");
            fileLogger2.LogWarrning("Zadanie in warning");
            fileLogger2.LogError("Zadanie contains Error", new Exception());
        }

        public interface ILogger
        {
            public void LogInfo(string message);
            public void LogWarrning(string message);
            public void LogError(string message, Exception ex);
        }

        public class LocalFileLogger<T> : ILogger
        {
            public string Name { get; }
            public LocalFileLogger(string name)
            {
                Name = name;
            }

            public void LogInfo(string message)
            {
                File.AppendAllText(Name, $"[Info]: [{typeof(T).Name}] : {message}" + Environment.NewLine);
            }

            public void LogWarrning(string message)
            {
                File.AppendAllTextAsync(Name, $"[Warning]:[{typeof(T).Name}]:{message}" + Environment.NewLine);
            }

            public void LogError(string message, Exception ex)
            {
                File.AppendAllTextAsync(Name, $"[Error]:[{typeof(T).Name}]:{message}.{ex.Message}");
            }

        }
    }
}
