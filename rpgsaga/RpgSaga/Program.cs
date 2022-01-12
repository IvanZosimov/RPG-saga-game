using System;
using RPGSaga.Core;
using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        LogConfigurator.ConfigureLogger();

        ConfigController configController = new ConfigController();
        try
        {
            Game.Run(configController.ChooseConfiguration(args));
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
    }
}