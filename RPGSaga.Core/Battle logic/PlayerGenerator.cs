namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using Serilog;

    public class PlayerGenerator
    {
        private NamesGenerator namesGenerator;

        private List<Player> listOfPlayers;

        public PlayerGenerator()
        {
            this.listOfPlayers = new List<Player> { };
            this.namesGenerator = new NamesGenerator();
        }

        public List<Player> Generate(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                switch (Game.Rand.Next(0, 4))
                {
                    case 0:
                        listOfPlayers.Add(new Warrior(namesGenerator.GetRandomName()));
                        break;
                    case 1:
                        listOfPlayers.Add(new Mage(namesGenerator.GetRandomName()));
                        break;
                    case 2:
                        listOfPlayers.Add(new Archer(namesGenerator.GetRandomName()));
                        break;
                    case 3:
                        listOfPlayers.Add(new Peasant(namesGenerator.GetRandomName()));
                        break;
                }
            }

            Log.Information($"{numberOfPlayers} players were successfully generated");

            return listOfPlayers;
        }

        public List<Player> Generate()
        {
            List<Player> outputList = new List<Player> { };
            foreach (PlayerDTO player in PlayerListSerializer.ListOfPlayersDTO)
            {
                switch (player.PlayerTypeName)
                {
                    case "Warrior":
                        outputList.Add(new Warrior(player.Name));
                        break;
                    case "Archer":
                        outputList.Add(new Archer(player.Name));
                        break;
                    case "Mage":
                        outputList.Add(new Mage(player.Name));
                        break;
                    case "Peasant":
                        outputList.Add(new Peasant(player.Name));
                        break;
                    default:
                        throw new ArgumentException($"Unsupported type of player \"{player.PlayerTypeName}\" was found.");
                }
            }

            Log.Information($"{PlayerListSerializer.ListOfPlayersDTO.Count} players were successfully generated");

            return outputList;
        }
    }
}
