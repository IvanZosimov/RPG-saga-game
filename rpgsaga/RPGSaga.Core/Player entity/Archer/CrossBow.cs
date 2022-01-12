namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class CrossBow : IAbility
    {
        public string AbilityTypeName { get; } = "Crossbow";

        public int AbilityProbability { get; } = 5;

        public int DamageCoef { get; } = 3;

        public int NumberOfUse { get; set; } = 1;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { };
    }
}
