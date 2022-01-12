namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class FileConfig : IInputConfig
    {
        private PlayerGenerator playerGenerator;

        public FileConfig()
        {
            this.playerGenerator = new PlayerGenerator();
        }

        public List<Player> GetPlayers()
        {
            PlayerListSerializer.Deserialize();
            return playerGenerator.Generate();
        }
    }
}
