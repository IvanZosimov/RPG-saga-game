namespace RPGSaga.Core
{
    using System.Collections.Generic;
    using Serilog;

    public class Round
    {
        private Duel duel = new Duel();

        public void CreateDuels(List<Player> listOfPlayers)
        {
            List<Player> subListOfWinners = new List<Player>();

            if (listOfPlayers.Count == 1)
            {
                Log.Information($"\n=================================\nGlobal winner is {listOfPlayers[0]}\n=================================");
                return;
            }

            if ((listOfPlayers.Count % 2) != 0)
            {
                int excessPlayer = Game.Rand.Next(0, listOfPlayers.Count);
                subListOfWinners.Add(listOfPlayers[excessPlayer]);
                listOfPlayers.RemoveAt(excessPlayer);
            }

            while (listOfPlayers.Count != 0)
            {
                int firstIndex = Game.Rand.Next(0, listOfPlayers.Count);
                Player firstHero = listOfPlayers[firstIndex];
                listOfPlayers.RemoveAt(firstIndex);

                int secondIndex = Game.Rand.Next(0, listOfPlayers.Count);
                Player secondHero = listOfPlayers[secondIndex];
                listOfPlayers.RemoveAt(secondIndex);

                subListOfWinners.Add(duel.GetWinner<Player>(firstHero, secondHero));
            }

            this.CreateDuels(subListOfWinners);
        }
    }
}
