namespace RPGSaga.Core
{
    public class PlayerDTO
    {
        public PlayerDTO(Player player)
        {
            this.Name = player.Name;
            this.PlayerTypeName = player.PlayerTypeName;
        }

        public PlayerDTO()
        {
        }

        public string Name { get; set; }

        public string PlayerTypeName { get; set; }
    }
}
