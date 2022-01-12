using System.Collections.Generic;
using RPGSaga.Core;
using Xunit;

public class PlayerGeneratorTests
{
    [Fact]
    public void Generate_generates_list_of_players_using_input_number()
    {
        // Arrange
        PlayerGenerator playerGenerator = new PlayerGenerator();
        List<Player> emptyList = new List<Player>();
        int numberOfPlayers = 20;

        // Act
        emptyList = playerGenerator.Generate(numberOfPlayers);

        // Assert
        Assert.Equal(emptyList.Count, numberOfPlayers);
    }
}