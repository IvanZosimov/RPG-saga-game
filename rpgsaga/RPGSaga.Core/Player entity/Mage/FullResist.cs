namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class FullResist : IAbility
    {
        public string AbilityTypeName { get; } = "Full Resist";

        public int AbilityProbability { get; } = 5;

        public int DamageCoef { get; } = 0;

        public int NumberOfUse { get; set; } = 1;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { new HealMe() };
    }
}
