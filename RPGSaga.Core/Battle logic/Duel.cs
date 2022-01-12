namespace RPGSaga.Core
{
    using System.Text;
    using Serilog;

    public class Duel
    {
        private readonly StringBuilder sb = new StringBuilder();

        public T GetWinner<T>(T player1, T player2)
            where T : Player
        {
            int firstHeroHealth = player1.Health;
            int secondHeroHealth = player2.Health;
            sb.Append($"\nRound {Game.RoundCounter}.");
            Log.Information(sb.ToString());
            sb.Clear();
            sb.Append($"{player1} vs {player2}\n↓↓↓");
            Log.Information(sb.ToString());
            sb.Clear();
            try
            {
                while (player1.Health > 0 && player2.Health > 0)
                {
                    player1.ApplyEffects();

                    if (player2.Health <= 0 || player1.Health <= 0)
                    {
                        break;
                    }

                    if (!player1.SkipFlag && !player2.UsedAbility(player1))
                    {
                        player2.Attacked(player1);
                    }

                    if (player2.Health <= 0 || player1.Health <= 0)
                    {
                        break;
                    }

                    player2.ApplyEffects();

                    if (player2.Health <= 0 || player1.Health <= 0)
                    {
                        break;
                    }

                    if (!player2.SkipFlag && !player1.UsedAbility(player2))
                    {
                        player1.Attacked(player2);
                    }

                    if (player2.Health <= 0 || player1.Health <= 0)
                    {
                        break;
                    }

                    Log.Information("---");
                }

                return this.EnsureWellness(player1, player2, firstHeroHealth, secondHeroHealth);
            }
            catch (PlayerException ex)
            {
                Game.RoundCounter++;
                Log.Error($"{ex.TypeOfPlayer}s can't participate in the battle. We just kicked him out.");
                if (player1.PlayerTypeName == ex.TypeOfPlayer)
                {
                    player2.RefreshPlayer(secondHeroHealth);
                    Log.Information($"{player2} is local winner");
                    return player2;
                }
                else
                {
                    player1.RefreshPlayer(firstHeroHealth);
                    Log.Information($"{player2} is local winner");
                    return player1;
                }
            }
        }

        private T EnsureWellness<T>(T player1, T player2, int firstHeroHealth, int secondHeroHealth)
            where T : Player
        {
            if (player1.Health <= 0)
            {
                Log.Information($"{player1} has died out :(");
                player2.RefreshPlayer(secondHeroHealth);
                Game.RoundCounter++;
                return player2;
            }
            else
            {
                Log.Information($"{player2} has died out :(");
                player1.RefreshPlayer(firstHeroHealth);
                Game.RoundCounter++;
                return player1;
            }
        }
    }
}
