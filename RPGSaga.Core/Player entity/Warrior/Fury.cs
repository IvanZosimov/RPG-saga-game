namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class Fury : IAbility
    {
        public string AbilityTypeName { get; } = "Fury";

        public int AbilityProbability { get; } = 40;

        public int DamageCoef { get; } = 2;

        public int NumberOfUse { get; set; } = 1;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { };
    }
}
