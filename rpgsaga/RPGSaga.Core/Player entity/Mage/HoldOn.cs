namespace RPGSaga.Core
{
    using System.Collections.Generic;

    public class HoldOn : IAbility
    {
        public string AbilityTypeName { get; } = "Hold On";

        public int AbilityProbability { get; } = 30;

        public int DamageCoef { get; } = 0;

        public int NumberOfUse { get; set; } = 1;

        public IEnumerable<IEffect> AvailablefEffects { get; set; } = new List<IEffect>() { new SkipTurn() };
    }
}
