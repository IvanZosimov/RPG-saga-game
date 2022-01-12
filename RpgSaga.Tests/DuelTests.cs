using RPGSaga.Core;
using Xunit;

public class DuelTests
{
    [Theory]
    [InlineData(1, 1000, "Player2")]
    [InlineData(1000, 1, "Player1")]
    public void GetWinner_returns_winner(int health1, int health2, string playerName)
    {
        // Arrange
        var player1 = new NoSkillEntity("Player1");
        player1.Health = health1;
        var player2 = new NoSkillEntity("Player2");
        player2.Health = health2;
        var duel = new Duel();

        // Act
        var result = duel.GetWinner(player1, player2);

        // Assert
        Assert.True(result.Name == playerName);
    }
}
