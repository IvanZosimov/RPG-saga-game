using System;
using RPGSaga.Core;
using Xunit;

public class PlayerTests
{
    [Fact]
    public void ToString_returns_name_and_type()
    {
        // Arrange
        var player = new Warrior("Ivan");

        // Act
        var result = player.ToString();

        // Assert
        Assert.Equal("Ivan (Warrior)", result);
    }

    [Fact]
    public void ToStringWithHealth_returns_name_type_and_hp()
    {
        // Arrange
        var player = new Warrior("Ivan");

        // Act
        var result = player.ToStringWithHealth();

        // Assert
        Assert.Equal("Ivan (Warrior → 150 HP)", result);
    }

    [Fact]
    public void RefreshPlayer_changes_hp_to_specified()
    {
        // Arrange
        var player = new Warrior("Ivan");
        int newHealth = 1000;

        // Act
        player.RefreshPlayer(newHealth);

        // Assert
        Assert.Equal(newHealth, player.Health);
    }

    [Fact]
    public void Attacked_reduces_hp_by_enemy_power()
    {
        // Arrange
        var player = new Warrior("Ivan");
        var initialHealth = player.Health;
        var enemy = new NoSkillEntity("Armen");

        // Act
        player.Attacked(enemy);

        // Assert
        Assert.Equal(player.Health, initialHealth - enemy.Power);
    }

    [Fact]
    public void Equals_same_objects_returns_true()
    {
        // Arrange
        var player1 = new Warrior("Ivan");
        var player2 = new Warrior("Ivan");

        // Act
        var result = player1.Equals(player2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_different_objects_returns_false()
    {
        // Arrange
        var player1 = new Warrior("Ivan");
        var player2 = new Warrior("Habib");

        // Act
        var result = player1.Equals(player2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UsedAbillity_returns_false_if_pull_is_empty()
    {
        // Arrange
        var player1 = new Warrior("Ivan");
        var player2 = new NoSkillEntity("Habib");

        // Act
        var result = player1.UsedAbility(player2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UsedAbillity_returns_true_if_player_used_skill()
    {
        // Arrange
        var player1 = new Warrior("Ivan");
        var player2 = new PermanentSkillEntity("Albert");

        // Act
        var result = player1.UsedAbility(player2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsedAbillity_returns_false_if_ability_not_available()
    {
        // Arrange
        var player1 = new Warrior("Ivan");
        var player2 = new ZeroNumberOfSkillUseEntity("Albert");

        // Act
        var result = player1.UsedAbility(player2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ApplyEffects_skipturn_effect_applies_skip_flag()
    {
        // Arrange
        var player = new SkipTurnEntity("Albert");

        // Act
        player.ApplyEffects();

        // Assert
        Assert.True(player.SkipFlag);
    }

    [Fact]
    public void ApplyEffects_regular_damage_changes_health()
    {
        // Arrange
        var player = new RegularDamageEntity("Albert");
        var initialHealth = player.Health;

        // Act
        player.ApplyEffects();

        // Assert
        Assert.True(player.Health != initialHealth);
    }

    [Fact]
    public void UsedAbility_if_enemy_skips_turn_it_deals_zero_damage()
    {
        // Arrange
        var player = new Archer("Ivan");
        var initialHealth = player.Health;
        var enemy = new SkipTurnEntity("Albert");
        enemy.ApplyEffects();

        // Act
        player.UsedAbility(enemy);

        // Assert
        Assert.True(player.Health == initialHealth);
    }

    [Fact]
    public void Player_throws_PlayerException_when_PullOfAbilities_is_unavailable()
    {
        // Arrange
        var enemy = new Peasant("Ivan");
        var player = new Archer("Armen");

        // Act
        Action act = () => player.UsedAbility(enemy);

        // Act/Assert
        Assert.Throws<PlayerException>(act);
    }
}