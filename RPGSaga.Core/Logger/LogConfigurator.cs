namespace RPGSaga.Core
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Serilog;

    public static class LogConfigurator
    {
        private const string PathToSettings = @"appsettings.json";

        private static readonly string LogFilePath = $"Logs\\{DateTime.Now:MM_dd_yyyy_HH_mm_ss}.txt";

        public static void ConfigureLoggerJson()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(PathToSettings)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(LogFilePath)
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
