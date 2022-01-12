namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using Serilog;

    public class KeyboardConfig : IInputConfig
    {
        private int numberOfPlayers;

        private PlayerGenerator playerGenerator;

        public KeyboardConfig()
        {
            this.playerGenerator = new PlayerGenerator();
        }

        public List<Player> GetPlayers()
        {
            this.GetNumberOfPlayers();
            return this.playerGenerator.Generate(numberOfPlayers);
        }

        private void GetNumberOfPlayers()
        {
            Log.Information("Enter the number of players, please:");
            bool inputIsValid = false;
            while (!inputIsValid)
            {
                try
                {
                    inputIsValid = this.ValidateConsoleInput();
                }
                catch (ArgumentException ex)
                {
                    Log.Error(ex.Message);
                }
            }
        }

        private bool ValidateConsoleInput()
        {
            string input = Console.ReadLine();
            Log.Information($"Entered sequence: {input}");
            bool parseResult = int.TryParse(input, out numberOfPlayers);
            if (parseResult)
            {
                if (numberOfPlayers <= 1)
                {
                    throw new ArgumentException("Please enter a correct value. It should be at least higher than 1");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("You didn't enter a number, please try again");
            }
        }
    }
}
