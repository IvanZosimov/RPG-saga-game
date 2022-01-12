namespace RPGSaga.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    public static class PlayerListSerializer
    {
        private const string PathToFolder = @"JSON repository";
        private static List<PlayerDTO> listOfPlayersDTO;

        static PlayerListSerializer()
        {
            PlayerListSerializer.listOfPlayersDTO = new List<PlayerDTO> { };
        }

        public static string FileNameToSave { get; set; }

        public static string FileNameToGet { get; set; }

        public static List<PlayerDTO> ListOfPlayersDTO
        {
            get { return PlayerListSerializer.listOfPlayersDTO; }
        }

        public static void Serialize(List<Player> initialList)
        {
            PlayerListSerializer.CreateDTO(initialList);

            string fullPath = PathToFolder + @"\" + FileNameToSave;

            File.WriteAllText(fullPath, JsonSerializer.Serialize(PlayerListSerializer.listOfPlayersDTO));
        }

        public static void Deserialize()
        {
            string fullPath = PathToFolder + @"\" + FileNameToGet;

            PlayerListSerializer.listOfPlayersDTO = JsonSerializer.Deserialize<List<PlayerDTO>>(File.ReadAllText(fullPath));
        }

        private static void CreateDTO(List<Player> initialList)
        {
            PlayerListSerializer.listOfPlayersDTO.Clear();
            foreach (Player player in initialList)
            {
                PlayerListSerializer.listOfPlayersDTO.Add(new PlayerDTO(player));
            }
        }
    }
}
