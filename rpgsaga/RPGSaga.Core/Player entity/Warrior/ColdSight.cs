namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class ColdSight : IAbility
    {
        public string AbilityTypeName { get; } = "Cold Sight";

        public int AbilityProbability { get; } = 20;

        public int DamageCoef { get; } = 0;

        public int NumberOfUse { get; set; } = 1;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { new SkipTurn() };
    }
}
