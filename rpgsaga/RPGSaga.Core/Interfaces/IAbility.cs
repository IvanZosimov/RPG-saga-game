namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public interface IAbility
    {
        public string AbilityTypeName { get; }

        public int AbilityProbability { get; }

        public int DamageCoef { get; }

        public int NumberOfUse { get; set; }

        public IEnumerable<IEffect> AvailablefEffects { get; set; }

        public bool UseAbility()
        {
            {
                if (this.NumberOfUse == 0)
                {
                    return false;
                }

                if (Game.Rand.Next(1, 101) <= this.AbilityProbability)
                {
                    this.NumberOfUse--;
                    return true;
                }

                return false;
            }
        }
    }
}