namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Serilog;

    public abstract class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public int Health { get; set; }

        public int Power { get; set; }

        public string PlayerTypeName { get; set; }

        public bool SkipFlag { get; set; }

        protected internal virtual IReadOnlyList<IAbility> PullOfAbilites { get; set; } = new List<IAbility>();

        protected internal IList<IEffect> PullOfEffects { get; set; } = new List<IEffect>();

        public void Attacked(Player enemy)
        {
            this.SkipFlag = false;
            Log.Information($"{enemy.ToStringWithHealth()} deals damage of {enemy.Power} to {this.ToStringWithHealth()}");
            this.Health -= enemy.Power;
        }

        public bool UsedAbility(Player enemy)
        {
            if (!enemy.PullOfAbilites.Any())
            {
                return false;
            }

            IAbility chosenAbility = enemy.PullOfAbilites[Game.Rand.Next(0, enemy.PullOfAbilites.Count)];
            var abilityStatus = chosenAbility.UseAbility();
            if (!abilityStatus)
            {
                return false;
            }

            foreach (IEffect effect in chosenAbility.AvailablefEffects)
            {
                if (!effect.SelfEffect)
                {
                    if (this.PullOfEffects.Any(x => x.EffectTypeName == effect.EffectTypeName))
                    {
                        this.PullOfEffects.Remove(effect);
                        this.PullOfEffects.Add(effect);
                    }
                    else
                    {
                        this.PullOfEffects.Add(effect);
                    }
                }
                else
                {
                    enemy.GetSelfEffect(effect);
                }
            }

            Log.Information($"{enemy.ToStringWithHealth()} applies {chosenAbility.AbilityTypeName}" +
                $"{(chosenAbility.DamageCoef != 0 ? $" and deals damage of {enemy.Power * chosenAbility.DamageCoef} to {this.ToStringWithHealth()}" : " ")} ");
            this.Health -= enemy.Power * chosenAbility.DamageCoef;
            return true;
        }

        public void ApplyEffects()
        {
            foreach (IEffect effect in this.PullOfEffects)
            {
                if (effect.UseEffect())
                {
                    if (effect.SkipFlag)
                    {
                        this.SkipFlag = true;
                        Log.Information($"{this.ToStringWithHealth()} {effect.Definition}");
                    }
                    else
                    {
                        if (effect.RegularDamage < 0)
                        {
                            Log.Information($"{this.ToStringWithHealth()} {effect.Definition} {-effect.RegularDamage}");
                            this.Health -= effect.RegularDamage;
                        }
                        else
                        {
                            Log.Information($"{this.ToStringWithHealth()} {effect.Definition} {effect.RegularDamage}");
                            this.Health -= effect.RegularDamage;
                        }
                    }
                }
            }
        }

        public void RefreshPlayer(int health)
        {
            this.Health = health;
            this.PullOfEffects.Clear();
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.PlayerTypeName})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Player))
            {
                return false;
            }

            Player p = (Player)obj;
            return Name == p.Name && Health == p.Health && Power == p.Power && PlayerTypeName == p.PlayerTypeName;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Health, Power, Name, PlayerTypeName).GetHashCode();
        }

        public string ToStringWithHealth()
        {
            return $"{this.Name} ({this.PlayerTypeName} → {this.Health} HP)";
        }

        private void GetSelfEffect(IEffect effect)
        {
            this.PullOfEffects.Add(effect);
        }
    }
}
