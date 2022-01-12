namespace RPGSaga.Core
{
    using System;

    public static class Logger
    {
        public static void Info(string data)
        {
            Console.WriteLine(data);
        }

        public static void Info(string data, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(data);
            Console.ResetColor();
        }

        public static void Error(string data)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(data);
            Console.ResetColor();
        }
    }
}
