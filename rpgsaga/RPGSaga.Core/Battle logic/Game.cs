namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using Serilog;

    public static class Game
    {
        static Game()
        {
            Rand = new Random();
            RoundCounter = 1;
            SerializationNeeded = false;
        }

        public static IInputConfig InputConfig { get; set; }

        public static bool SerializationNeeded { get; set; }

        public static int RoundCounter { get; set; }

        public static Random Rand { get; }

        public static List<Player> ListOfPlayers { get; set; }

        public static void Run((IInputConfig config, bool serNeeded) configTuple)
        {
            try
            {
                Game.InputConfig = configTuple.config;
                Game.SerializationNeeded = configTuple.serNeeded;
                Game.ListOfPlayers = InputConfig.GetPlayers();
                if (Game.SerializationNeeded)
                {
                    PlayerListSerializer.Serialize(Game.ListOfPlayers);
                }

                Round round = new Round();
                round.CreateDuels(ListOfPlayers);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
