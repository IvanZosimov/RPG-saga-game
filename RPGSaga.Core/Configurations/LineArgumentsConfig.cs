namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class LineArgumentsConfig : IInputConfig
    {
        private int numberOfPlayers;

        private PlayerGenerator playerGenerator;

        public LineArgumentsConfig(int numberOfPlayers)
        {
            this.playerGenerator = new PlayerGenerator();
            this.numberOfPlayers = numberOfPlayers;
        }

        public List<Player> GetPlayers()
        {
            return this.playerGenerator.Generate(numberOfPlayers);
        }
    }
}
