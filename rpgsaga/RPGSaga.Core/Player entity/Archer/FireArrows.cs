namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class FireArrows : IAbility
    {
        public string AbilityTypeName { get; } = "Fire Arrows";

        public int AbilityProbability { get; } = 30;

        public int DamageCoef { get; } = 1;

        public int NumberOfUse { get; set; } = 1;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { new Burning() };
    }
}
